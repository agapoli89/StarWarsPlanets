using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsPlanets.UserInteractions;

public class ConsoleUI : IUI
{
    public string GetData()
    {
        return Console.ReadLine();
    }

    public void PrintPlanets(List<PlanetInfo> planets)
    {
        Console.WriteLine($"{"Name".PadRight(15)} | {"Diameter".PadRight(15)} | {"SurfaceWater".PadRight(15)} | {"Population".PadRight(15)}");
        Console.WriteLine(new string('-', 70));
        foreach (var planet in planets)
        {
            Console.WriteLine(
                $"{planet.name.PadRight(15)} | {planet.diameter.PadRight(15)} | {planet.surface_water.PadRight(15)} | {planet.population.PadRight(15)}");
        }
    }
    public void PrintQuestion() => Console.WriteLine($@"The statistics of which property would you like to see?
population
diameter
surface water
");
}
