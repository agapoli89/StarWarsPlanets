using StarWarsPlanets.API;
using StarWarsPlanets.UserInteractions;

namespace StarWarsPlanets.App;

public class StarWarsPlanetsApp
{
    private readonly IUI _ui = new ConsoleUI();
    public async void Run(DataReader reader)
    {
        var planets = await reader.GetPlanets();

        _ui.PrintPlanets(planets);
        _ui.PrintQuestion();
        var propertyToCheck = _ui.GetData();
    }
}