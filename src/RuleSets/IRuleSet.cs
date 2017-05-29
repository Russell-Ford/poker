namespace PokerSolver.RuleSets
{
    using PokerSolver.Models;

    public interface IRuleSet
    {
        int ScoreHand(Hand hand);
    }
}
