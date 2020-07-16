using System.Collections.Generic;

namespace Blazor.Shared
{
    public class People
    {
        public string count { get; set; }
        public string next { get; set; }

        public IEnumerable<PeopleResults> results { get; set; }
    }
}
