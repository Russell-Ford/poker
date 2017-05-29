namespace PokerSolver.Rules
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;
    using PokerSolver.RuleProcessors;

    public class ProcessorDrivenRule : IRule
    {
        /// <summary>
        ///     The rule whose logic we use for tie-breaking as flush does not need to supply its own
        /// </summary>
        private IRule TieBreakingRule { get; }

        private IList<IRuleProcessor> Processors { get; }

        public ProcessorDrivenRule(IList<IRuleProcessor> processors, IRule tieBreakingRule)
        {
            this.Processors = processors;
            this.TieBreakingRule = tieBreakingRule;
        }

        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            return this.TieBreakingRule.BreakTie(hands);
        }

        public bool EvaluateRule(Hand hand)
        {
            foreach (var processor in this.Processors)
            {
                if (!processor.ProcessHand(hand)) //optimization bail on first false
                {
                    return false;
                }
            }

            return true;
        }
    }
}
