namespace PokerSolver.RuleSets
{
    using System.Collections.Generic;

    using PokerSolver.Rules;

    public class ThreeCardPoker : AbstractRuleSet
    {
        public ThreeCardPoker()
        {
            // configured rules with DI
            Rules = new List<IRule>
            {
                new ThreeOfAKindRule(),
                new PairRule(),
                new HighCardRule()
            };
        }        
    }
}
