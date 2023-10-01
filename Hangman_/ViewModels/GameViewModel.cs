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

        public List<AlphabetLetter> Alphabet { get; set; }

        public List<WordChar> CharsOfRandomWord { get; set; }


        public GameViewModel(string randomWord)
        {
            RandomWord = randomWord;

            CreateListOfAlphabet();
            CreateListOfChars();

            GuessLetterCommand = new RelayCommand(guessedLetter => GuessLetter(guessedLetter));
        }

        private void GuessLetter(object guessedLetter)
        {

            foreach (WordChar c in CharsOfRandomWord)
            {
                if (c.LetterOfWord == (char)guessedLetter)
                {
                    c.CharVisibility = LetterVisibilityStatus.GuessCorrect;
                }
            }
        }

        public void CreateListOfAlphabet()
        {
            Alphabet = new List<AlphabetLetter>();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                var alphabetLetter = new AlphabetLetter
                {
                    Letter = letter,
                    LetterIsEnabled = true, 
                };

                Alphabet.Add(alphabetLetter);
            }
        }

        public void CreateListOfChars()
        {
            CharsOfRandomWord = new List<WordChar>();

            foreach (char c in RandomWord)
            {
                char upperC = Char.ToUpper(c);

                var letter = new WordChar
                {
                    LetterOfWord = upperC,
                    CharVisibility = LetterVisibilityStatus.GuessWrong,
                };

                CharsOfRandomWord.Add(letter);
            }
        }
    }
}
