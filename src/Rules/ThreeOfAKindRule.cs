namespace PokerSolver.Rules
{
    using System;
    using System.Collections.Generic;

    using PokerSolver.Models;    

    public class ThreeOfAKindRule : IRule
    {
        /// <summary>
        ///     The rule whose logic we use for tie-breaking as 3-of-a-kind does not need to supply its own
        /// </summary>
        private IRule TieBreakingRule { get; }

        public ThreeOfAKindRule(IRule tieBreakingRule)
        {
            this.TieBreakingRule = tieBreakingRule;
        }

        public bool EvaluateRule(Hand hand)
        {
            return hand.EvaluateSameKind(3);
        }

        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            return this.TieBreakingRule.BreakTie(hands);
        }
    }
}
