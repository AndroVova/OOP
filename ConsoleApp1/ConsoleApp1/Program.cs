using System;
using System.Threading;
using System.Media;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static public int gameSpeed = 60;
        static public List<Enemy> enemies = new List<Enemy>();
        static public Teleporter teleport = new Teleporter(new Cell(10, 2), new Cell(10, 25));

        static public Enemy enemy1 = new Enemy(new Cell(0, 0));
        static public Enemy enemy2 = new Enemy(new Cell(0, 0));
        static public Enemy enemy3 = new Enemy(new Cell(0, 0));
        static public Enemy enemy4 = new Enemy(new Cell(0, 0));
        static public Enemy enemy5 = new Enemy(new Cell(0, 0));
        static public Enemy enemy6 = new Enemy(new Cell(0, 0));
        static public Enemy enemy7 = new Enemy(new Cell(0, 0));

        static void Main()
        {
            Console.Title = "BomberMan";
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
            

            bool gameIsActive = true;
            while (gameIsActive)
            {
                Menu.currentSection = 0;
                Menu.MakeMenu(Menu.menu);
                Console.Clear();
                

                if (Menu.currentSection == 0)
                {
                    sound0.Stop();
                    Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;

                    Plane.walls.Clear();
                    Plane.bricks.Clear();

                    Plane.position.X = 25;
                    Plane.position.Y = 29;
                    
                    Player.position.X = 9;
                    Player.position.Y = 3;

                    Player.isAlive = true;
                    Player.bombs.Clear();
                    Player.broakenBricks = 0;


                    enemy1.position.X = 9;
                    enemy1.position.Y = 25;

                    enemy2.position.X = 10;
                    enemy2.position.Y = 26;

                    enemy3.position.X = 3;
                    enemy3.position.Y = 7;
                    
                    enemy4.position.X = 7;
                    enemy4.position.Y = 12;

                    enemy5.position.X = 11;
                    enemy5.position.Y = 14;

                    enemy6.position.X = 15;
                    enemy6.position.Y = 9;

                    enemy7.position.X = 19;
                    enemy7.position.Y = 8;

                    enemies.Clear();
                   
                    enemies.Add(enemy1);
                    enemies.Add(enemy2);
                    enemies.Add(enemy3);
                    enemies.Add(enemy4);
                    enemies.Add(enemy5);
                    enemies.Add(enemy6);
                    enemies.Add(enemy7);


                    Plane.MakeField();
                    Console.ResetColor();

                    while (Player.isAlive && enemies.Count != 0)
                    {
                        DrawBombs();
                        DrawPlayerMovement();
                        DrawEnemyMovement();
                        TeleporeterDraw();
                        DrawEnemyLives();
                        Thread.Sleep(3*gameSpeed);
                    }
                    Thread.Sleep(100);
                    Console.ResetColor();
                    Console.Clear();

                    if (!Player.isAlive)
                    {
                        SoundPlayer sound = new SoundPlayer(@"C:\Users\Vova\Desktop\HALO.wav");
                        sound.PlayLooping();

                        string loseText = ("         ■■■■■                                            ■■■■                                       \n" +
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
                        TextAnimation(loseText);
                        sound.Stop();
                    }
                    if (enemies.Count == 0 && Player.isAlive)
                    {
                        SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Vova\Desktop\mainTheme.wav");
                        sound1.PlayLooping();
                        string winText = ("    ■■          ■■                  ■■                           ■■              ■              \n" +
                                          "     ■■        ■■                    ■■                         ■■               ■              \n" +
                                          "      ■■      ■■                      ■■                       ■■                ■              \n" +
                                          "       ■■    ■■                        ■■                     ■■                 ■              \n" +
                                          "        ■■  ■■                          ■■                   ■■                  ■              \n" +
                                          "         ■■■■                            ■■                 ■■                   ■              \n" +
                                          "          ■■     ■■■■    ■    ■           ■■      ■■■      ■■    ■   ■■■■■       ■              \n" +
                                          "          ■■    ■    ■   ■    ■            ■■    ■■■■■    ■■     ■   ■    ■      ■              \n" +
                                          "          ■■    ■    ■   ■    ■             ■■  ■■   ■■  ■■      ■   ■    ■      ■              \n" +
                                          "          ■■    ■    ■   ■    ■              ■■■■     ■■■■       ■   ■    ■     ■■■             \n" +
                                          "          ■■     ■■■■     ■■■■■               ■■       ■■        ■   ■    ■     ■■■             \n" +
                                          "                                                                                                \n"
                                           );
                        TextAnimation(winText);
                        sound1.Stop();
                    }
                }
                else if (Menu.currentSection == 1)
                {
                    Menu.currentSection = 0;
                    Menu.MakeMenu(Menu.settings);
                    Console.Clear();
                    switch (Menu.currentSection)
                    {
                        case 0:
                            Menu.ViewControls();
                            Console.Clear();
                            continue;
                        case 1:
                            Menu.MakeMenu(Menu.gameSpeedSettings);
                            Console.Clear();
                            switch (Menu.currentSection)
                            {
                                case 0:
                                    gameSpeed = 40;
                                    break;
                                case 1:
                                    gameSpeed = 60;
                                    break;
                                case 2:
                                    gameSpeed = 80;
                                    break;
                                default:
                                    break;
                            }
                            continue;
                        case 2:
                            continue ;
                    }                                  
                }
                else if (Menu.currentSection == 2)
                {
                    string str = ("    ■■■■■■■■■■                       \n" +
                                  "    ■■       ■■                      \n" +
                                  "    ■■        ■■                     \n" +
                                  "    ■■         ■■                    \n" +
                                  "    ■■        ■■                     \n" +
                                  "    ■■■■■■■■■■■                      \n" +
                                  "    ■■        ■■     ■   ■   ■■■■■   \n" +
                                  "    ■■         ■■     ■  ■   ■       \n" +
                                  "    ■■         ■■      ■■■   ■■■■    \n" +
                                  "    ■■        ■■        ■    ■       \n" +
                                  "    ■■■■■■■■■■■        ■     ■■■■■   \n");

                    TextAnimation(str);
                    gameIsActive = false;
                }

                Console.ReadKey();
                Console.ResetColor();
            }
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
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(16, Plane.position.X);
                    Console.Write(Player.broakenBricks);
                    Console.ResetColor();
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
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies.Any(el => el.isAlive))
                {
                    Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(enemies[i].position.Y,
                                              enemies[i].position.X);
                    Console.Write(" ");

                    enemies[i].OnMove();

                    Console.SetCursorPosition(enemies[i].position.Y,
                                              enemies[i].position.X);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("☺");
                    Console.SetCursorPosition(0, Plane.position.X + 1);
                    Console.ResetColor();
                }
            }
        }
        static void DrawEnemyLives()
        {
            Console.SetCursorPosition(18 , Plane.position.X);
            Console.Write($"enemies alive: {enemies.Count}/7");
        }
        static void TeleporeterDraw()
        {
            Console.SetCursorPosition(teleport.positionIn.Y,
                                      teleport.positionIn.X);

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (changeColor)
                Console.Write("▀");  
            else
                Console.Write("▄");
            
            Console.SetCursorPosition(teleport.positionOut.Y,
                                      teleport.positionOut.X);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (changeColor)
            {
                Console.Write("▀");
                changeColor = false;
            }
            else
            {
                Console.Write("▄");
                changeColor = true;
            }

            Console.SetCursorPosition(0, Plane.position.X + 1);
            Console.ResetColor();
        }

        private static bool changeColor = true;
        private static void TextAnimation(string str)
        {
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
    }
}