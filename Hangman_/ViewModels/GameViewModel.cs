using Hangman_.Commands;
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

        public bool LetterIsEnabled { get; set; } = true;

        public List<char> Alphabet { get; set; }

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
            MessageBox.Show("HEJ");
        }

        public void CreateListOfAlphabet()
        {
            Alphabet = new List<char>();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                Alphabet.Add(letter);
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
