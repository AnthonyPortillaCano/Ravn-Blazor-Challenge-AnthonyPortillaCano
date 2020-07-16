#pragma checksum "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Pages\People.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dada7c68f6d5d16540c97947629145c1abe5cef"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Blazor.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Blazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Blazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\_Imports.razor"
using Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Pages\People.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class People : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "E:\NetCore3.1Cursos\EntrevistaDemoBlazor\Solution\Blazor.Client\Pages\People.razor"
       
    private List<PeopleResults> people { get; set; }
    private int actualPage = 1;
    private int totalPages;
    private string height = string.Empty;
    protected override async Task OnInitializedAsync()
    {
        await LoadPeople();
    }

    private async Task SelectedPage(int page)
    {
        actualPage = page;
        await LoadPeople(page);
    }

    private async Task Filter()
    {
        actualPage = 1;
        await LoadPeople();
    }

    private async Task Clean()
    {
        height = string.Empty;
        actualPage = 1;
        await LoadPeople();
    }
    async Task LoadPeople(int page = 1, int quantityRecordsShow = 10)
    {
        var httpResponse = await Http.GetAsync($"http://localhost:53466/people/listpeople?Page={page}&QuantityShow={quantityRecordsShow}&height={height}");

        if (httpResponse.IsSuccessStatusCode)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            people = JsonSerializer.Deserialize<List<PeopleResults>>(responseString,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            totalPages = Convert.ToInt32(people.FirstOrDefault().totalPages);
        }
        else
        {
            Console.WriteLine("error");
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
