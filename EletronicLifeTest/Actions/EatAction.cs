using EletronicLifeTest.Critters;
using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;

namespace EletronicLifeTest.Actions
{
    public class EatAction : IAction
    {
        public Direction Direction { get; set; }

        public EatAction(Direction direction)
        {
            Direction = direction;
        }

        public bool PerformAction(World world, Vector vector, IActor actor)
        {
            var dest = vector + Direction.Vector;
            var critter = actor as Critter;
            var atDest = world.Grid[dest] as Critter;
            if (critter != null && atDest != null && atDest.Energy != null)
            {
                critter.Energy += atDest.Energy;
                world.Grid[dest] = null;
                return true;
            }
            return false;
        }
    }
}