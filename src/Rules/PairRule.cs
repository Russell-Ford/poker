namespace PokerSolver.Rules
{
    using System.Collections.Generic;
    using System.Linq;

    using PokerSolver.Models;    

    public class PairRule : IRule
    {
        public bool EvaluateRule(Hand hand)
        {
            return hand.EvaluateSameKind(2);
        }

        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            var winningPairRank = default(Rank);
            var tieWinners = new List<Hand> { };
            foreach (var hand in hands)
            {
                var pairedRanks = hand.GetRanksOfAKind(2);
                var highPairRank = pairedRanks.OrderByDescending(x => (int)x).First();

                if (highPairRank > winningPairRank)
                {
                    winningPairRank = highPairRank;
                    tieWinners = new List<Hand> { hand };
                }
                else if (highPairRank == winningPairRank)
                {
                    // NOTE: We order by descending b/c we want the _highest_ ranked card in the hand that is not in the pair
                    var nonPairHighCardRank = hand.Cards.OrderByDescending(x => (int)x.Rank).First(x => x.Rank != highPairRank).Rank;
                    var winningHighCardRank = tieWinners[0].Cards.OrderByDescending(x => (int)x.Rank).First(x => x.Rank != highPairRank).Rank;

                    if (nonPairHighCardRank > winningHighCardRank)
                    {
                        winningHighCardRank = nonPairHighCardRank;
                        tieWinners = new List<Hand> { hand };
                    }
                    else if (nonPairHighCardRank == winningHighCardRank)
                    {
                        tieWinners.Add(hand);
                    }                    
                }
            }

            return tieWinners;
        }
    }
}