namespace PokerSolver.Rules
{
    using PokerSolver.Models;
    using PokerSolver.RuleProcessors.Interfaces;

    public class ThreeOfAKindRule : IRule
    {
        private ISameKindProcessor SameKindProcessor { get; }

        public ThreeOfAKindRule(ISameKindProcessor sameKindProcessor)
        {
            this.SameKindProcessor = sameKindProcessor;
        }

        public bool EvaluateRule(Hand hand)
        {
            return this.SameKindProcessor.EvaluateSameKind(hand, 3);
        }
    }
}
