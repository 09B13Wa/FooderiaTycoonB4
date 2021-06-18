using CSCore;
using CSCore.Codecs.MP3;

namespace FooderiaTycoon.Sound
{
    public class Music
    {
        private Mp3Frame _audioTrack;
        private int _length;
        public Music(Mp3Frame mp3Frame)
        {
            _audioTrack = mp3Frame;
            _length = mp3Frame.FrameLength;
        }
        //TODO:TO IMPROVE
    }
}