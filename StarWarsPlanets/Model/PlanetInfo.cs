using System.Text.Json.Serialization;

namespace StarWarsPlanets.Model;

public record PlanetInfo(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population
)
{
    // pomocnicza właściwość do pracy z liczbą
    public double? DiameterAsDouble =>
        double.TryParse(diameter, out var val) ? val : null;
    public double? PopulationAsDouble =>
        double.TryParse(population, out var val) ? val : null;
    public double? SurfaceWaterAsDouble =>
        double.TryParse(surface_water, out var val) ? val : null;
};
