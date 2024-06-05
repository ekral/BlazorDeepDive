using ServerManagement.Models;

namespace ServerManagement
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly List<City> cities = 
        [ 
            new() { Name = "Toronto" }, 
            new() { Name = "Montreal" },
            new() { Name = "Ottawa" },
            new() { Name = "Calgary" },
            new() { Name = "Halifax" }
        ];

        public List<City> GetCities() => cities;
    }

}
