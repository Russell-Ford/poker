namespace PokerSolver.RuleProcessors
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;

    public class FlushRuleProcessor : IRuleProcessor
    {
        private Dictionary<Hand, bool> ProcessedHandCache { get; } = new Dictionary<Hand, bool>();

        public bool ProcessHand(Hand hand)
        {
            if (!ProcessedHandCache.ContainsKey(hand))
            {
                var result = this.EvaluateFlush(hand);
                ProcessedHandCache.Add(hand, result);
            }

            return ProcessedHandCache[hand];
        }

        private bool EvaluateFlush(Hand hand)
        {
            var suitToCheck = hand.Cards.Select(c => c.Suit).First();
            return hand.Cards.All(c => c.Suit == suitToCheck);
        }
    }
}
