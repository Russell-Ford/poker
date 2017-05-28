namespace PokerSolver.Models
{
    using System.Collections.Generic;

    public class Hand
    {
        public IList<Card> Cards { get; } = new List<Card>();

        public Hand(IList<string> cardStrings)
        {
            foreach (var cardString in cardStrings)
            {
                Cards.Add(new Card(cardString));
            }
        }
    }
}
