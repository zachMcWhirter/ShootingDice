using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        List<string> insultList = new List<string>()
        {
            "You suck!",
            "Wow, you're really awful at this",
            "And...more crap",
            "Maybe you should quit dude",
            "Just give me your money and save us some time"
        };
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int randomIndex = new Random().Next(0, insultList.Count);
            Console.WriteLine(insultList[randomIndex]);
            int myRoll = Roll();
            int otherRoll = other.Roll();

            Console.WriteLine($"{Name} rolls a {myRoll}");

            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if (myRoll > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }
    }
}