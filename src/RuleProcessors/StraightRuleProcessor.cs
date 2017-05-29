namespace PokerSolver.RuleProcessors
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;

    public class StraightRuleProcessor : IRuleProcessor
    {
        private Dictionary<Hand, bool> ProcessedHandCache { get; } = new Dictionary<Hand, bool>();

        public bool ProcessHand(Hand hand)
        {
            if (!ProcessedHandCache.ContainsKey(hand))
            {
                var result = this.EvaluateStraight(hand);
                ProcessedHandCache.Add(hand, result);
            }

            return ProcessedHandCache[hand];
        }

        private bool EvaluateStraight(Hand hand)
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
