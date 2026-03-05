using StarWarsPlanets.Model;

namespace StarWarsPlanets.App
{
    public static class StarWarsPlanetsStatistic
    {
        public static string GetMinMaxValue(IEnumerable<Planet> planets, string validatedProperty)
        {
            Func<Planet, long?> selector = validatedProperty.ToLower() switch
            {
                "diameter" => p => p.Diameter,
                "surface_water" => p => p.SurfaceWater,
                "population" => p => p.Population,
                _ => throw new ArgumentException("There is no such property")
            };

            var filteredPlanets = planets
                .Select(p => new { Planet = p.Name, Value = selector(p) })
                .Where(x => x.Value.HasValue)
                .ToList();

            if (!filteredPlanets.Any())
                return $"There is no data for {validatedProperty}";


            var minPlanet = filteredPlanets
                .Where(x => x.Value > 0)
                .MinBy(x => x.Value);
            var maxPlanet = filteredPlanets
                .MaxBy(x => x.Value);


            return $@"Max {validatedProperty} is {maxPlanet!.Value} (planet: {maxPlanet.Planet})
Min {validatedProperty} is {minPlanet!.Value} (planet: {minPlanet.Planet})";
        }
    }
}