using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;

namespace EletronicLifeTest.Actions
{
    public class MoveAction : IAction
    {
        public Direction Direction { get; set; }

        public MoveAction(Direction direction)
        {
            Direction = direction;
        }

        public void PerformAction(World world, Vector vector, IActor actor)
        {
            var dest = vector + Direction.Vector;
            if (world.Grid.HasVector(dest) && world.Grid[dest] == null)
            {
                world.Grid[vector] = null;
                world.Grid[dest] = actor;
            }
        }
    }
}