namespace EletronicLifeTest.Critters
{
    public abstract class Critter
    {
        public char Id { get; set; }
        public decimal? Energy { get; set; }

        public Critter(decimal? energy)
        {
            Energy = energy;
        }
    }
}