using System.Collections.Generic;
using System.Linq;

using PokerSolver.Models;

namespace PokerSolver.Rules
{
    public class HighCardRule : IRule
    {
        public IList<Hand> BreakTie(IList<Hand> hands)
        {
            var tieWinners = new List<Hand>();
            foreach (var hand in hands)
            {
                var orderedCards = hand.Cards.OrderByDescending(x => (int)x.Rank).Select(x => x.Rank).ToList();

                if (!tieWinners.Any())
                {
                    tieWinners = new List<Hand> { hand };
                }
                else
                {
                    // even if there is more than one they have to be equal so we can just compare to one
                    var orderedWinnerCards = tieWinners[0].Cards.OrderByDescending(x => (int)x.Rank).Select(x => x.Rank).ToList(); 

                    for (var i = 0; i < orderedCards.Count; i++)
                    {
                        if (orderedCards[i] > orderedWinnerCards[i])
                        {
                            tieWinners = new List<Hand> { hand };
                        }
                        else if (orderedCards[i] == orderedWinnerCards[i])
                        {
                            // :puke:
                            if (i == orderedCards.Count - 1)
                            {
                                tieWinners.Add(hand);
                            }

                            continue;
                        }
                        else if (orderedCards[i] < orderedWinnerCards[i])
                        {
                            break;
                        }
                    }
                }   
            }

            return tieWinners;
        }

        public bool EvaluateRule(Hand hand)
        {
            // we can always evaluate a hand as a "high card" hand
            return true;
        }
    }
}
