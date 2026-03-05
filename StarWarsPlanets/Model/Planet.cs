using StarWarsPlanets.DTO;
using StarWarsPlanets.Utilities;
using System.Text.Json.Serialization;

namespace StarWarsPlanets.Model;

public readonly record struct Planet
{
    public Planet(string name, int? diameter, int? surfaceWater, long? population)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public string Name { get; }
    public int? Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population {  get; }

    public static explicit operator Planet(Root root)
    {
        var name = root.name;
        int? diameter = StringExtensions.ToIntOrNull(root.diameter);
        int? surfaceWater = StringExtensions.ToIntOrNull(root.surface_water);
        long? population = StringExtensions.ToLongOrNull(root.population);

        return new Planet(name, diameter, surfaceWater, population);
    }
};
