using EletronicLifeTest.Critters;
using EletronicLifeTest.Helpers;
using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;
using System;

namespace EletronicLifeTest.Actions
{
    public class ReproduceAction : IAction
    {
        public Direction Direction { get; set; }

        public ReproduceAction(Direction direction)
        {
            Direction = direction;
        }

        public bool PerformAction(World world, Vector vector, IActor actor)
        {
            Util.Repro(actor.GetType());
            var critter = actor as Critter;
            var baby = Activator.CreateInstance(actor.GetType()) as Critter;
            baby.Id = critter.Id;
            var dest = vector + Direction.Vector;
            if (baby != null && critter != null && world.Grid.HasVector(dest) && world.Grid[dest] == null && critter.Energy > 2 * baby.Energy)
            {
                critter.Energy -= 2 * baby.Energy;
                world.Grid[dest] = baby;
                return true;
            }
            return false;
        }
    }
}