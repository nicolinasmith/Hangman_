using Hangman_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_.Models
{
    public class AlphabetButton : BaseViewModel
    {
        public char AlphabetChar { get; set; }

        public bool IsEnabled { get; set; }
    }
}
