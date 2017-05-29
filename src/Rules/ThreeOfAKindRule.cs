namespace PokerSolver.Rules
{
    using System;
    using System.Collections.Generic;

    using PokerSolver.Models;    

    public class ThreeOfAKindRule : IRule
    {
        public bool EvaluateRule(Hand hand)
        {
            return hand.EvaluateSameKind(3);
        }

        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
