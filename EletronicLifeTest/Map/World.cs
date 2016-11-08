using EletronicLifeTest.Critters;
using EletronicLifeTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EletronicLifeTest.Map
{
    public class World
    {
        public Grid Grid { get; set; }
        private IDictionary<char, Type> _legend;

        public World(string[] map, Dictionary<char, Type> legend)
        {
            Grid = new Grid(map[0].Length, map.Length);
            _legend = legend;
            for (int y = 0; y < map.Length; y++)
            {
                var line = map[y];
                for (int x = 0; x < line.Length; x++)
                {
                    Type t;
                    if (legend.TryGetValue(line[x], out t))
                    {
                        var critter = Activator.CreateInstance(t);
                        ((Critter)critter).Id = line[x];
                        Grid[x, y] = critter;
                    }
                }
            }
        }

        public void Turn()
        {
            var acted = new List<IActor>();
            Grid.ForEachSpace((vector, obj) =>
            {
                var actor = obj as IActor;
                if (actor != null && !acted.Contains(actor))
                {
                    acted.Add(actor);
                    var action = actor.Act(new View(this, vector));
                    if (action != null)
                        action.PerformAction(this, vector, actor);
                }
            });
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int lastY = 0;
            Grid.ForEachSpace((vector, obj) =>
            {
                if (vector.Y != lastY)
                {
                    lastY = vector.Y;
                    sb.Append(Environment.NewLine);
                }
                sb.Append(obj == null ? ' ' : ((Critter)obj).Id);
            });
            return sb.ToString();
        }
    }
}