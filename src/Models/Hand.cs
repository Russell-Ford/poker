namespace PokerSolver.Models
{
    using System.Collections.Generic;

    using System.Linq;

    public class Hand
    {
        private bool _ranksOfAKindEvaluated = false;

        private IList<(Rank rank, int numberOfOccurances)> RanksOfAKind { get; set; } = new List<(Rank, int)>();

        public int Id { get; }

        public IList<Card> Cards { get; } = new List<Card>();

        public Hand(int id, IList<string> cardStrings)
        {
            this.Id = id;

            foreach (var cardString in cardStrings)
            {
                Cards.Add(new Card(cardString));
            }
        }

        public IList<Rank> GetRanksOfAKind(int numberOfKind)
        {
            if (!this._ranksOfAKindEvaluated)
            {
                this.EvaluateRanksInHand();
            }

            return this.RanksOfAKind
                .Where(x => x.numberOfOccurances == numberOfKind)
                .Select(x => x.rank)
                .ToList();
        }

        /// <summary>
        ///     Evaluates whether this hand has some number of a kind.
        /// </summary>
        /// <param name="numberOfKind">The number of a kind to check a hand for. IE 3 would check a hand for 3 cards of the same rank.</param>
        public bool EvaluateSameKind(int numberOfKind)
        {
            if (!this._ranksOfAKindEvaluated)
            {
                this.EvaluateRanksInHand();
                this._ranksOfAKindEvaluated = true;
            }

            return this.RanksOfAKind.Any(x => x.numberOfOccurances == numberOfKind);
        }

        private void EvaluateRanksInHand()
        {
            var numCardsInHand = this.Cards.Count;
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
                var rankToCheck = this.Cards[i].Rank;
                for (var j = 0; j < numCardsInHand; j++)
                {
                    // we shouldn't check a card's rank against itself
                    if (j == i)
                    {
                        continue;
                    }

                    if (this.Cards[j].Rank == rankToCheck)
                    {
                        sameRankCount++;
                        skippableIndexes.Add(j);
                    }
                }

                if (sameRankCount > 1 && !this.RanksOfAKind.Any(x => x.rank == rankToCheck))
                {
                    this.RanksOfAKind.Add((rankToCheck, sameRankCount));
                }
            }
        }        
    }
}
