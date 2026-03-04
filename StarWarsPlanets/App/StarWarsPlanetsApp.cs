using StarWarsPlanets.API;
using StarWarsPlanets.Model;
using StarWarsPlanets.UserInteractions;
using StarWarsPlanets.Validation;

namespace StarWarsPlanets.App;

public class StarWarsPlanetsApp : StarWarsPlanetsAppBase
{
    private readonly IUserInputValidator _userInputValidator;
    private readonly IUI _ui;
    private readonly IDataReader _dataReader;

    public StarWarsPlanetsApp(IUserInputValidator userInputValidator, IUI ui, IDataReader dataReader)
    {
        _userInputValidator = userInputValidator;
        _ui = ui;
        _dataReader = dataReader;
    }

    public async void Run()
    {
        var planets = _dataReader.GetPlanets().GetAwaiter().GetResult();

        ConsoleTablePrinter.PrintTable(planets);
        _ui.PrintQuestion();
        var validatedProperty = _userInputValidator.Validate(_ui.GetData());
        if (validatedProperty != null)
        {
            var message = GetMinMaxValue(planets, validatedProperty);
            _ui.PrintMessage(message);
        }
        _ui.ExitApp();
    }
}