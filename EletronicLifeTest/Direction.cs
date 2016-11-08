using EletronicLifeTest.Map;
using System.Linq;

namespace EletronicLifeTest
{
    public class Direction
    {
        public string Id { get; set; }
        public Vector Vector { get; set; }

        public Direction(string id, Vector vector = null)
        {
            Id = id;
            Vector = vector ?? Directions.FromId(id)?.Vector;
        }

        private static Direction SumDirWithNumber(Direction dir, int n)
        {
            var index = Directions.All.Select(d => d.Id).ToList().IndexOf(dir.Id);
            return Directions.All.ElementAt((index + n + Directions.Map.Count) % Directions.Map.Count);
        }

        public static Direction operator +(Direction dir, int n)
            => SumDirWithNumber(dir, n);

        public static Direction operator -(Direction dir, int n)
            => SumDirWithNumber(dir, n * -1);

        public override bool Equals(object obj)
            => (obj as Direction)?.Id == Id;
    }
}