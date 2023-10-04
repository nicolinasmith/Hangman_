using Hangman_.Commands;
using Hangman_.Enums;
using Hangman_.Models;
using Hangman_.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman_.ViewModels
{
    public class GameViewModel : BaseViewModel
    {

        public ICommand GuessLetterCommand { get; set; }

        public string RandomWord { get; set; }

        public List<AlphabetButton> Alphabet { get; set; }

        public List<CharsOfWord> CharsOfRandomWord { get; set; }

        public Hangman Hangman { get; set; }
        
        public string Tries { get; set; }

        int countWrongs = 0;
        int countCorrect = 0;

        public GameViewModel(string randomWord)
        {
            RandomWord = randomWord;
            Tries = "0 / 8 wrongs before the bear is awoken";

            Hangman = new Hangman();

            CreateListOfAlphabet();
            CreateListOfChars();

            GuessLetterCommand = new RelayCommand(guessedLetter => GuessLetter(guessedLetter));
        }

        public void CreateListOfAlphabet()
        {
            Alphabet = new List<AlphabetButton>();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                var alphabetLetter = new AlphabetButton
                {
                    AlphabetChar = letter,
                    IsEnabled = true,
                };

                Alphabet.Add(alphabetLetter);
            }
        }

        public void CreateListOfChars()
        {
            CharsOfRandomWord = new List<CharsOfWord>();

            foreach (char c in RandomWord)
            {
                char upperC = Char.ToUpper(c);

                var letter = new CharsOfWord
                {
                    WordChar = upperC,
                    CharVisibility = LetterVisibilityStatus.GuessWrong,
                };

                CharsOfRandomWord.Add(letter);
            }
        }

        private void GuessLetter(object guessedLetter)
        {
            bool guessCorrect = false;

            foreach (CharsOfWord c in CharsOfRandomWord)
            {
                if (c.WordChar == (char)guessedLetter)
                {
                    c.CharVisibility = LetterVisibilityStatus.GuessCorrect;
                    countCorrect++;
                    guessCorrect = true;
                }
            }

            foreach (AlphabetButton c in Alphabet)
            {
                if (c.AlphabetChar == (char)guessedLetter)
                {
                    c.IsEnabled = false;
                }
            }

            if (!guessCorrect)
            {
                countWrongs++;
                Hangman.HangmanStatus = (HangmanStatus)countWrongs;
                Tries = $"{countWrongs} / 8 wrongs before the bear is awoken";
            }

            CalculateWin();
            CalculateLost();
        }

        private void CalculateLost()
        {
            if (countWrongs == 8)
            {
                GameFinished();
                SoundManager.PlaySound("LostSound");
                MessageBox.Show($"The bear is awoken and you have lost.\nThe correct word was:\n{RandomWord.ToUpper()}.");
            }
        }

        private void CalculateWin()
        {
            int countChars = 0;

            foreach (CharsOfWord c in CharsOfRandomWord)
            {
                if (c.CharVisibility == LetterVisibilityStatus.GuessCorrect)
                {
                    countChars++;
                }
            }
            if (countChars == CharsOfRandomWord.Count)
            {
                GameFinished();
                SoundManager.PlaySound("WonSound");
                MessageBox.Show($"Congratulations!\n \nYou have guessed the correct word:\n{RandomWord.ToUpper()}.");
            }
        }

        private void GameFinished()
        {
            foreach (CharsOfWord c in CharsOfRandomWord)
            {
                c.CharVisibility = LetterVisibilityStatus.GuessCorrect;
            }

            foreach (AlphabetButton c in Alphabet)
            {
                c.IsEnabled = false;
            }
        }
    }
}
