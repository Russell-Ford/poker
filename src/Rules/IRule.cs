namespace PokerSolver.Rules
{
    using PokerSolver.Models;

    public interface IRule
    {
        bool EvaluateRule(Hand hand);
    }
}
