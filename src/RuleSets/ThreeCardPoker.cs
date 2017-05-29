namespace PokerSolver.RuleSets
{
    using System.Collections.Generic;

    using PokerSolver.RuleProcessors;
    using PokerSolver.Rules;

    public class ThreeCardPoker : AbstractRuleSet
    {
        public ThreeCardPoker()
        {
            // dependencies
            var straightProcessor = new StraightRuleProcessor();
            var flushProcessor = new FlushRuleProcessor();
            var highCardRule = new HighCardRule();

            // configured rules with DI
            Rules = new List<IRule>
            {
                new ProcessorDrivenRule(new IRuleProcessor[] { straightProcessor, flushProcessor }, highCardRule), // straight-flush rule
                new ThreeOfAKindRule(highCardRule),
                new ProcessorDrivenRule(new[] { straightProcessor }, highCardRule), // straight rule
                new ProcessorDrivenRule(new[] { flushProcessor }, highCardRule), // flush rule
                new PairRule(),
                highCardRule
            };
        }        
    }
}
