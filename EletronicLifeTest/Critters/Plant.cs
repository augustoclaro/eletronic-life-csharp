using EletronicLifeTest.Actions;
using EletronicLifeTest.Helpers;
using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;

namespace EletronicLifeTest.Critters
{
    public class Plant : Critter, IActor
    {
        public Plant() : base(Util.Random(3, 7))
        {
        }

        public IAction Act(View view)
        {
            if (Energy > 15)
            {
                var space = view.Find(" ");
                if (space != null)
                    return new ReproduceAction(space);
            }
            if (Energy < 20)
                return new GrowAction();
            return null;
        }
    }
}