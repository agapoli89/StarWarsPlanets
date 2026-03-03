using StarWarsPlanets.API;
using StarWarsPlanets.App;

var app = new StarWarsPlanetsApp();
var reader = new DataReader();

try
{
    app.Run(reader);
}
catch (Exception ex)
{
    Console.WriteLine("Error");
}


Console.ReadKey();
