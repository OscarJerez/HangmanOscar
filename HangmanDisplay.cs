using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // Add Newtonsoft.Json via NuGet for JSON handling

namespace HangmanOscar
{
    // Manages the display of the hangman graphics
    public class HangmanDisplay
    {
        public void PrintHangman(int wrong)
        {
            string[] stages =
            {
                "\n+---+\n    |\n    |\n    |\n   ===",
                "\n+---+\nO   |\n    |\n    |\n   ===",
                "\n+---+\nO   |\n|   |\n    |\n   ===",
                "\n+---+\n O  |\n/|  |\n    |\n   ===",
                "\n+---+\n O  |\n/|\\ |\n    |\n   ===",
                "\n+---+\n O  |\n/|\\ |\n/   |\n   ===",
                "\n+---+\n O  |\n/|\\ |\n/ \\ |\n   ==="
            };

            Console.WriteLine(stages[wrong]);
        }
    }
}
