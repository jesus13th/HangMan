using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace HangMan {
    public class Program {
        private static Dictionary<string, string[]> words = new Dictionary<string, string[]>() { };
        private static string[] fruits = {
            "apple", "pineapple", "cucumber", "broccoli","carrot", "banana", "avocado", "cherry", "lemon", "mango", "orange", "peach", "strawberry", "lettuce", "mushroom", "pea", "potato", "pumpkin", "radish", "tomato", "corn"};
        private static string[] animals = { "bear", "dog", "seagull", "cat", "pig", "goat", "lion", "tiger", "giraffe", "flamingo", "penguin", "toucan", "hen", "horse", "elephant", "cow", "dolphin", "cocodrile", "duck", "owl", "whale", "snake", "shark" };
        private static string word = "";
        private static int health = 5;

        public static void Main() {
            words.Add("Animal", animals);
            words.Add("Vegetable", fruits);
            Random random = new Random();
            var category = words.Keys.ElementAt(new Random().Next(0, words.Keys.Count));
            word = words[category][new Random().Next(0, category.Length)];
            StringBuilder hideWord = new StringBuilder(new string('*', word.Length));
            Console.WriteLine($"your category is: \"{category}\"");
            while (health > 0 && word != hideWord.ToString()) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your word is: { hideWord }");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Insert a character:");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine(Environment.NewLine);
                if (word.Contains(c)) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Success");
                    word.AllIndexesOf(c).ToList().ForEach(i => hideWord[i] = c);
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Fail, Health: { --health }");
                }
            }
            Console.ForegroundColor = health > 0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"End of Game, the word is '{word}', you { (health > 0 ? "win" : "lose")}.");
        }
    }
    public static class Extensions {
        public static IEnumerable<int> AllIndexesOf(this string str, char searchstring) {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1) {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + 1);
            }
        }
    }
}
