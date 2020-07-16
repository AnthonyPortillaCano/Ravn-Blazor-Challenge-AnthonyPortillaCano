using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazor.Server.Helpers;
using Blazor.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Blazor.Server.Controllers
{
    [Route("People")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        public PeopleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("ListPeople")]
        public async Task<List<PeopleResults>> ListPeople([FromQuery] Pagination pagination, [FromQuery] string height)
        {
            People people = new People();
            IEnumerable<PeopleResults> peopleResults = Enumerable.Empty<PeopleResults>();
            try
            {
                string result;

                using (var client = new HttpClient())

                {
                    client.BaseAddress = new Uri(_configuration["urlStarWars"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("people/");
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        people = JsonConvert.DeserializeObject<People>(result);

                    }
                    peopleResults= height==null? people.results: people.results.Where(x => x.height.Contains(height.Trim()));
                  double totalPages= HttpContext.InsertParametersPageInResponse(peopleResults, pagination.QuantityShow);
                    peopleResults.FirstOrDefault().totalPages = totalPages;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
                return peopleResults.Page(pagination).Cast<PeopleResults>().ToList();
        }

        [HttpGet]
        [Route("detailPeople/{id}")]
        public async Task<IActionResult> GetPeopleByUrl( string  id)
        {
            People people = new People();
           PeopleResults peopleResults =new  PeopleResults();
            try
            {
                string result;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["urlStarWars"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("people/");
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        people = JsonConvert.DeserializeObject<People>(result);

                    }
                    peopleResults =  people.results.Where(x => x.url.Contains(id.Trim())).FirstOrDefault();
  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(peopleResults);
        }
    }
}
