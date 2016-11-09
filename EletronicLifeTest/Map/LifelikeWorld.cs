//using EletronicLifeTest.Critters;
//using EletronicLifeTest.Interfaces;
//using System;
//using System.Collections.Generic;

//namespace EletronicLifeTest.Map
//{
//    public class LifelikeWorld : World
//    {
//        public LifelikeWorld(string[] map, Dictionary<char, Type> legend)
//            : base(map, legend)
//        {
//        }

//        public override void LetAct(IActor actor, Vector vector)
//        {
//            var action = actor.Act(new View(this, vector));
//            if (action == null || !action.PerformAction(this, vector, actor))
//            {
//                var critter = actor as Critter;
//                if (critter != null)
//                {
//                    critter.Energy -= .2m;
//                    if (critter.Energy <= 0)
//                        Grid[vector] = null;
//                }
//            }
//        }
//    }
//}