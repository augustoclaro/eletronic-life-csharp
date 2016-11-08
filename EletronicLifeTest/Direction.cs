using EletronicLifeTest.Map;

namespace EletronicLifeTest
{
    public class Direction
    {
        public string Id { get; set; }
        public Vector Vector { get; set; }

        internal Direction(string id, Vector vector = null)
        {
            Id = id;
            Vector = vector ?? Directions.FromId(id)?.Vector;
        }
    }
}