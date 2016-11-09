using EletronicLifeTest.Critters;
using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;

namespace EletronicLifeTest.Actions
{
    public class GrowAction : IAction
    {
        public bool PerformAction(World world, Vector vector, IActor actor)
        {
            var critter = actor as Critter;
            if (critter != null)
                critter.Energy += .5m;
            return true;
        }
    }
}