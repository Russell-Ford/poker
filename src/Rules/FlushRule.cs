namespace PokerSolver.Rules
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;

    public class FlushRule : IRule
    {
        /// <summary>
        ///     The rule whose logic we use for tie-breaking as 3-of-a-kind does not need to supply its own
        /// </summary>
        private IRule TieBreakingRule { get; }

        public FlushRule(IRule tieBreakingRule)
        {
            this.TieBreakingRule = tieBreakingRule;
        }

        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            return this.TieBreakingRule.BreakTie(hands);
        }

        public bool EvaluateRule(Hand hand)
        {
            var suitToCheck = hand.Cards.Select(c => c.Suit).First();
            return hand.Cards.All(c => c.Suit == suitToCheck);
        }
    }
}
