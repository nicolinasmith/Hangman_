using Hangman_.Commands;
using Hangman_.Enums;
using Hangman_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        int count = 0;


        public GameViewModel(string randomWord)
        {
            RandomWord = randomWord;

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
            foreach (CharsOfWord c in CharsOfRandomWord)
            {
                if (c.WordChar == (char)guessedLetter)
                {
                    c.CharVisibility = LetterVisibilityStatus.GuessCorrect;
                    CountToFinishedGame();
                }
            }

            foreach (AlphabetButton c in Alphabet)
            {
                if (c.AlphabetChar == (char)guessedLetter)
                {
                    c.IsEnabled = false;
                }
            }
        }

        private void CountToFinishedGame()
        {
            foreach (CharsOfWord c in CharsOfRandomWord)
            {
                if (c.CharVisibility == LetterVisibilityStatus.GuessCorrect)
                {
                    count++;
                }
            }
            if (count == CharsOfRandomWord.Count)
            {
                MessageBox.Show("hej");
            }
        }
    }
}
