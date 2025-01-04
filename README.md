# HangmanOscar

## Overview

This is a console-based Hangman game implemented in C# using the **Spectre.Console** library for enhanced console UI. The game reads a list of words from a JSON file (`words.json`), randomly selects one, and allows the player to guess the letters until the word is completed or the player loses.

---

## Features

- **Spectre.Console**: Provides a colorful and interactive console experience.
- **Word List from JSON**: Fetches words dynamically from an external `words.json` file.
- **Hangman Stages**: Displays the hangman graphics for wrong guesses.
- **Dynamic Word Guessing**: Tracks guessed letters and updates the word display in real-time.

---

## Requirements

1. **C# Environment**: .NET 6.0 or later.
2. **Libraries**:
   - **Spectre.Console**: For advanced console visuals.
   - **Newtonsoft.Json**: For reading and parsing the JSON file.

Install the libraries using NuGet Package Manager:

```sh
Install-Package Spectre.Console
Install-Package Newtonsoft.Json
```

---

## JSON File

The game uses a `words.json` file to store the list of words. Place this file in the same directory as the program executable.

### Example `words.json`

```json
[
    "rental",
    "nominee",
    "township",
    "adhesive",
    "lengthy",
    "swarm",
    "court",
    "baguette",
    "leper",
    "vital"
]
```

---

## How to Run the Game

1. **Clone the Repository** (or download the source files):

   ```sh
   git clone https://github.com/your-repo/hangman-game.git
   ```

2. **Build and Run the Program**:

   - Open the project in your favorite C# IDE (e.g., Visual Studio, JetBrains Rider).
   - Restore NuGet packages.
   - Compile and run the project.

3. **Play the Game**:

   - The game will display underscores (`_`) for each letter in the word.
   - Enter one letter at a time to guess the word.
   - The game will show your progress and a hangman graphic for wrong guesses.

---

## How the Code Works

### Core Components

1. **`HangmanDisplay`**** Class**

   - Manages the visuals for the hangman stages.

2. **`WordManager`**** Class**

   - Reads the list of words from `words.json` and selects a random word.

3. **`HangmanGame`**** Class**

   - Contains the main game logic, including tracking guessed letters and checking for victory or loss conditions.

4. **`Program`**** Class**

   - Entry point of the application. Initializes the game components and starts the game.

---

## Example Output

```plaintext
Welcome to Hangman
-----------------------------------------
_ _ _ _ _

Letters guessed so far:
Guess a letter: e

_ e _ _ _

Letters guessed so far: e
Guess a letter: t

_ e t t _

Congratulations, you won!
```

---

## Troubleshooting

- **JSON File Not Found**:
  Ensure `words.json` is in the same directory as the program executable.

- **NuGet Packages Not Installed**:
  Run the following commands to install the required libraries:

  ```sh
  dotnet add package Spectre.Console
  dotnet add package Newtonsoft.Json
  ```

---

