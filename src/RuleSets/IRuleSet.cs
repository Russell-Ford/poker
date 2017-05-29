namespace PokerSolver.RuleSets
{
    using System.Collections.Generic;
    using PokerSolver.Models;

    public interface IRuleSet
    {
        /// <summary>
        ///     Ranks a hand against the current rules in the rule set.
        /// </summary>
        /// <param name="hand">The hand to evaluate.</param>
        /// <returns>The rank of the rule compared to other rules which the hand matched. Lower is better.</returns>
        int GolfScore(Hand hand);

        /// <summary>
        ///     Breaks ties between hands which match the same judging rule.
        /// </summary>
        /// <param name="winningRuleRank">The rank of rule that the winners matched. IE First rule, second rule, etc.</param>
        /// <param name="tiedHands">The hands which were tied for the win.</param>
        /// <returns>A list of hand(s) which won the tie-breaker.</returns>
        IList<Hand> BreakTie(int winningRuleRank, IList<Hand> tiedHands);
    }
}
