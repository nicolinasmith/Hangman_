using Hangman_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman_.Models
{
    public class WordChar : DependencyObject
    {
        public char LetterOfWord { get; set; }

        public LetterVisibilityStatus CharVisibility
        {
            get { return (LetterVisibilityStatus)GetValue(CharVisibilityProperty); }
            set { SetValue(CharVisibilityProperty, value); }
        }

        public static readonly DependencyProperty CharVisibilityProperty =
            DependencyProperty.Register("CharVisibility", typeof(LetterVisibilityStatus), typeof(WordChar), new PropertyMetadata(LetterVisibilityStatus.GuessWrong));

    }
}
