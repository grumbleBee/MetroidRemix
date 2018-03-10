
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using System;
using CSE3902.Util;

namespace CSE3902.Effects
{
    public class SoundManager
    {
        readonly Dictionary<string, CustomSound> _songList = new Dictionary<string, CustomSound>();
        public static SoundManager Instance { get; } = new SoundManager();

        private SoundManager()
        {

        }

        public void PlaySong(string name)
        {
            if (_songList.ContainsKey(name))
            {
                _songList[name].SoundEffectInstance.Play();

            }
            else
            {
                Console.WriteLine("Error loading " + name + " song");
            }
        }

        public void PauseSong(string name)
        {
            if (_songList.ContainsKey(name))
            {
                _songList[name].SoundEffectInstance.Pause();
            }
            else
            {
                Console.WriteLine("Error pausing" + name + " song");
            }
        }

        public void ResumeSong(string name)
        {
            if (_songList.ContainsKey(name))
            {
                _songList[name].SoundEffectInstance.Resume();
            }
            else
            {
                Console.WriteLine("Error resuming " + name + " song");
            }
        }

        public SoundEffectInstance GetSoundEffect(string name)
        {
            return _songList[name].SoundEffectInstance;
        }

        public void LoadAllSongs(ContentManager content, string fileLocation)
        {
            var fileStream = File.OpenRead(fileLocation);
            var fileReader = new StreamReader(fileStream);

            while (!fileReader.EndOfStream)
            {
                string line = fileReader.ReadLine();
                string[] songArray = line.Split(',');
                SoundEffect song = content.Load<SoundEffect>(songArray[0]);
                CustomSound customSound = new CustomSound {SoundEffect = song};
                customSound.SoundEffectInstance = customSound.SoundEffect.CreateInstance();
                if (songArray[1].Equals(SoundConstants.Loop)) customSound.SoundEffectInstance.IsLooped = true;
                _songList.Add(songArray[0], customSound);
            }

        }

    
    }

}
