namespace PokerSolver.RuleSets
{
    using System.Collections.Generic;

    using PokerSolver.Rules;

    public class ThreeCardPoker : AbstractRuleSet
    {
        public ThreeCardPoker()
        {
            // dependencies
            var highCardRule = new HighCardRule();

            // configured rules with DI
            Rules = new List<IRule>
            {
                new ThreeOfAKindRule(highCardRule),
                new PairRule(),
                highCardRule
            };
        }        
    }
}
