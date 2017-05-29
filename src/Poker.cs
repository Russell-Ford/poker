namespace PokerSolver
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;
    using PokerSolver.RuleSets;

    public class Poker
    {
        private IList<Hand> PlayerHands { get; } = new List<Hand>();

        private IRuleSet RuleSet { get; }

        public Poker(IRuleSet ruleSet)
        {
            this.RuleSet = ruleSet;
        }

        public void AddPlayerHand(int playerId, IList<string> playerHand)
        {
            this.PlayerHands.Add(new Hand(playerId, playerHand));
        }

        public IList<int> DetermineWinners()
        {
            var winningRank = int.MaxValue;
            var winners = new List<Hand> { };

            foreach (var playerHand in PlayerHands)
            {
                var rank = this.RuleSet.GolfScore(playerHand);

                if (rank < winningRank)
                {
                    winningRank = rank;
                    winners = new List<Hand> { playerHand };
                }
                else if (rank == winningRank)
                {
                    winners.Add(playerHand);
                }
            }

            if (winners.Count > 1)
            {
                winners = 
                    this.RuleSet.BreakTie(winningRank, winners)
                        .ToList();
            }

            return winners.Select(h => h.Id).ToList();
        }
    }
}
