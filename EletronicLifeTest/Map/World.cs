﻿using EletronicLifeTest.Critters;
using EletronicLifeTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public int Turns;

        public void Turn()
        {
            var acted = new List<IActor>();
            for (var y = 0; y < Grid.Height; y++)
                for (var x = 0; x < Grid.Width; x++)
                {
                    var vector = new Vector(x, y);
                    var actor = Grid[vector] as IActor;
                    if (actor != null && !acted.Contains(actor))
                    {
                        acted.Add(actor);
                        LetAct(actor, vector);
                    }
                }
            Turns++;
        }

        public virtual void LetAct(IActor actor, Vector vector)
        {
            //var action = actor.Act(new View(this, vector));
            //if (action != null)
            //    action.PerformAction(this, vector, actor);

            var action = actor.Act(new View(this, vector));
            if (action == null || !action.PerformAction(this, vector, actor))
            {
                var critter = actor as Critter;
                if (critter != null)
                {
                    critter.Energy -= .2m;
                    if (critter.Energy <= 0)
                        Grid[vector] = null;
                }
            }
        }

        public override string ToString()
            => string.Join(Environment.NewLine, 
                Enumerable.Range(0, Grid.Height)
                    .Select(y => string.Join("", 
                        Enumerable.Range(0, Grid.Width)
                            .Select(x => Grid[x, y] == null ? " " : ((Critter)Grid[x, y]).Id.ToString()))));
    }
}