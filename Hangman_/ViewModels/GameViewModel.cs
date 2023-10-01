using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public string RandomWord { get; set; }

        public List<char> Alphabet { get; set; }

        public GameViewModel(string randomWord)
        {
            RandomWord = randomWord;

            Alphabet = new List<char>();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                Alphabet.Add(letter);
            }
            //DataContext = this;
        }
    }
}
