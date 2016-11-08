using EletronicLifeTest.Critters;
using EletronicLifeTest.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace EletronicLifeTest.Map
{
    public class View
    {
        private Vector _vector;
        private World _world;

        public View(World world, Vector vector)
        {
            _world = world;
            _vector = vector;
        }

        public IEnumerable<Direction> FindAll(string space)
            => Directions.All.Where(d => Look(d) == space);

        public Direction Find(string space)
        {
            var found = FindAll(space);
            return found.Any() ? found.RandOne() : null;
        }

        public string Look(Direction dir)
        {
            var target = _vector + dir.Vector;
            if (!_world.Grid.HasVector(target)) return "#";
            var obj = _world.Grid[target];
            return obj == null ? " " : ((Critter)obj).Id.ToString();
        }
    }
}