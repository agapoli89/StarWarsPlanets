using StarWarsPlanets.Model;

namespace StarWarsPlanets.App
{
    public class StarWarsPlanetsAppBase
    {

        public string GetMinMaxValue(List<PlanetInfo> planets, string validatedProperty)
        {
            Func<PlanetInfo, double?> selector = validatedProperty.ToLower() switch
            {
                "diameter" => p => p.DiameterAsDouble,
                "surface_water" => p => p.SurfaceWaterAsDouble,
                "population" => p => p.PopulationAsDouble,
                _ => throw new ArgumentException("Nieznana właściwość")
            };

            var filteredPlanets = planets
                .Select(p => new { Planet = p.name, Value = selector(p) })
                .Where(x => x.Value.HasValue)
                .ToList();

            if (!filteredPlanets.Any())
            {
                return $"There is no data for {validatedProperty}";
            }

            var minPlanet = filteredPlanets.OrderBy(x => x.Value).First();
            var maxPlanet = filteredPlanets.OrderByDescending(x => x.Value).First();

            return $@"Max {validatedProperty} is {maxPlanet.Value} (planet: {maxPlanet.Planet})
Min {validatedProperty} is {minPlanet.Value} (planet: {minPlanet.Planet})";

        }
    }
}