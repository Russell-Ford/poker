namespace PokerSolver.Rules
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;


    public class StraightRule : IRule
    {
        /// <summary>
        ///     The rule whose logic we use for tie-breaking as straight rule does not need to supply its own
        /// </summary>
        private IRule TieBreakingRule { get; }

        public StraightRule(IRule tieBreakingRule)
        {
            this.TieBreakingRule = tieBreakingRule;
        }

        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            return this.TieBreakingRule.BreakTie(hands);
        }

        public bool EvaluateRule(Hand hand)
        {
            var orderedRanks = hand.Cards.Select(c => c.Rank).OrderBy(r => r).ToArray();

            var isStraight = true; //assume straight

            // look-behind algo checking
            for (var i = 1; i < orderedRanks.Count(); i++)
            {
                if (orderedRanks[i] - 1 != orderedRanks[i - 1]) //real-world optimization, straights are rarer than not-straights
                {
                    isStraight = false;
                    break;
                }
            }

            return isStraight;
        }
    }
}
