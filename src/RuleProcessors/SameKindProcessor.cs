namespace PokerSolver.RuleProcessors
{
    using System.Collections.Generic;

    using PokerSolver.Models;
    using PokerSolver.RuleProcessors.Interfaces;

    /// <summary>
    ///     Dependents can make use of built in caching if the share the same instance to evaluate a single hand.
    /// </summary>
    public class SameKindProcessor : ISameKindProcessor
    {
        private Dictionary<Rank, int> RanksOfAKind { get; set; }

        private Hand CachedHandResults { get; set; }

        /// <summary>
        ///     Evaluates whether a particular hand has some number of a kind.
        /// </summary>
        /// <param name="numberOfKind">The number of a kind to check a hand for. IE 3 would check a hand for 3 cards of the same rank.</param>
        /// <param name="hand">The hand to check.</param>
        /// <remarks>
        ///     Documentation from interface
        /// </remarks>        
        public bool EvaluateSameKind(Hand hand, int numberOfKind)
        {
            if (CachedHandResults != hand)
            {
                RanksOfAKind = new Dictionary<Rank, int>();
                this.EvaluateRanksInHand(hand);
            }

            return RanksOfAKind.ContainsValue(numberOfKind);
        }

        private void EvaluateRanksInHand(Hand hand)
        {
            var numCardsInHand = hand.Cards.Count;
            var skippableIndexes = new List<int>(numCardsInHand); //optimization as list will never be bigger than numCardsInHand
            for (var i = 0; i < numCardsInHand; i++)
            {
                // NOTE: this may be a premature optimization as hand sizes in poker are often
                //       very small. as such this check may be more expensive than simple
                //       brute force w/o dynamic programming
                if (skippableIndexes.Contains(i))
                {
                    continue;
                }

                var sameRankCount = 1; // b/c a card is always equal to itself
                var rankToCheck = hand.Cards[i].Rank;
                for (var j = 0; j < numCardsInHand; j++)
                {
                    // we shouldn't check a card's rank against itself
                    if (j == i)
                    {
                        continue;
                    }

                    if (hand.Cards[j].Rank == rankToCheck)
                    {
                        sameRankCount++;
                        skippableIndexes.Add(j);
                    }
                }

                if (sameRankCount > 1 && !this.RanksOfAKind.ContainsKey(rankToCheck))
                {
                    this.RanksOfAKind.Add(rankToCheck, sameRankCount);
                }
            }
        }
    }
}
