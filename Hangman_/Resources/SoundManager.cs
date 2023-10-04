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
            soundDictionary.Add("LostSound", new SoundPlayer(Properties.Resources.LostBear));
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
