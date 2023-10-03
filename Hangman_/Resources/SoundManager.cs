using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_.Resources
{
    public class SoundManager
    {
        private static Dictionary<string, SoundPlayer> soundDictionary = new Dictionary<string, SoundPlayer>();

        static SoundManager()
        {
            soundDictionary.Add("WonSound", new SoundPlayer(Properties.Resources.Won));
            soundDictionary.Add("LoseSound", new SoundPlayer(Properties.Resources.Lost));
            soundDictionary.Add("CorrectSound", new SoundPlayer(Properties.Resources.Correct));
            soundDictionary.Add("WrongSound", new SoundPlayer(Properties.Resources.Wrong));
        }

        public static void PlaySound(string soundKey)
        {
            if (soundDictionary.ContainsKey(soundKey))
            {
                soundDictionary[soundKey].Play();
            }
            else
            {
                throw new ArgumentException("Sound not found", nameof(soundKey));
            }
        }
    }
}
