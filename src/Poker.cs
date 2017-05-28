namespace PokerSolver
{
    using System;
    using System.Collections.Generic;

    using PokerSolver.Models;

    public class Poker
    {
        private Dictionary<int, Hand> PlayerHands { get; } = new Dictionary<int, Hand>();

        public void AddPlayerHand(int playerId, IList<string> playerHand)
        {
            this.PlayerHands.Add(playerId, new Hand(playerHand));
        }

        public IList<int> DetermineWinners()
        {
            // need to implement the rules probably with a irule pattern for genericness

            throw new NotImplementedException();
        }
    }
}
