using EletronicLifeTest.Map;
using System.Collections.Generic;
using System.Linq;

namespace EletronicLifeTest
{
    public static class Directions
    {
        private static IDictionary<string, Vector> _map = new Dictionary<string, Vector>
        {
            ["N"] = new Vector(0, -1),
            ["NE"] = new Vector(1, -1),
            ["E"] = new Vector(1, 0),
            ["SE"] = new Vector(1, 1),
            ["S"] = new Vector(0, 1),
            ["SW"] = new Vector(-1, 1),
            ["W"] = new Vector(-1, 0),
            ["NW"] = new Vector(-1, -1)
        };

        public static IEnumerable<string> Names => _map.Keys;
        public static Direction N => new Direction("N");
        public static Direction NE => new Direction("NE");
        public static Direction E => new Direction("E");
        public static Direction SE => new Direction("SE");
        public static Direction S => new Direction("S");
        public static Direction SW => new Direction("SW");
        public static Direction W => new Direction("W");
        public static Direction NW => new Direction("NW");

        public static Direction FromId(string id)
            => _map.ContainsKey(id) ? new Direction(id, _map[id]) : null;

        public static IEnumerable<Direction> All
            => _map.Select(kv => FromId(kv.Key));
    }
}