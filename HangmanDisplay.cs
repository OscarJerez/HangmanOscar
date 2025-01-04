using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // Add Newtonsoft.Json via NuGet for JSON handling
using Spectre.Console; // Add Spectre.Console via NuGet for enhanced console UI

namespace Hangman_OJ
{
    // Manages the display of the hangman graphics
    public class HangmanDisplay
    {
        public void PrintHangman(int wrong)
        {
            string[] stages =
            {
                "[red]\n+---+\n    |\n    |\n    |\n   ===[/]",
                "[red]\n+---+\nO   |\n    |\n    |\n   ===[/]",
                "[red]\n+---+\nO   |\n|   |\n    |\n   ===[/]",
                "[red]\n+---+\n O  |\n/|  |\n    |\n   ===[/]",
                "[red]\n+---+\n O  |\n/|\\ |\n    |\n   ===[/]",
                "[red]\n+---+\n O  |\n/|\\ |\n/   |\n   ===[/]",
                "[red]\n+---+\n O  |\n/|\\ |\n/ \\ |\n   ===[/]"
            };

            AnsiConsole.MarkupLine(stages[wrong]);
        }
    }

    // Manages the word selection and JSON file operations
    public class WordManager
    {
        public List<string> Words { get; private set; }

        public WordManager(string filePath)
        {
            LoadWordsFromJson(filePath);
        }

        private void LoadWordsFromJson(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                Words = JsonConvert.DeserializeObject<List<string>>(json)!;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[bold red]Error reading JSON file:[/] " + ex.Message);
                Words = new List<string>();
            }
        }

        public string GetRandomWord()
        {
            Random random = new Random();
            return Words[random.Next(Words.Count)];
        }
    }
}