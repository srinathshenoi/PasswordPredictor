using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenesisPredictor
{
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            //Random random = new Random();
            var target = "home";
            var guess = GenerateRandom(target.Length);
            Console.WriteLine("target - " + target);
            Console.WriteLine("Guess - " + guess);
            CheckFitness(guess, target);
        }

        private static void CheckFitness(string guess, string target)
        {
            //var fitness = Compare(guess, target);
            var count = 0;
            while (!guess.Equals(target))
            {
                count++;
                var fitness = Compare(guess, target);
                //Console.WriteLine(fitness.Count);
                //Thread.Sleep(50);
                guess = ModifyGuess(guess, fitness);
                Console.WriteLine("Fitness - "+fitness.Count +" Count - " + count+ " New Guess - " + guess);
            }
            Console.WriteLine("\nAnswer - " + guess);
        }

        private static string ModifyGuess(string guess, List<int> fitness)
        {
            var newGuess = new StringBuilder();
            var library = "qwertyuiopasdfghjklzxcvbnm";
            //var random = new Random();
            for (int guessIndex = 0; guessIndex < guess.Length; guessIndex++)
            {
                if (!fitness.Contains(guessIndex))
                {
                    var RandomIndex = random.Next(0, library.Length);
                    newGuess.Insert(guessIndex,library[RandomIndex]);
                }
                else
                {
                    newGuess.Insert(guessIndex, guess[guessIndex]);
                }
            }
            return newGuess.ToString();
        }

        private static List<int> Compare(string guess, string target)
        {
            var fitnessIndexes = new List<int>();
            for (int guessCharIndex = 0; guessCharIndex < guess.Length; guessCharIndex++)
            {
                if (guess[guessCharIndex].Equals(target[guessCharIndex]))
                {
                    fitnessIndexes.Add(guessCharIndex);
                }
            }
            return fitnessIndexes;
        }

        private static string GenerateRandom(int length)
        {
            var library = "qwertyuiopasdfghjklzxcvbnm";
            var guess = new StringBuilder();
            //var random = new Random();
            while (length > guess.Length)
            {
                var guessIndex = random.Next(0, library.Length);
                guess.Append(library[guessIndex]);
            }
            return guess.ToString();
        }
    }
}
