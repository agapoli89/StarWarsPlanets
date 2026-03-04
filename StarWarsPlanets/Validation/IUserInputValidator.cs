using StarWarsPlanets.Model;

namespace StarWarsPlanets.Validation
{
    public interface IUserInputValidator
    {
        string Validate(string input);
    }
}