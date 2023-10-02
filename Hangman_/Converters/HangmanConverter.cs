using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Data;
using Hangman_.Enums;
using System.Windows.Controls;

namespace Hangman_.Converters
{
    public class HangmanConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hangmanStatus = (HangmanStatus)value;

            switch (hangmanStatus)
            {
                case HangmanStatus.NoGuess:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/0Guess.jpg");

                case HangmanStatus.Wrong1:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/1Guess.jpg");

                case HangmanStatus.Wrong2:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/2Guess.jpg");

                case HangmanStatus.Wrong3:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/3Guess.jpg");

                case HangmanStatus.Wrong4:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/4Guess.jpg");

                case HangmanStatus.Wrong5:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/5Guess.jpg");

                case HangmanStatus.Wrong6:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/6Guess.jpg");

                case HangmanStatus.Wrong7:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/7Guess.jpg");

                case HangmanStatus.Wrong8:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/8Guess.jpg");

                case HangmanStatus.Wrong9:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/9Guess.jpg");

                case HangmanStatus.Wrong10:
                    return new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/10Guess.jpg");

                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
