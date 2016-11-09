using EletronicLifeTest.Actions;
using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;

namespace EletronicLifeTest.Critters
{
    public class PlantEater : Critter, IActor
    {
        public PlantEater() : base(20)
        {
        }

        public IAction Act(View view)
        {
            var space = view.Find(" ");
            if (Energy > 60 && space != null)
                return new ReproduceAction(space);
            var plant = view.Find("*");
            if (plant != null)
                return new EatAction(plant);
            if (space != null)
                return new MoveAction(space);
            return null;
        }
    }
}