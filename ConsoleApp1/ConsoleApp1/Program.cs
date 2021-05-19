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
        static public Teleporter teleport = new Teleporter(new Cell(10, 2), new Cell(10, 25));
<<<<<<< HEAD
<<<<<<< HEAD

        static public Enemy enemy1 = new Enemy(new Cell(0, 0));
        static public Enemy enemy2 = new Enemy(new Cell(0, 0));
        static public Enemy enemy3 = new Enemy(new Cell(0, 0));
        static public Enemy enemy4 = new Enemy(new Cell(0, 0));
        static public Enemy enemy5 = new Enemy(new Cell(0, 0));
        static public Enemy enemy6 = new Enemy(new Cell(0, 0));
        static public Enemy enemy7 = new Enemy(new Cell(0, 0));

        static public bool level1 = false;
        static public bool level2 = false;
        static public bool level3 = false;
        static public bool isHard = false;
        static public bool isBack = false;
        private static bool changeColor = true;

        static private byte enemiesNumber;


=======
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
=======
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
        static void Main()
        {
            Console.CursorVisible = false;

<<<<<<< HEAD
            Media.titleSound.PlayLooping();
            string bomberManText = 
                   "\n"+
                   "\n" +
                   "\n" +
                   "\n" +
                   "\n" +
                   "            ▀█████████▄   ▄██████▄    ▄▄▄▄███▄▄▄▄   ▀█████████▄     ▄████████    ▄████████ \n" +
                   "              ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███   ███    ███   ███    ███ \n" +
                   "              ███    ███ ███    ███ ███   ███   ███   ███    ███   ███    █▀    ███    ███ \n" +
                   "             ▄███▄▄▄██▀  ███    ███ ███   ███   ███  ▄███▄▄▄██▀   ▄███▄▄▄      ▄███▄▄▄▄██▀ \n" +
                   "            ▀▀███▀▀▀██▄  ███    ███ ███   ███   ███ ▀▀███▀▀▀██▄  ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   \n" +
                   "              ███    ██▄ ███    ███ ███   ███   ███   ███    ██▄   ███    █▄  ▀███████████ \n" +
                   "              ███    ███ ███    ███ ███   ███   ███   ███    ███   ███    ███   ███    ███ \n" +
                   "            ▄█████████▀   ▀██████▀   ▀█   ███   █▀  ▄█████████▀    ██████████   ███    ███ \n" +
                   "                                                                                ███    ███ \n" +
                   "                                                 ▄▄▄▄███▄▄▄▄      ▄████████ ███▄▄▄▄        \n" +
                   "                                               ▄██▀▀▀███▀▀▀██▄   ███    ███ ███▀▀▀██▄      \n" +
                   "                                               ███   ███   ███   ███    ███ ███   ███      \n" +
                   "                                               ███   ███   ███   ███    ███ ███   ███      \n" +
                   "                                               ███   ███   ███ ▀███████████ ███   ███      \n" +
                   "                                               ███   ███   ███   ███    ███ ███   ███      \n" +
                   "                                               ███   ███   ███   ███    ███ ███   ███      \n" +
                   "                                                ▀█   ███   █▀    ███    █▀   ▀█   █▀       \n" +
                   "\n" +
                   "                                   press enter to start                                    \n" +
                   "\n" ;

            TextAnimation(bomberManText);
            Console.ReadLine();
            Console.Clear();

            string enterNameText =
                "\n" +
                "\n"+
            "       ██████  ██       █████  ██    ██ ███████ ██████         ███████ ███    ██ ████████ ███████ ██████  \n" +
            "       ██   ██ ██      ██   ██  ██  ██  ██      ██   ██        ██      ████   ██    ██    ██      ██   ██ \n" +
            "       ██████  ██      ███████   ████   █████   ██████         █████   ██ ██  ██    ██    █████   ██████  \n" +
            "       ██      ██      ██   ██    ██    ██      ██   ██        ██      ██  ██ ██    ██    ██      ██   ██ \n" +
            "       ██      ███████ ██   ██    ██    ███████ ██   ██ ▄█     ███████ ██   ████    ██    ███████ ██   ██ \n" +
            "                                                                                       \n" +
            "\n" +
            "               ██    ██  ██████  ██    ██ ██████      ███    ██  █████  ███    ███ ███████  \n" +
            "                ██  ██  ██    ██ ██    ██ ██   ██     ████   ██ ██   ██ ████  ████ ██            \n" +
            "                 ████   ██    ██ ██    ██ ██████      ██ ██  ██ ███████ ██ ████ ██ █████              \n" +
            "                  ██    ██    ██ ██    ██ ██   ██     ██  ██ ██ ██   ██ ██  ██  ██ ██                 \n" +
            "                  ██     ██████   ██████  ██   ██     ██   ████ ██   ██ ██      ██ ███████           \n";
            Console.WriteLine(enterNameText);
            Console.SetCursorPosition(50,16);
            Player.name = Console.ReadLine();
            Console.Clear();

            Media.titleSound.Stop();
            bool gameIsActive = true;
            while (gameIsActive)
            {
                Media.mainTheme.PlayLooping();
                Menu.MakeMenu(Menu.menu);
                Console.Clear();
                
                if (Menu.currentSection == 0)
                {
                    isBack = false;
                    Menu.MakeMenu(Menu.levelSelection);
                    Console.Clear();
                    switch (Menu.currentSection)
                    {
                        case 0:
                            level1 = true;
                            break;
                        case 1:
                            level2 = true;
                            break;
                        case 2:
                            level3 = true;
                            break;
                        case 3:
                            isBack = true;
                            Menu.currentSection = 0;
                            continue;                        
                    }
                    if (!isBack)                    
                        Game();                         
                }
                else if (Menu.currentSection == 1)
=======
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

            Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadLine();
            Console.Clear();
            sound0.Stop();

            
            Plane.position.X = 25;
            Plane.position.Y = 29;

            Player.position.X = 1;
            Player.position.Y = 3;

            Enemy enemy1 = new Enemy(new Cell(9 , 26));
            Enemy enemy2 = new Enemy(new Cell(20, 2));

            enemies.Add(enemy1);
            enemies.Add(enemy2);            

            Plane.MakeField();
            Console.ResetColor();

            while (Player.isAlive && enemies.Count != 0)
            {
                DrawBombs();
                DrawPlayerMovement();
                DrawEnemyMovement();
                TeleporeterDraw();
                Thread.Sleep(150);
            }
            Thread.Sleep(100);
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
<<<<<<< HEAD
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
=======
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(str);
                    Thread.Sleep(500);
<<<<<<< HEAD
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
<<<<<<< HEAD
                    switch (Menu.currentSection)
                    {
                        case 0:
                            Menu.ViewControls();
                            Console.Clear();
                            Menu.currentSection = 1;
                            Menu.isSelected = true;
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
                                case 3:
                                    Menu.currentSection = 1;
                                    Menu.isSelected = true;
                                    break;
                            }
                            continue;
                        case 2:
                            Menu.MakeMenu(Menu.difficultySeceltion);
                            Console.Clear();
                            switch (Menu.currentSection)
                            {
                                case 0:
                                    isHard = false; ;
                                    break;
                                case 1:
                                    isHard = true;
                                    break;
                                case 2:
                                    Menu.currentSection = 1;
                                    Menu.isSelected = true;
                                    break;
                            }
                            continue ;
                        case 3:
                            Menu.currentSection = 1;
                            continue;
                    }                                  
                }
                else if(Menu.currentSection == 2)
                {
                   /* DrawRating();*/
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (Menu.currentSection == 3)
                {
                    Console.SetWindowSize(100, 30);
                    string str = ("\n"+
                                  "\n" +
                                  "\n" +
                                  "\n" +
                                  "            ▀█████████▄  ▄██   ▄      ▄████████    \n" +
                                  "              ███    ███ ███   ██▄   ███    ███    \n" +
                                  "              ███    ███ ███▄▄▄███   ███    █▀     \n" +
                                  "             ▄███▄▄▄██▀  ▀▀▀▀▀▀███  ▄███▄▄▄        \n" +
                                  "            ▀▀███▀▀▀██▄  ▄██   ███ ▀▀███▀▀▀       \n" +
                                  "              ███    ██▄ ███   ███   ███    █▄    \n" +
                                  "              ███    ███ ███   ███   ███    ███   \n" +
                                  "            ▄█████████▀   ▀█████▀    ██████████   \n" +
                                  "\n" +
                                  "                                            ▀█████████▄  ▄██   ▄      ▄████████  \n" +
                                  "                                             ███    ███ ███   ██▄   ███    ███   \n" +
                                  "                                             ███    ███ ███▄▄▄███   ███    █▀    \n" +
                                  "                                            ▄███▄▄▄██▀  ▀▀▀▀▀▀███  ▄███▄▄▄       \n" +
                                  "                                           ▀▀███▀▀▀██▄  ▄██   ███ ▀▀███▀▀▀      \n" +
                                  "                                             ███    ██▄ ███   ███   ███    █▄   \n" +
                                  "                                             ███    ███ ███   ███   ███    ███  \n" +
                                  "                                           ▄█████████▀   ▀█████▀    ██████████ \n");
                    
                    TextAnimation(str);
                    gameIsActive = false;
                }

                Console.ReadKey();
                Console.ResetColor();
                ResetLevel();
=======
                }
            }
            if (enemies.Count == 0 && Player.isAlive)
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
                                  "          ■■     ■■■■     ■■■■■               ■■       ■■        ■   ■    ■     ■■■             \n" +
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
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
            }
