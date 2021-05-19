using System.Media;

namespace ConsoleApp1
{
    static public class Media
    {
        static public SoundPlayer titleSound = new SoundPlayer(@"sound\titleBomberMan.wav");
        static public SoundPlayer mainTheme = new SoundPlayer(@"sound\mainTheme.wav");
        static public SoundPlayer gameOverSound = new SoundPlayer(@"sound\HALO.wav");
        static public SoundPlayer explosionSound = new SoundPlayer(@"sound\explosion.wav");
    }
}
