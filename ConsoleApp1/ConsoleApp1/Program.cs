using System;
using System.Threading;
using System.Media;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Plane.position.X = 15;
            Plane.position.Y = 49;

            Player.position.X = 1;
            Player.position.Y = 3;


            Plane.MakeField();
            Console.ResetColor();
            //Console.WriteLine($"Score: {Player.score}");

            Console.CursorVisible = false ;
            SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\mainTheme.wav");
            sound1.PlayLooping();
            while (Player.isAlive)
            {
                DrawBombs();
                DrawPlayerMovement();
                Thread.Sleep(100);
            }
            Console.Clear();
            /*Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;*/
            //MediaPlayer;
            SoundPlayer sound = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\HALO.wav");
            sound.PlayLooping();
            Console.WriteLine("         ■■■■■                                            ■■■■                                       \n" +
                              "       ■■    ■■                                         ■■    ■■                                     \n" +
                              "      ■■       ■■                                      ■■      ■■                                    \n" +
                              "     ■■         ■■                                    ■■        ■■                                   \n" +
                              "     ■■                                               ■■        ■■                                   \n" +
                              "     ■■                                               ■■        ■■                                   \n" +
                              "     ■■     ■■■■■■                                    ■■        ■■                                   \n" +
                              "     ■■         ■■      ■■■    ■■■■■■    ■■■■         ■■        ■■    ■■      ■■  ■■■■    ■■■■■■     \n" +
                              "     ■■         ■■      ■ ■    ■  ■  ■   ■            ■■        ■■     ■■    ■■   ■       ■    ■     \n" +
                              "     ■■        ■■      ■  ■    ■  ■  ■   ■■■■         ■■        ■■      ■■  ■■    ■■■■    ■          \n" +
                              "      ■■      ■■       ■■■■    ■  ■  ■   ■             ■■      ■■        ■■■■     ■       ■          \n" +
                              "       ■■■■■■■         ■  ■    ■  ■  ■   ■■■■           ■■■■■■■           ■■      ■■■■    ■          \n"
                               );
            Console.ReadKey();
        }

        static void DrawPlayerMovement()
        {
            if (Console.KeyAvailable)
            {
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.SetCursorPosition(Player.position.Y,
                                          Player.position.X);

                ConsoleKeyInfo str = Console.ReadKey();
                Player.OnMove(str,
                              Plane.position.X,
                              Plane.position.Y);

                Console.SetCursorPosition(Player.position.Y,
                                          Player.position.X);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("☻");
                Console.SetCursorPosition(0, Plane.position.X + 1);
                Console.ResetColor();
            }
        }
        static void DrawBombs()
        {
            for (int i = 0; i < Player.bombs.Count; i++) 
            {
                if (Player.bombs[i].explosionTime == 0)
                {
                    Player.bombs[i].Explosion();
                    Player.bombs.Remove(Player.bombs[i--]);
                    Console.SetCursorPosition(0, Plane.position.X);
                    Console.WriteLine($"Score: {Player.score}");
                }
                else
                {
                    Player.bombs[i].Explosion();
                    Console.SetCursorPosition(Player.bombs[i].position.Y,
                                              Player.bombs[i].position.X);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('♦');
                    Console.SetCursorPosition(0, Plane.position.X + 1);
                }
            }
        }
    }
}