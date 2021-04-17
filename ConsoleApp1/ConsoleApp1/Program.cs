using System;
using System.Threading;
using System.Media;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            SoundPlayer sound0 = new SoundPlayer(@"C:\Users\Vova\Desktop\mainTheme.wav");
            sound0.PlayLooping();
            Console.WriteLine(    "     ■■■■■■■■■■                                                                              ■■■■    ■■■■       \n" +
                                  "     ■■       ■■                                                                             ■  ■    ■          \n" +
                                  "     ■■        ■■                                                                            ■■■     ■■■         \n" +
                                  "     ■■         ■■                                                                           ■       ■           \n" +
                                  "     ■■         ■■                      ■                                                    ■       ■■■■        \n" +
                                  "     ■■        ■■                       ■                                                                    \n" +
                                  "     ■■■■■■■■■■■                        ■                                                    ■■■■    ■■■       \n" +
                                  "     ■■         ■■    ■■■■    ■■■■■■    ■■■■■    ■■■■■   ■■■■■■                              ■  ■    ■  ■       \n" +
                                  "     ■■         ■■   ■    ■   ■  ■  ■   ■    ■   ■       ■    ■                              ■       ■  ■         \n" +
                                  "     ■■         ■■   ■    ■   ■  ■  ■   ■    ■   ■■■■■   ■                                   ■       ■  ■       \n" +
                                  "     ■■        ■■    ■    ■   ■  ■  ■   ■    ■   ■       ■                                   ■       ■  ■        \n" +
                                  "     ■■■■■■■■■■■      ■■■■    ■  ■  ■   ■■■■■    ■■■■■   ■                                                   \n" +
                                  "                                                                                             ■■■    ■■■■■         \n" +
                                  "                                                      ■■■          ■■■                       ■        ■        \n" +
                                  "                                                      ■■■■        ■■■■                       ■■■      ■        \n" +
                                  "                                                      ■■ ■■      ■■ ■■                       ■        ■        \n" +
                                  "                                                      ■■  ■■    ■■  ■■                       ■■■      ■        \n" +
                                  "                                                      ■■   ■■  ■■   ■■                                       \n" +
                                  "                                                      ■■    ■■■■    ■■                        ■■     ■■■■         \n" +
                                  "                                                      ■■            ■■                       ■       ■         \n" +
                                  "                                                      ■■            ■■    ■■■   ■■■■          ■      ■■■         \n" +
                                  "                                                      ■■            ■■   ■  ■   ■   ■          ■     ■         \n" +
                                  "                                                      ■■            ■■   ■  ■   ■   ■        ■■■     ■■■■          \n" +
                                  "                                                      ■■            ■■   ■■■■   ■   ■                        \n" +
                                  "                                                      ■■            ■■   ■  ■   ■   ■         ■■     ■■■■            \n" +
                                  "                                                                                             ■       ■  ■          \n" +
                                  "                                                                                              ■      ■            \n" +
                                  "                                                                                               ■     ■            \n" +
                                  "                                                                                             ■■■     ■             "

                                   );

            Console.ReadLine();
            Console.Clear();
            sound0.Stop();

            Plane.position.X = 25;
            Plane.position.Y = 29;

            Player.position.X = 1;
            Player.position.Y = 3;

            Enemy.position.X = 10;
            Enemy.position.Y = 3;

            Plane.MakeField();
            Console.ResetColor();

            while (Player.isAlive && Enemy.isAlive)
            {
                DrawBombs();
                DrawPlayerMovement();
                DrawEnemyMovement();
                Thread.Sleep(100);
            }
            Console.ResetColor();
            Console.Clear();
            
            if (!Player.isAlive)
            {
                SoundPlayer sound = new SoundPlayer(@"C:\Users\Vova\Desktop\HALO.wav");
                sound.PlayLooping();
                
                string str =     ("         ■■■■■                                            ■■■■                                       \n" +
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
                while (!Console.KeyAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            if (!Enemy.isAlive && Player.isAlive)
            {
                SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Vova\Desktop\mainTheme.wav");
                sound1.PlayLooping();
                string str =     ("    ■■          ■■                  ■■                           ■■              ■              \n" +
                                  "     ■■        ■■                    ■■                         ■■               ■              \n" +
                                  "      ■■      ■■                      ■■                       ■■                ■              \n" +
                                  "       ■■    ■■                        ■■                     ■■                 ■              \n" +
                                  "        ■■  ■■                          ■■                   ■■                  ■              \n" +
                                  "         ■■■■                            ■■                 ■■                   ■              \n" +
                                  "          ■■     ■■■■    ■    ■           ■■      ■■■      ■■    ■   ■■■■■       ■              \n" +
                                  "          ■■    ■    ■   ■    ■            ■■    ■■■■■    ■■     ■   ■    ■      ■              \n" +
                                  "          ■■    ■    ■   ■    ■             ■■  ■■   ■■  ■■      ■   ■    ■      ■              \n" +
                                  "          ■■    ■    ■   ■    ■              ■■■■     ■■■■       ■   ■    ■     ■■■             \n" +
                                  "          ■■     ■■■■      ■■■■               ■■       ■■        ■   ■    ■     ■■■             \n" +
                                  "                                                                                                \n"
                                   );
                while (!Console.KeyAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
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
                Player.OnMove(str);

                Console.SetCursorPosition(Player.position.Y,
                                          Player.position.X);
                Console.ForegroundColor = ConsoleColor.Green;
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
                    Player.bombs[i].ExplosionAnimation();
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
        static void DrawEnemyMovement()
        {
            if (Enemy.isAlive)
            {
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Enemy.position.Y,
                                          Enemy.position.X);
                Console.Write(" ");

                Enemy.OnMove();

                Console.SetCursorPosition(Enemy.position.Y,
                                          Enemy.position.X);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("@");
                Console.SetCursorPosition(0, Plane.position.X + 1);
                Console.ResetColor();
            }
        }
    }
}