namespace CowAndBull
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cow and Bull Game!");
            string word = "golf";

            bool guessed = false;
            int attempts = 0;

            while (!guessed)
            {
                Console.WriteLine($"Attempt {++attempts}");
                Console.Write("Enter your guess: ");
                string guess = Console.ReadLine().ToLower();

                if (guess.Length != 4)
                {
                    Console.WriteLine("Please enter a 4-letter word.");
                    continue;
                }

                int cows = 0;
                int bulls = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess[i])
                    {
                        cows++;
                    }
                    else if (word.Contains(guess[i]))
                    {
                        bulls++;
                    }
                }

                Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");

                if (cows == 4)
                {
                    guessed = true;
                }
            }

            Console.WriteLine($"Congratulations!!! You guessed the word '{word}' in {attempts} attempts.");
        }
    }
}
