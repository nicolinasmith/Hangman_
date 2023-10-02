using Hangman_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman_.Models
{
    public class Hangman : DependencyObject
    {
        public HangmanStatus HangmanStatus
        {
            get { return (HangmanStatus)GetValue(HangmanStatusProperty); }
            set { SetValue(HangmanStatusProperty, value); }
        }

        public static readonly DependencyProperty HangmanStatusProperty =
            DependencyProperty.Register("HangmanStatus", typeof(HangmanStatus), typeof(Hangman), new PropertyMetadata(HangmanStatus.NoGuess));

    }
}
