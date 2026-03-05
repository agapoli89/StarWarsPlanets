using StarWarsPlanets.DTO;

namespace StarWarsPlanets.Validation
{
    public interface IUserInputValidator
    {
        string? Validate(string? input);
    }
}