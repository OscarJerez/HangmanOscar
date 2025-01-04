using Hangman_OJ;
using Spectre.Console;

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
        AnsiConsole.MarkupLine("[bold green]Welcome to Hangman[/]");
        AnsiConsole.MarkupLine("[blue]-----------------------------------------[/]");

        string randomWord = _wordManager.GetRandomWord();
        List<char> guessedLetters = new List<char>();

        int wrongGuesses = 0;
        int correctGuesses = 0;
        int wordLength = randomWord.Length;

        DisplayWordState(randomWord, guessedLetters);

        while (wrongGuesses < 6 && correctGuesses < wordLength)
        {
            AnsiConsole.Markup("[yellow]\nLetters guessed so far:[/] ");
            guessedLetters.ForEach(c => AnsiConsole.Markup($"[white]{c} [/]"));

            AnsiConsole.Markup("\n[yellow]Guess a letter: [/] ");
            char guessedLetter;
            try
            {
                guessedLetter = Console.ReadLine()![0];
            }
            catch
            {
                AnsiConsole.MarkupLine("[red]Invalid input. Please enter a single letter.[/]");
                continue;
            }

            if (guessedLetters.Contains(guessedLetter))
            {
                AnsiConsole.MarkupLine("[red]\nYou have already guessed this letter.[/]");
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

        AnsiConsole.MarkupLine(wrongGuesses < 6
            ? "[bold green]\nCongratulations, you won![/]"
            : $"[bold red]\nGame Over! The word was: {randomWord}[/]");
    }

    private int DisplayWordState(string word, List<char> guessedLetters)
    {
        int correctGuesses = 0;
        AnsiConsole.Markup("\n");

        foreach (char c in word)
        {
            if (guessedLetters.Contains(c))
            {
                AnsiConsole.Markup($"[green]{c} [/]");
                correctGuesses++;
            }
            else
            {
                AnsiConsole.Markup("[white]_ [/]");
            }
        }

        AnsiConsole.MarkupLine("");
        return correctGuesses;
    }
}