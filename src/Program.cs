namespace PokerSolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PokerSolver.RuleSets;

    public class Program
    {
        private static void Main()
        {
            try
            {
                // dependencies
                var threeCardRuleSet = new ThreeCardPoker();

                // injection
                var poker = new Poker(threeCardRuleSet);

                int numPlayers = Prompts.GetNumberOfPlayers();
                poker.AddPlayerHands(Prompts.GetHands(numPlayers));

                var winners = poker.DetermineWinners().OrderBy(i => i); // required to sort ties in ascending order

                Console.WriteLine("```");

                var output = string.Join(" ", winners); //optimization - let JITer decide if we need a string builder
                Console.WriteLine(output);

                Console.WriteLine("```");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}