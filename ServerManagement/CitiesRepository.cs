namespace ServerManagement
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly List<string> cities = ["Toronto"/*, "Montreal", "Ottawa", "Calgary", "Halifax"*/];

        public List<string> GetCities() => cities;
    }

}
