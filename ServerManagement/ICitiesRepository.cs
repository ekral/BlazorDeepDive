
using ServerManagement.Models;

namespace ServerManagement
{
    public interface ICitiesRepository
    {
        List<City> GetCities();
    }
}