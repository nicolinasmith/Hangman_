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
                case HangmanStatus.No_Guess:
                    var image = new Image();
                    var imageUri = new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/0Guess.jpg");
                    var bitmapImage = new BitmapImage(imageUri);
                    image.Source = bitmapImage;
                    return image;

                case HangmanStatus.First_Wrong:
                    var image1 = new Image();
                    var imageUri1 = new Uri("pack://application:,,,/Hangman_;component/Pictures/Hangman/1Guess.jpg");
                    var bitmapImage1 = new BitmapImage(imageUri1);
                    image1.Source = bitmapImage1;
                    return image1;
                   
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
