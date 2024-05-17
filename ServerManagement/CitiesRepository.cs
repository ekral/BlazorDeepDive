namespace ServerManagement
{
    public class CitiesRepository : ICitiesRepository
    {
        private List<string> cities = ["Toronto", "Montreal", "Ottawa", "Calgary", "Halifax"];

        public List<string> GetCities() => cities;
    }

}
