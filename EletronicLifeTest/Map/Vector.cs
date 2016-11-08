namespace EletronicLifeTest.Map
{
    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector vector, Vector vector2)
            => new Vector(vector.X + vector2.X, vector.Y + vector2.Y);
    }
}