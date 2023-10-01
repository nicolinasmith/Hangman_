using Hangman_.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Hangman_.Converters
{
    public class LetterVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var letterStatus = (LetterVisibilityStatus)value;

            return letterStatus switch
            {
                LetterVisibilityStatus.GuessWrong => Visibility.Hidden,
                LetterVisibilityStatus.GuessCorrect => Visibility.Visible,
                _ => throw new NotImplementedException(),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
