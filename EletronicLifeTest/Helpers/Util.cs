using System;
using System.Collections.Generic;

namespace EletronicLifeTest.Helpers
{
    public static class Util
    {
        private static Random _rand = new Random();
        private static Dictionary<Type, int> _list = new Dictionary<Type, int>();

        public static int Random(int min, int max)
            => _rand.Next(min, max + 1);

        public static void Repro(Type t)
        {
            if (!_list.ContainsKey(t))
                _list.Add(t, 0);
            _list[t]++;
        }
    }
}