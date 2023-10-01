using Hangman_.Commands;
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

        public List<char> CharsOfRandomWord { get; set; }

        public GameViewModel(string randomWord)
        {
            RandomWord = randomWord;

            CreateListOfAlphabet();
            CreateListOfChars();

            GuessLetterCommand = new RelayCommand(letter => GuessLetter((char)letter));
        }

        private void GuessLetter(char letter)
        {
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
            CharsOfRandomWord = new List<char>();

            foreach (char c in RandomWord)
            {
                char upperC = Char.ToUpper(c);
                CharsOfRandomWord.Add(upperC);
            }
        }
    }
}
