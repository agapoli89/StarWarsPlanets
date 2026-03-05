using System;
using System.Collections.Generic;
using System.Text;
using StarWarsPlanets.DTO;

namespace StarWarsPlanets.UserInteractions;

public class ConsoleUI : IUI
{
    public void ExitApp()
    {
        PrintMessage("Press any key to close");
        Console.ReadKey();
    }

    public string GetData()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input;  
            }
            Console.WriteLine("Invalid input");
        };
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

  
    public void PrintQuestion() => Console.WriteLine($@"The statistics of which property would you like to see?
population
diameter
surface water
");
}
