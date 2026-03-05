using StarWarsPlanets.Model;

namespace StarWarsPlanets.DataAccess
{
    public interface IPlanetReader
    {
        Task<IEnumerable<Planet>> DeserializeData();
    }
}