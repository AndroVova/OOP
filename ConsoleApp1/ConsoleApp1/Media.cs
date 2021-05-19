using System.Media;

namespace ConsoleApp1
{
    static public class Media
    {
        static public SoundPlayer titleSound = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\titleBomberMan.wav");
        static public SoundPlayer mainTheme = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\mainTheme.wav");
        static public SoundPlayer gameOverSound = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\HALO.wav");
        static public SoundPlayer explosionSound = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\explosion.wav");

    }
}
