using StarWarsPlanets.Model;

namespace StarWarsPlanets.UserInteractions
{
    public interface IUI
    {
        void ExitApp();
        string GetData();
        void PrintMessage(string message);
        void PrintQuestion();
    }
}