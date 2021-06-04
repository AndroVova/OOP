using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using System.Diagnostics;


namespace ConsoleApp1
{
    class Program
    {
        public static List<Enemy> enemies = new List<Enemy>();
        static public Teleporter teleport = new Teleporter(new Cell(6, 2), new Cell(15, 25));

        static public bool level1 = false;
        static public bool level2 = false;
        static public bool level3 = false;
        static public bool level4 = false;
        static public bool isHard = false;        

        private static bool changeColor = true;

        static public byte enemiesNumber;
        static public int gameSpeed = 60;

        static void Main()
        {
            Console.CursorVisible = false;

            Media.titleSound.PlayLooping();
            
            TextAnimation(Menu.bomberManText);
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine(Menu.enterNameText);
            Console.SetCursorPosition(50, 16);
            Player.name = Console.ReadLine();
            Console.Clear();

            Media.titleSound.Stop();

            Menu.MakeMenuStructure();
        }

        static public void Game()
            {
                Media.mainTheme.Stop();
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                
                Plane.MakeField();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (Player.isAlive && enemies.Count != 0)
                {
                    DrawBombs();
                    DrawPlayerMovement();
                    DrawEnemyMovement();
                    DrawTeleporeter();
                    DrawEnemyLives();
                    Thread.Sleep(3 * gameSpeed);
                }
                stopWatch.Stop();

                Thread.Sleep(100);
                Console.ResetColor();
                Console.Clear();
                
                DrawEndGameText(stopWatch);
            }

        static private void DrawPlayerMovement()
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
        static private void DrawBombs()
            {
                for (int i = 0; i < Player.bombs.Count; i++)
                {
                    if (Player.bombs[i].explosionTime == 0)
                    {
                        Player.bombs[i].ExplosionAnimation();
                        Player.bombs.Remove(Player.bombs[i--]);
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

        static private void DrawEnemyMovement()
            {
                for (int i = 0; i < enemies.Count; i++)
                { 
                    Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(enemies[i].position.Y,
                                              enemies[i].position.X);
                    Console.Write(" ");
                    enemies[i].Move();
                
                    Console.SetCursorPosition(enemies[i].position.Y,
                                              enemies[i].position.X);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("☻");
                    Console.SetCursorPosition(0, Plane.position.X + 1);
                    Console.ResetColor();
                }
            }

        static private void DrawEnemyLives()
            {
                Console.SetCursorPosition(0, Plane.position.X);
                Console.Write($"enemies alive: {enemies.Count}/{enemiesNumber}");
            }

        static void DrawTeleporeter()

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
        private static void DrawEndGameText(Stopwatch stopWatch)
        {
            if (!Player.isAlive)
            {
                Media.gameOverSound.PlayLooping();
                TextAnimation(Menu.loseText);
                Media.gameOverSound.Stop();
            }
            if (enemies.Count == 0 && Player.isAlive)
            {
                Media.mainTheme.PlayLooping();

                TimeSpan time = stopWatch.Elapsed;
                var newRating = new WorkWithFile();
                newRating.AddResults(new GameResults(Player.name, (time.Seconds).ToString(), DateTime.Now, Player.usedBombs));

                TextAnimation(Menu.winText);
                Media.mainTheme.Stop();
            }
        }
        public static void TextAnimation(string str)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.ResetColor();
                } while (!Console.KeyAvailable);
            }
        public static void ResetLevel()
            {
                level1 = false;
                level2 = false;
                level3 = false;
                level4 = false;

                Plane.walls.Clear();
                Plane.bricks.Clear();

                Player.usedBombs = 0;
                Player.isAlive = true;
                Player.bombs.Clear();

                enemies.Clear();
                enemiesNumber = 0;

                Menu.currentSection = 0;
            }
        public static void DrawRating()
            {
                var rating = new WorkWithFile();
                var result = rating.ReadJSON().OrderByDescending(el => el.UsedBobms).ToList();
                if (result.Any())
                {
                    var table = new ConsoleTable("Place", "Name", "Time", "Date", "Used Bombs");
                    for (int i = 0; i < result.Count && i < 10; i++) 
                        table.AddRow(i + 1, result[i].Name, result[i].Time + " s", result[i].Date, result[i].UsedBobms) ;
                    table.Write();
                }
                else
                    Console.WriteLine("You haven`t any data to show");
            }
    }
} 
