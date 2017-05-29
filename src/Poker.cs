namespace PokerSolver
{
    using System.Collections.Generic;

    using PokerSolver.Models;
    using PokerSolver.RuleSets;

    public class Poker
    {
        private Dictionary<int, Hand> PlayerHands { get; } = new Dictionary<int, Hand>();

        private IRuleSet RuleSet { get; }

        public Poker(IRuleSet ruleSet)
        {
            this.RuleSet = ruleSet;
        }

        public void AddPlayerHand(int playerId, IList<string> playerHand)
        {
            this.PlayerHands.Add(playerId, new Hand(playerHand));
        }

        public IList<int> DetermineWinners()
        {
            var winningScore = 0;
            var winners = new List<int> { };

            foreach (var playerHand in PlayerHands)
            {
                var hand = playerHand.Value;
                var score = this.RuleSet.ScoreHand(hand);

                if (score > winningScore)
                {
                    winningScore = score;
                    winners = new List<int> { playerHand.Key };
                }
                else if (score == winningScore)
                {
                    winners.Add(playerHand.Key);
                }
            }

            return winners;
        }
    }
}
