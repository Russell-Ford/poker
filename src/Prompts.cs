namespace PokerSolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PokerSolver.RuleSets;
    using PokerSolver.Models;

    public class Prompts
    {
        public static int GetNumberOfPlayers() {
            Console.WriteLine("Number of players?");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out var numberOfPlayers))
            {
                Console.WriteLine("First line must be number of players");
                throw new ArgumentException("First line must be number of players");
            }
            if(numberOfPlayers <= 0) {
                Console.WriteLine("2 players are required to play.");
                throw new ArgumentException("2 players are required to play.");
            } else if (numberOfPlayers == 1) {
                Console.WriteLine("Playing by yourself is no fun.");
                throw new ArgumentException("Playing by yourself is no fun.");
            } else if (numberOfPlayers >= 18) {
                Console.WriteLine("Not enough cards in one deck for more than 17 players!");
                throw new ArgumentException("Not enough cards for more than 17 players!");
            }

            return numberOfPlayers;
        }

        public static List<Hand> GetHands(int numberOfPlayers) {
            List<Hand> hands = new List<Hand>();

            Console.WriteLine("```");
            Console.WriteLine("input player id's and value of cards:");
            Console.WriteLine("example:");
            Console.WriteLine("0 Qc Kc 4s");
            Console.WriteLine("1 Ah 2c Js");
            Console.WriteLine("2 3h 9h Th");
            Console.WriteLine("```");
            for (var i = 0; i < numberOfPlayers; i++)
            {
                hands.Add(GetHand());
            }

            return hands;
        }

        public static Hand GetHand() {
            var playerInput = Console.ReadLine().Split(' ');

            // HACK: playerHand[0] is hardcoded based on what we know about input.
            //       we always expect id to come first in the split string...
            if (!int.TryParse(playerInput[0], out var playerId))
            {
                throw new ArgumentException("First item in a hand must be the player id");
            }

            var playerCardInput = new List<string>(playerInput.Length - 1); //optimization since we know the eventual list size

            // NOTE: we start at 1 b/c we already processed the first piece of input
            for (var j = 1; j < playerInput.Length; j++)
            {
                playerCardInput.Add(playerInput[j]);
            }
            return new Hand(playerId, playerCardInput);
        }


    }
}