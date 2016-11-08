using EletronicLifeTest.Map;

namespace EletronicLifeTest.Interfaces
{
    public interface IActor
    {
        IAction Act(View view);
    }
}