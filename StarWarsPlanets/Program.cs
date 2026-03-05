using StarWarsPlanets.API;
using StarWarsPlanets.App;
using StarWarsPlanets.DataAccess;
using StarWarsPlanets.UserInteractions;
using StarWarsPlanets.Validation;

var app = new StarWarsPlanetsApp(new UserInputValidator(), new ConsoleUI(), new PlanetReader());

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application experienced an unexpected error and will have to be closed.");
    Console.WriteLine(ex.Message);
    Console.WriteLine("Press any key to close");
}

