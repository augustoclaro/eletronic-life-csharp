using System;
using System.Linq;

namespace EletronicLifeTest.Map
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public object[] Space { get; set; }
        public int NullCount => Space.Count(o => o == null);
        public int NotNullCount => Space.Count(o => o != null);

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Space = new object[width * height];
        }

        public bool HasVector(Vector vector)
            => vector.X >= 0 && vector.X < Width
            && vector.Y >= 0 && vector.Y < Height;

        public object this[int x, int y]
        {
            get
            {
                return Space[x + Width * y];
            }
            set
            {
                Space[x + Width * y] = value;
            }
        }

        public object this[Vector vector]
        {
            get
            {
                return this[vector.X, vector.Y];
            }
            set
            {
                this[vector.X, vector.Y] = value;
            }
        }

        public void ForEachSpace(Action<Vector, object> action)
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    action(new Vector(x, y), this[x, y]);
        }
    }
}