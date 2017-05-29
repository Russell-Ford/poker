namespace PokerSolver.RuleProcessors
{
    using PokerSolver.Models;

    public interface IRuleProcessor
    {
        bool ProcessHand(Hand hand);
    }
}
