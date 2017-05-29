namespace PokerSolver.Rules
{
    using PokerSolver.Models;
    using PokerSolver.RuleProcessors.Interfaces;

    public class PairRule : IRule
    {
        private ISameKindProcessor SameKindProcessor { get; }

        public PairRule(ISameKindProcessor sameKindProcessor)
        {
            this.SameKindProcessor = sameKindProcessor;
        }

        public bool EvaluateRule(Hand hand)
        {
            return this.SameKindProcessor.EvaluateSameKind(hand, 2);
        }
    }
}