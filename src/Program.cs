namespace PokerSolver
{
    using System;
    using System.Collections.Generic;    

    public class Program
    {
        private static void Main()
        {
            try
            {
                var poker = new Poker();

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var numberOfPlayers))
                {
                    throw new ArgumentException("First line must be number of players");
                }

                for (var i = 0; i < numberOfPlayers; i++)
                {
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

                    poker.AddPlayerHand(playerId, playerCardInput);
                }

                var winners = poker.DetermineWinners();                
                var output = string.Join(" ", winners); //optimization - let JITer decide if we need a string builder

                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}