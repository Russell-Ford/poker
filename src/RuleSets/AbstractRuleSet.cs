namespace PokerSolver.RuleSets
{
    using System.Collections.Generic;

    using PokerSolver.Models;
    using PokerSolver.Rules;

    public abstract class AbstractRuleSet : IRuleSet
    {
        /// <summary>
        ///     Rules that are run until one evaluates to true. Possible score decreases for each rule run.
        /// </summary>
        /// <remarks>
        ///     Rules should be in order of evaluation with winningest first.
        /// </remarks>
        protected IReadOnlyList<IRule> Rules { get; set; }

        public int ScoreHand(Hand hand)
        {
            var potentialScore = 100 * this.Rules.Count;
            for (var i = 0; i < this.Rules.Count; i++)
            {
                if (this.Rules[i].EvaluateRule(hand))
                {
                    return potentialScore;
                }

                potentialScore -= 100;
            }

            // HACK: Hard-coded "high card" rule. If we ever find a version of poker where this isn't
            //       the fallback, we'll need to move it to its own rule.
            foreach (var card in hand.Cards)
            {
                // HACK: Utilizes the underlying nature of rank as an enum. If we reify to a class we
                //       may need to revisit this cast.
                // NOTE: potentialScore should be 0 on the first loop so it will always get replaced.
                if ((int)card.Rank > potentialScore)
                {
                    potentialScore = (int)card.Rank;
                }
            }

            return potentialScore;
        }
    }
}
