using StarWarsPlanets.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsPlanets.Validation;

public class UserInputValidator : IUserInputValidator
{
    public string? Validate(string? input)
    {
        switch(input)
        {
            case "population":
                return "population";
            case "diameter":
                return "diameter";
            case "surface water":
                return "surface_water";
            default:
                Console.WriteLine("Invalid input");
                return null;
        }
    }
}
