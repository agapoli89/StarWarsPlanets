using System.Text.Json;

namespace StarWarsPlanets.API
{
    public class DataReader
    {
        private readonly IApiDataReader _apiDataReader;

        public DataReader()
        {
            _apiDataReader = new ApiDataReader();
        }

        public async Task<List<PlanetInfo>> GetPlanets()
        {
            var baseAddress = "https://swapi.info/api/";
            var requestUri = "planets";

            //IApiDataReader apiDataReader = new ApiDataReader();
            var json = await _apiDataReader.Read(baseAddress, requestUri);

            var planets = JsonSerializer.Deserialize<List<PlanetInfo>>(json);
            return planets ?? new List<PlanetInfo>();
        }
    }
}