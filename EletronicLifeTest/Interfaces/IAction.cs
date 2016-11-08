using EletronicLifeTest.Map;

namespace EletronicLifeTest.Interfaces
{
    public interface IAction
    {
        void PerformAction(World world, Vector vector, IActor actor);
    }
}