=======
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str);
                    Thread.Sleep(500);
                    Console.Clear();
                }
            }
            if (enemies.Count == 0 && Player.isAlive)
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
                                  "          ■■     ■■■■     ■■■■■               ■■       ■■        ■   ■    ■     ■■■             \n" +
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
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
                Console.ReadKey();
        }

        static private void Game()
        {
            Media.mainTheme.Stop();
            Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;

            Plane.position.X = 25;
            Plane.position.Y = 29;

            Player.position.X = 9;
            Player.position.Y = 3;

            enemy1.position.X = 9;
            enemy1.position.Y = 25;

            enemy2.position.X = 10;
            enemy2.position.Y = 26;

            if (level3)
            {
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

                enemies.Add(enemy3);
                enemies.Add(enemy4);
                enemies.Add(enemy5);
                enemies.Add(enemy6);
                enemies.Add(enemy7);
            }
            
            enemies.Add(enemy1);
            enemies.Add(enemy2);

            enemiesNumber = (byte)enemies.Count();

            Plane.MakeField();
            Console.ResetColor();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (Player.isAlive && enemies.Count != 0)
            {
                DrawBombs();
                DrawPlayerMovement();
                DrawEnemyMovement();
                TeleporeterDraw();
                DrawEnemyLives();
                Thread.Sleep(3 * gameSpeed);
            }
            stopWatch.Stop();
            Thread.Sleep(100);
            Console.ResetColor();
            Console.Clear();

            if (!Player.isAlive)
            {
                Media.gameOverSound.PlayLooping();

                string loseText = (
                    "\n" +
                    "\n" +
                    "\n" +
                    "\n" +
                   "            ▄██████▄     ▄████████   ▄▄▄▄███▄▄▄▄      ▄████████                                   \n" +
                   "           ███    ███   ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███                                   \n" +
                   "           ███    █▀    ███    ███ ███   ███   ███   ███    █▀                                    \n" +
                   "          ▄███          ███    ███ ███   ███   ███  ▄███▄▄▄                                       \n" +
                   "         ▀▀███ ████▄  ▀███████████ ███   ███   ███ ▀▀███▀▀▀                                       \n" +
                   "           ███    ███   ███    ███ ███   ███   ███   ███    █▄                                    \n" +
                   "           ███    ███   ███    ███ ███   ███   ███   ███    ███                                   \n" +
                   "           ████████▀    ███    █▀   ▀█   ███   █▀    ██████████                                   \n" +
                   "\n" +
                   "                                                     ▄██████▄   ▄█    █▄     ▄████████    ▄████████ \n" +
                   "                                                    ███    ███ ███    ███   ███    ███   ███    ███ \n" +
                   "                                                    ███    ███ ███    ███   ███    █▀    ███    ███ \n" +
                   "                                                    ███    ███ ███    ███  ▄███▄▄▄      ▄███▄▄▄▄██▀ \n" +
                   "                                                    ███    ███ ███    ███ ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   \n" +
                   "                                                    ███    ███ ███    ███   ███    █▄  ▀███████████ \n" +
                   "                                                    ███    ███ ███    ███   ███    ███   ███    ███ \n" +
                   "                                                     ▀██████▀   ▀██████▀    ██████████   ███    ███ \n" +
                   "                                                                                         ███    ███ \n");
                
                TextAnimation(loseText);
                Media.gameOverSound.Stop();
                
            }
            if (enemies.Count == 0 && Player.isAlive)
            {
                Media.mainTheme.PlayLooping();
                string winText = (
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "               ▄██   ▄    ▄██████▄  ███    █▄                      \n" +
                "               ███   ██▄ ███    ███ ███    ███                     \n" +
                "               ███▄▄▄███ ███    ███ ███    ███                     \n" +
                "               ▀▀▀▀▀▀███ ███    ███ ███    ███                     \n" +
                "               ▄██   ███ ███    ███ ███    ███                     \n" +
                "               ███   ███ ███    ███ ███    ███                     \n" +
                "               ███   ███ ███    ███ ███    ███                     \n" +
                "                ▀█████▀   ▀██████▀  ████████▀                      \n" +
                "\n" +
                "                                    ▄█     █▄   ▄█  ███▄▄▄▄   \n" +
                "                                   ███     ███ ███  ███▀▀▀██▄ \n" +
                "                                   ███     ███ ███▌ ███   ███ \n" +
                "                                   ███     ███ ███▌ ███   ███ \n" +
                "                                   ███     ███ ███▌ ███   ███ \n" +
                "                                   ███     ███ ███  ███   ███ \n" +
                "                                   ███ ▄█▄ ███ ███  ███   ███ \n" +
                "                                    ▀███▀███▀  █▀    ▀█   █▀  \n");

                TimeSpan time = stopWatch.Elapsed;
               /* var newRating = new WorkWithFile();
                newRating.AddResults(new GameResults(Player.name, (time.Seconds).ToString(), DateTime.Now, Player.usedBombs));*/

                TextAnimation(winText);
                Media.mainTheme.Stop();
                }
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
<<<<<<< HEAD
<<<<<<< HEAD
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ResetColor();
=======
                    Console.SetCursorPosition(0, Plane.position.X);
                    Console.WriteLine($"Score: {Player.score}");
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
=======
                    Console.SetCursorPosition(0, Plane.position.X);
                    Console.WriteLine($"Score: {Player.score}");
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
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
                if (enemies.Any(el => el.isAlive))
                {
                    Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(enemies[i].position.Y,
                                              enemies[i].position.X);
                    Console.Write(" ");

                    enemies[i].OnMove(enemies[i]);

                    Console.SetCursorPosition(enemies[i].position.Y,
                                              enemies[i].position.X);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("@");
                    Console.SetCursorPosition(0, Plane.position.X + 1);
                    Console.ResetColor();
                }
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
        
        static private void DrawEnemyLives()
        {
            Console.SetCursorPosition(0 , Plane.position.X);
            Console.Write($"enemies alive: {enemies.Count}/{enemiesNumber}");
        }
        static private void TeleporeterDraw()
=======
=======
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
        static void TeleporeterDraw()
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
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
<<<<<<< HEAD
<<<<<<< HEAD

        
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
                Console.ResetColor();
            }
        }
        private static void ResetLevel()
        {
            level1 = false;
            level2 = false;
            level3 = false;

            Plane.walls.Clear();
            Plane.bricks.Clear();
            Plane.empty.Clear();

            Player.usedBombs = 0;
            Player.isAlive = true;
            Player.bombs.Clear();

            enemies.Clear();

            Menu.currentSection = 0;
        }
        /*public static void DrawRating()
        {
            var rating = new WorkWithFile();
            var result = rating.ReadJSON().OrderByDescending(el => el.UsedBobms).ToList();
            if (result.Any())
            {
                var table = new ConsoleTable("Place","Name","Time","Date","Used Bombs");
                for (int i = 0; i < result.Count && i < 10; i++) 
                    table.AddRow(i + 1, result[i].Name, result[i].Time + " s", result[i].Date, result[i].UsedBobms) ;
                table.Write();
            }
            else
                Console.WriteLine("You haven`t any data to show");
        }*/
=======
        private static bool changeColor = true;
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
=======
        private static bool changeColor = true;
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
    }
}