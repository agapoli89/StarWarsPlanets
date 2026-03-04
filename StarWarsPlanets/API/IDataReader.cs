using StarWarsPlanets.Model;

namespace StarWarsPlanets.API
{
    public interface IDataReader
    {
        Task<List<PlanetInfo>> GetPlanets();
    }
}