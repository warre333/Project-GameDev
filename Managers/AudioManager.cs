using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Project.Enums;
using System.Collections.Generic;

namespace Project.Managers
{
    public class AudioManager
    {
        private Song curSong;
        private Dictionary<AudioFile, Song> audios;

        public AudioManager()
        {
            audios = new Dictionary<AudioFile, Song>();
        }

        public void LoadContent(ContentManager content)
        {
            audios.Add(AudioFile.THEME, content.Load<Song>("Audio/Decisive Battle"));

            curSong = audios[AudioFile.THEME];
        }

        public void Play()
        {
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(curSong);
        }

        private void SetAudio(AudioFile audioFile)
        {
            curSong = audios[audioFile];
        }

        public void SetAudioAndPlay(AudioFile audioFile)
        {
            SetAudio(audioFile);
            Play();
        }
    }
}
