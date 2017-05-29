namespace PokerSolver.RuleSets
{
    using System;
    using System.Collections.Generic;

    using PokerSolver.Models;
    using PokerSolver.Rules;

    public abstract class AbstractRuleSet : IRuleSet
    {
        /// <summary>
        ///     Rules that are run until one evaluates to true which determines how the hand is ranked.
        /// </summary>
        /// <remarks>
        ///     Rules should be in order of evaluation with winningest first.
        /// </remarks>
        protected IReadOnlyList<IRule> Rules { get; set; }

        /// <summary>
        ///     Breaks ties between hands which match the same judging rule.
        /// </summary>
        /// <param name="winningRuleRank">The rank of rule that the winners matched.</param>
        /// <param name="tiedHands">The hands which were tied for the win.</param>
        /// <returns>A list of hand(s) which won the tie-breaker.</returns>
        public IList<Hand> BreakTie(int winningRuleRank, IList<Hand> tiedHands)
        {
            var rule = Rules[winningRuleRank];
            return rule.BreakTie(tiedHands);
        }

        /// <summary>
        ///     Ranks a hand against the current rules in the rule set.
        /// </summary>
        /// <param name="hand">The hand to rank.</param>
        /// <returns>The index of the matching rule which is also the rule's rank against others in terms of how winning it is.</returns>
        public int GolfScore(Hand hand)
        {
            for (var i = 0; i < this.Rules.Count; i++)
            {
                if (this.Rules[i].EvaluateRule(hand))
                {
                    return i;
                }                
            }

            throw new Exception("RuleSet does not cover all possible hands");
        }
    }
}
