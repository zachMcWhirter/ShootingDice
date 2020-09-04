using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.Name = "Bob";

            Player player2 = new Player();
            player2.Name = "Sue";
            player2.Play(player1);

            Console.WriteLine("-------------------");

            Player large = new LargeDicePlayer();
            large.Name = "Biggie";
            large.Play(player2);

            Console.WriteLine("-------------------");

            // new players here
            Player smack = new SmackTalkingPlayer();
            smack.Name = "D-bag";
            smack.Play(large);

            Console.WriteLine("-------------------");

            Player oneUpper = new OneHigherPlayer();
            oneUpper.Name = "One Upper";
            oneUpper.Play(smack);

            Console.WriteLine("-------------------");

            Player human = new HumanPlayer();
            human.Name = "HomoSapien-Sapien";
            human.Play(oneUpper);

            Console.WriteLine("-------------------");

            Player superDBag = new CreativeSmackTalkingPlayer();
            superDBag.Name = "Super D-Bag";
            superDBag.Play(human);

            Console.WriteLine("-------------------");

            Player loser = new SoreLoserPlayer();
            loser.Name = "Loser";

            try
            {
                loser.Play(oneUpper);
                player1.Play(player2);
            }
            catch
            {
                Console.WriteLine($"Loser screams at the sky! NOOOOO! I've been defeated!");
            }

            Console.WriteLine("-------------------");

            Player oneUpper2 = new OneHigherPlayer();
            oneUpper2.Name = "One Upper2";
            oneUpper2.Play(loser);

            Console.WriteLine("-------------------");

            Player hiRoller = new UpperHalfPlayer();
            hiRoller.Name = "High Roller";
            hiRoller.Play(loser);

            Console.WriteLine("-------------------");

            Player hiRollerLoser = new SoreLoserUpperHalfPlayer();
            hiRollerLoser.Name = "High Rollin Loser";

            try
            {
                hiRollerLoser.Play(hiRoller);
                player1.Play(player2);
            }
            catch
            {
                Console.WriteLine($"High Rollin Loser screams at the sky! NOOOOO! I cannot be defeated by the likes of you!");
            }

            Console.WriteLine("-------------------");

            List<Player> players = new List<Player>()
            {
                player1,
                player2,
                large,
                smack,
                oneUpper,
                human,
                superDBag,
                loser,
                oneUpper2,
                hiRoller

            };

            PlayMany(players);
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                try
                {
                    player1.Play(player2);
                }
                catch
                {
                    Console.WriteLine($"Loser screams at the sky! NOOOOO! I cannot be defeated!");
                }
            }
        }
    }
}