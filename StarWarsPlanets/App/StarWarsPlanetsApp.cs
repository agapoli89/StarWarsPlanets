using StarWarsPlanets.DataAccess;
using StarWarsPlanets.UserInteractions;
using StarWarsPlanets.Validation;

namespace StarWarsPlanets.App;

public class StarWarsPlanetsApp(IUserInputValidator userInputValidator, IUI ui, IPlanetReader dataReader)
{
    private readonly IUserInputValidator _userInputValidator = userInputValidator;
    private readonly IUI _ui = ui;
    private readonly IPlanetReader _dataReader = dataReader;

    public async Task Run()
    {
        var planets = await _dataReader.DeserializeData();
      
        ConsoleTablePrinter.PrintTable(planets);
        _ui.PrintQuestion();
        var statisticField = _userInputValidator.Validate(_ui.GetData());
        if (statisticField != null)
        {
            var message = StarWarsPlanetsStatistic.GetMinMaxValue(planets, statisticField);
            _ui.PrintMessage(message);
        }
        _ui.ExitApp();
    }
}