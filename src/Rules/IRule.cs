namespace PokerSolver.Rules
{
    using System.Collections.Generic;

    using PokerSolver.Models;

    public interface IRule
    {
        bool EvaluateRule(Hand hand);

        IList<Hand> BreakTie(IList<Hand> hands);
    }
}
