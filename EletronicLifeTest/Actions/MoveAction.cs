﻿using EletronicLifeTest.Critters;
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

        public bool PerformAction(World world, Vector vector, IActor actor)
        {
            var dest = vector + Direction.Vector;
            var critter = actor as Critter;
            if (critter != null && world.Grid.HasVector(dest) && world.Grid[dest] == null && critter.Energy > 1)
            {
                critter.Energy--;
                world.Grid[vector] = null;
                world.Grid[dest] = actor;
                return true;
            }
            return false;
        }
    }
}