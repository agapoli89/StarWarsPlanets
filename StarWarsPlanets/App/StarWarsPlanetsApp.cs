using StarWarsPlanets.DataAccess;
using StarWarsPlanets.DTO;
using StarWarsPlanets.UserInteractions;
using StarWarsPlanets.Validation;

namespace StarWarsPlanets.App;

public class StarWarsPlanetsApp(IUserInputValidator userInputValidator, IUI ui, IPlanetReader dataReader)
{
    private readonly IUserInputValidator _userInputValidator = userInputValidator;
    private readonly IUI _ui = ui;
    private readonly IPlanetReader _dataReader = dataReader;

    public async void Run()
    {
        var planets = _dataReader.DeserializeData().GetAwaiter().GetResult();

        ConsoleTablePrinter.PrintTable(planets);
        _ui.PrintQuestion();
        var validatedProperty = _userInputValidator.Validate(_ui.GetData());
        if (validatedProperty != null)
        {
            var message = StarWarsPlanetsStatistic.GetMinMaxValue(planets, validatedProperty);
            _ui.PrintMessage(message);
        }
        _ui.ExitApp();
    }
}