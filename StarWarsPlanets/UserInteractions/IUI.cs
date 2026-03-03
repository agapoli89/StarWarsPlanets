namespace StarWarsPlanets.UserInteractions
{
    public interface IUI
    {
        string GetData();
        void PrintPlanets(List<PlanetInfo> planets);
        void PrintQuestion();
    }
}