//using EletronicLifeTest.Actions;
//using EletronicLifeTest.Helpers;
//using EletronicLifeTest.Interfaces;
//using EletronicLifeTest.Map;

//namespace EletronicLifeTest.Critters
//{
//    public class BouncingCritter : Critter, IActor
//    {
//        private Direction _direction = Directions.FromId(Directions.Names.RandOne());

//        public IAction Act(View view)
//        {
//            if (view.Look(_direction) != " ")
//                _direction = view.Find(" ") ?? Directions.S;
//            return new MoveAction(_direction);
//        }
//    }
//}