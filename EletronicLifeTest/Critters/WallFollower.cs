using EletronicLifeTest.Actions;
using EletronicLifeTest.Interfaces;
using EletronicLifeTest.Map;

namespace EletronicLifeTest.Critters
{
    public class WallFollower : Critter, IActor
    {
        private Direction _direction = Directions.S;

        public IAction Act(View view)
        {
            var start = _direction;
            if (view.Look(_direction - 3) != " ")
                start = _direction = _direction - 2;
            while (view.Look(_direction) != " ")
            {
                _direction += 1;
                if (_direction == start) break;
            }
            return new MoveAction(_direction);
        }
    }
}