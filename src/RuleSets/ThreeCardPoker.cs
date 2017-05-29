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
            var sameKindProcessor = new SameKindProcessor();

            // configured rules with DI
            Rules = new List<IRule>
            {
                new ThreeOfAKindRule(sameKindProcessor),
                new PairRule(sameKindProcessor)
            };
        }        
    }
}
