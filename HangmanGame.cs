using HangmanOscar;

public class HangmanGame
{
    private readonly HangmanDisplay _display;
    private readonly WordManager _wordManager;

    public HangmanGame(HangmanDisplay display, WordManager wordManager)
    {
        _display = display;
        _wordManager = wordManager;
    }

    public void Play()
    {
        Console.WriteLine("Welcome to Hangman");
        Console.WriteLine("-----------------------------------------");

        string randomWord = _wordManager.GetRandomWord();
        List<char> guessedLetters = new List<char>();

        int wrongGuesses = 0;
        int correctGuesses = 0;
        int wordLength = randomWord.Length;

        DisplayWordState(randomWord, guessedLetters);

        while (wrongGuesses < 6 && correctGuesses < wordLength)
        {
            Console.Write("\nLetters guessed so far: ");
            guessedLetters.ForEach(c => Console.Write(c + " "));

            Console.Write("\nGuess a letter: ");
            char guessedLetter = Console.ReadLine()![0];

            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine("\nYou have already guessed this letter.");
            }
            else
            {
                guessedLetters.Add(guessedLetter);

                if (randomWord.Contains(guessedLetter))
                {
                    correctGuesses = DisplayWordState(randomWord, guessedLetters);
                }
                else
                {
                    wrongGuesses++;
                    _display.PrintHangman(wrongGuesses);
                }
            }
        }

        Console.WriteLine(wrongGuesses < 6 ? "\nCongratulations, you won!" : "\nGame Over! The word was: " + randomWord);
    }

    private int DisplayWordState(string word, List<char> guessedLetters)
    {
        int correctGuesses = 0;
        Console.Write("\n");

        foreach (char c in word)
        {
            if (guessedLetters.Contains(c))
            {
                Console.Write(c + " ");
                correctGuesses++;
            }
            else
            {
                Console.Write("_ ");
            }
        }

        Console.WriteLine();
        return correctGuesses;
    }
}
