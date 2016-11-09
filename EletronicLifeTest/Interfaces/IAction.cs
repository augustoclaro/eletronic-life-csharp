using EletronicLifeTest.Map;

namespace EletronicLifeTest.Interfaces
{
    public interface IAction
    {
        bool PerformAction(World world, Vector vector, IActor actor);
    }
}