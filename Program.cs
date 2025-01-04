using Hangman_OJ;
using Spectre.Console;

public class Program
{
    static void Main(string[] args)
    {
        string jsonFilePath = "words.json";

        if (!File.Exists(jsonFilePath))
        {
            AnsiConsole.MarkupLine("[bold red]JSON file not found! Please ensure 'words.json' is in the same directory as the program.[/]");
            return;
        }

        HangmanDisplay display = new HangmanDisplay();
        WordManager wordManager = new WordManager(jsonFilePath);
        HangmanGame game = new HangmanGame(display, wordManager);

        game.Play();
    }
}

