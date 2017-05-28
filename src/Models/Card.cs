namespace PokerSolver.Models
{
    using System;

    public class Card
    {
        public Rank Rank { get; }

        public Suit Suit { get; }

        public Card(string cardString)
        {
            if (cardString.Length != 2)
            {
                throw new ArgumentException(
                    $"Card inputs must be 2 characters; First character should identify rank, second should identify suit. '{cardString}' is invalid");
            }

            // this switch is ewww; could be replaced if we reified rank to be a class
            switch (cardString[0])
            {
                case '2':
                    this.Rank = Rank.Two;
                    break;
                case '3':
                    this.Rank = Rank.Three;
                    break;
                case '4':
                    this.Rank = Rank.Four;
                    break;
                case '5':
                    this.Rank = Rank.Five;
                    break;
                case '6':
                    this.Rank = Rank.Six;
                    break;
                case '7':
                    this.Rank = Rank.Seven;
                    break;
                case '8':
                    this.Rank = Rank.Eight;
                    break;
                case '9':
                    this.Rank = Rank.Nine;
                    break;
                case 'T':
                    this.Rank = Rank.Ten;
                    break;
                case 'J':
                    this.Rank = Rank.Jack;
                    break;
                case 'Q':
                    this.Rank = Rank.Queen;
                    break;
                case 'K':
                    this.Rank = Rank.King;
                    break;
                case 'A':
                    this.Rank = Rank.Ace;
                    break;
                default:
                    throw new ArgumentException($"First character of card input should identify a rank. '{cardString[0]}' is not valid rank.");
            }

            switch (cardString[1])
            {
                case 'c':
                    this.Suit = Suit.Clubs;
                    break;
                case 'd':
                    this.Suit = Suit.Diamonds;
                    break;
                case 'h':
                    this.Suit = Suit.Hearts;
                    break;
                case 's':
                    this.Suit = Suit.Spades;
                    break;
                default:
                    throw new ArgumentException($"Second character of card input should identify suit. '{cardString[1]}' is not valid rank.");
            }
        }
    }    
}
