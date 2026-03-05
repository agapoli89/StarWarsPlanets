using System.Text.Json;
using StarWarsPlanets.API;
using StarWarsPlanets.DTO;
using StarWarsPlanets.Model;

namespace StarWarsPlanets.DataAccess
{
    public class PlanetReader : IPlanetReader
    {
        private readonly IApiDataReader _apiDataReader;

        public PlanetReader()
        {
            _apiDataReader = new ApiDataReader();
        }

        public async Task<IEnumerable<Planet>> DeserializeData()
        {
            var baseAddress = "https://swapi.info/api/";
            var requestUri = "planets";

            //IApiDataReader apiDataReader = new ApiDataReader();
            var json = await _apiDataReader.Read(baseAddress, requestUri);

            var roots = JsonSerializer.Deserialize<List<Root>>(json);

            var planets = ToPlanets(roots);
            return planets ?? [];
        }

        private static IEnumerable<Planet> ToPlanets(List<Root>? roots)
        {
            if (roots == null || roots.Count == 0) throw new ArgumentNullException(nameof(roots));

            return roots.Select(root => (Planet)root);
        }
    }
}