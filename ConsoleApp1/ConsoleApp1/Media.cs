using System.Media;

namespace ConsoleApp1
{
    static public class Media
    {
        static public SoundPlayer titleSound = new SoundPlayer(@"sound\titleBomberMan.wav");
        static public SoundPlayer mainTheme = new SoundPlayer(@"sound\mainTheme.wav");
        static public SoundPlayer gameOverSound = new SoundPlayer(@"sound\HALO.wav");
        static public SoundPlayer explosionSound = new SoundPlayer(@"sound\explosion.wav");

        static public string level1 = @"Levels\level1.txt";
        static public string level2 = @"Levels\level2.txt";
        static public string level3 = @"Levels\level3.txt";
        static public string level4 = @"Levels\level4.txt";
    }
}
