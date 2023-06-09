﻿using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        public static int challengeTally = 0;
        public static void increaseChallengeTally()
        {
            challengeTally++;
        }
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Console.WriteLine("What is your name adventurer?... ");
            string userName = Console.ReadLine();

            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge howManyFingers = new Challenge("How many fingers am I holding up?", new Random().Next(1, 5), 25);
            Challenge woodchuck = new Challenge("How much wood could a woodchuck chuck if a woodchuck could chuck wood?", 7, 75);
            Challenge bikes = new Challenge("How many wheels does a bike have?", 2, 5);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Robe newRobe = new Robe
            {
                Color = "red",
                Length = 57
            };
            Hat newHat = new Hat
            {
                ShininessLevel = 5
            };

            Adventurer theAdventurer = new Adventurer(userName, newRobe, newHat);
            theAdventurer.GetDescription();

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                howManyFingers,
                woodchuck,
                bikes
            };
            // Randomize the challenges
            int getRandomChallenges()
            {
                int newChallenges = new Random().Next(0, 7);
                return newChallenges;
            }
            //create a different list of challenges that have been randomized
            var randomChallenges = new List<int>();
            while (randomChallenges.Count < 5)
            {
                int challenge = getRandomChallenges();
                if (!randomChallenges.Contains(challenge))
                {
                    randomChallenges.Add(challenge);
                }
            }

            // Loop through all of the random challenges and play 5 of them

            for (var i = 0; i < randomChallenges.Count; i++)
            {
                int theChallenge = randomChallenges[i];
                Challenge currentChallenge = challenges[theChallenge];
                currentChallenge.RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }
            void Prize(Adventurer adventurer)
            {
                Prize usersPrize = new Prize($"You win {theAdventurer.Awesomeness} jars of pickles!!");
                usersPrize.ShowPrize(adventurer);
            }
            Prize(theAdventurer);

            Console.WriteLine("Play Again? Yes or No...");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {
                Main(args);
                challengeTally = (challengeTally * 10);
                theAdventurer.Awesomeness += challengeTally;
                challengeTally = 0;
                Console.WriteLine($"Awesomeness Level: {theAdventurer.Awesomeness}");
            }
            else if (answer == "no")
            {
                return;
            }

        }
    }
}
