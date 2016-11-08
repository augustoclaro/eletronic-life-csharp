using System;
using System.Collections.Generic;
using System.Linq;

namespace EletronicLifeTest.Helpers
{
    public static class Extensions
    {
        private static Random _rand = new Random();

        public static T RandOne<T>(this IEnumerable<T> enumerable)
        {
            var count = enumerable.Count();
            return count == 0 ? default(T) : enumerable.ElementAt(_rand.Next(count));
        }
    }
}