using System;

namespace EletronicLifeTest.Map
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private object[] _space;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            _space = new object[width * height];
        }

        public bool HasVector(Vector vector)
            => vector.X >= 0 && vector.X < Width
            && vector.Y >= 0 && vector.Y < Height;

        public object this[int x, int y]
        {
            get
            {
                return _space[x + Width * y];
            }
            set
            {
                _space[x + Width * y] = value;
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