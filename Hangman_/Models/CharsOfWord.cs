using Hangman_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman_.Models
{
    public class CharsOfWord : DependencyObject
    {
        public char WordChar { get; set; }

        public LetterVisibilityStatus CharVisibility
        {
            get { return (LetterVisibilityStatus)GetValue(CharVisibilityProperty); }
            set { SetValue(CharVisibilityProperty, value); }
        }

        public static readonly DependencyProperty CharVisibilityProperty =
            DependencyProperty.Register("CharVisibility", typeof(LetterVisibilityStatus), typeof(CharsOfWord), new PropertyMetadata(LetterVisibilityStatus.GuessWrong));

    }
}
