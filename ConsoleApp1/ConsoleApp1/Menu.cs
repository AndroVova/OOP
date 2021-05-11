using System;
using System.Threading;

namespace ConsoleApp1
{
    static public class Menu
    {
        static private int position;
        static public bool isSelected = false;
        static public int currentSection = 0;
        static private string startGameText = 
                                   ("       ■■  ■■■■■     ■   ■■■■  ■■■■■       ■■■       ■   ■   ■   ■■■■      \n" +
                                    "      ■      ■     ■ ■   ■   ■   ■        ■        ■ ■   ■■ ■■   ■         \n" +
                                    "       ■     ■    ■  ■   ■       ■        ■  ■    ■  ■   ■ ■ ■   ■■■       \n" +
                                    "        ■    ■    ■■■■   ■       ■        ■   ■   ■■■■   ■   ■   ■         \n" +
                                    "      ■■■    ■    ■  ■   ■       ■         ■■■    ■  ■   ■   ■   ■■■■      \n");

        static private string settingsText = 
                              ("       ■■   ■■■■ ■■■■■ ■■■■■  ■   ■■■■     ■■■     ■■           \n" +
                               "      ■     ■      ■     ■    ■   ■   ■   ■       ■             \n" +
                               "       ■    ■■■    ■     ■    ■   ■   ■   ■  ■     ■            \n" +
                               "        ■   ■      ■     ■    ■   ■   ■   ■   ■     ■           \n" +
                               "      ■■■   ■■■■   ■     ■    ■   ■   ■    ■■■    ■■■           \n");

        static private string exitText = 
                          ("      ■■■■  ■   ■   ■  ■■■■■        \n" +
                           "      ■      ■ ■    ■    ■          \n" +
                           "      ■■■     ■     ■    ■          \n" +
                           "      ■      ■ ■    ■    ■          \n" +
                           "      ■■■■  ■   ■   ■    ■          \n");

        static private string controlsText = ("      ■■■  ■■■■  ■■■  ■■■■■  ■■■■   ■■■■   ■      ■■   \n" +
                                              "      ■    ■  ■  ■  ■   ■    ■   ■  ■  ■   ■     ■     \n" +
                                              "      ■    ■  ■  ■  ■   ■    ■      ■  ■   ■      ■    \n" +
                                              "      ■    ■  ■  ■  ■   ■    ■      ■  ■   ■       ■   \n" +
                                              "      ■■■  ■■■■  ■  ■   ■    ■      ■■■■   ■■■■  ■■■   \n");

        static private string gameSpeedSettingText = ("       ■■■       ■   ■   ■   ■■■■      ■■   ■■■■   ■■■■   ■■■■   ■■■■   \n" +
                                                      "      ■        ■ ■   ■■ ■■   ■        ■     ■   ■  ■      ■      ■   ■  \n" +
                                                      "      ■  ■    ■  ■   ■ ■ ■   ■■■       ■    ■■■■   ■■■    ■■■    ■   ■  \n" +
                                                      "      ■   ■   ■■■■   ■   ■   ■          ■   ■      ■      ■      ■   ■  \n" +
                                                      "       ■■■    ■  ■   ■   ■   ■■■■     ■■■   ■      ■■■■   ■■■■   ■■■■   \n");

        static private string highSpeedText = ("      ■   ■   ■    ■■■   ■   ■   \n" +
                                               "      ■   ■   ■   ■      ■   ■   \n" +
                                               "      ■■■■■   ■   ■  ■   ■■■■■   \n" +
                                               "      ■   ■   ■   ■   ■  ■   ■   \n" +
                                               "      ■   ■   ■    ■■■   ■   ■   \n");

        static private string normalSpeedText = ("      ■■■■    ■■■   ■■■   ■   ■     ■  ■       \n" +
                                                 "      ■   ■  ■   ■  ■  ■  ■■ ■■   ■ ■  ■      \n" +
                                                 "      ■   ■  ■   ■  ■■■   ■ ■ ■  ■  ■  ■      \n" +
                                                 "      ■   ■  ■   ■  ■ ■   ■   ■  ■■■■  ■      \n" +
                                                 "      ■   ■   ■■■   ■  ■  ■   ■  ■  ■  ■■■■■  \n");

        static private string slowSpeedText = ("       ■■   ■       ■■■   ■■          ■■\n" +
                                               "      ■     ■      ■   ■   ■■        ■■  \n" +
                                               "       ■    ■      ■   ■    ■■  ■■  ■■ \n" +
                                               "        ■   ■      ■   ■     ■■■  ■■■  \n" +
                                               "      ■■■   ■■■■■   ■■■       ■    ■   \n");


        static public string[] menu = new string[] {startGameText, settingsText, exitText };
        static public string[] settings = new string[] { controlsText, gameSpeedSettingText, exitText };
        static public string[] gameSpeedSettings = new string[] { highSpeedText, normalSpeedText, slowSpeedText };

        static public void MakeMenu(string[] items)
        {
            foreach(string i in items)
            {
                Console.WriteLine(i);
            }


            ViewCurrentSection(items);
            while (!isSelected)
            {
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                MovementInMenu(key);
                ViewCurrentSection(items);                
            }
            isSelected = false;
            Console.ResetColor();
        }

        static public void ViewCurrentSection(string[] items)
        {
            while (!Console.KeyAvailable && !isSelected)
            {
                if (currentSection == 0)
                    position = 0;
                else if (currentSection == 1)
                    position = 6;
                else if (currentSection == 2)
                    position = 12;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, position);
                Console.Write(items[currentSection]);
                Thread.Sleep(500);

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, position);
                Console.Write(items[currentSection]);
                Thread.Sleep(500);    
            }
        }
        static public void MovementInMenu(ConsoleKeyInfo key)
        {
            switch (key.Key) 
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        currentSection--;
                        if (currentSection < 0)
                            currentSection = 2;
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        currentSection++;
                        if (currentSection > 2)
                            currentSection = 0;
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        isSelected = true;
                        break;
                    }
                default:
                    break;
                                     

            }

        }

        static public void ViewControls()
        {
            Console.Write
                          ("      ■  ■  ■■■■       ■      ■■           ■■     ■      ■                               \n" +
                           "      ■  ■  ■   ■      ■■      ■■         ■■     ■      ■■■                              \n" +
                           "      ■  ■  ■■■■    ■■■■■■      ■■  ■■■  ■■     ■      ■■■■■                            \n" +
                           "      ■  ■  ■          ■■        ■■■■ ■■■■     ■         ■                              \n" +
                           "       ■■   ■          ■          ■■   ■■     ■          ■                              \n" +
                           "                                                                                        \n" +
                           "      ■     ■■■■  ■■■■ ■■■■■     ■             ■       ■     ■                          \n" +
                           "      ■     ■     ■      ■       ■■          ■ ■      ■     ■■                          \n" +
                           "      ■     ■■■   ■■■    ■    ■■■■■■        ■  ■     ■     ■■■■■■                       \n" +
                           "      ■     ■     ■      ■       ■■         ■■■■    ■       ■■                          \n" +
                           "      ■■■■  ■■■■  ■      ■       ■          ■  ■   ■         ■                          \n" +
                           "                                                                                        \n" +
                           "      ■■■    ■■■  ■■          ■■  ■■■■         ■        ■■       ■    ■                 \n" +
                           "      ■  ■  ■   ■  ■■        ■■   ■   ■        ■■      ■        ■     ■                 \n" +
                           "      ■  ■  ■   ■   ■■  ■■  ■■    ■   ■     ■■■■■■      ■      ■    ■■■■■               \n" +
                           "      ■  ■  ■   ■    ■■■  ■■■     ■   ■        ■■        ■    ■      ■■■                \n" +
                           "      ■■■    ■■■      ■    ■      ■   ■        ■       ■■■   ■        ■                  \n" +
                           "                                                                                        \n" +
                           "      ■■■   ■   ■■■   ■  ■ ■■■■■      ■      ■■■       ■      ■                         \n" +
                           "      ■  ■  ■  ■      ■  ■   ■        ■■     ■  ■     ■       ■■                        \n" +
                           "      ■■■   ■  ■  ■   ■■■■   ■     ■■■■■■    ■  ■    ■     ■■■■■■                        \n" +
                           "      ■ ■   ■  ■   ■  ■  ■   ■        ■■     ■  ■   ■         ■■                        \n" +
                           "      ■  ■  ■   ■■■   ■  ■   ■        ■      ■■■   ■          ■                         \n" +
                           "                                                                                        \n" +
                           "      ■■■    ■■■   ■■   ■■  ■■■       ■      ■■■■■                                       \n" +
                           "      ■  ■  ■   ■  ■ ■■■ ■  ■  ■      ■■     ■                                           \n" +
                           "      ■■■■  ■   ■  ■  ■  ■  ■■■■   ■■■■■■    ■■■■                                       \n" +
                           "      ■  ■  ■   ■  ■     ■  ■  ■      ■■     ■                                          \n" +
                           "      ■■■    ■■■   ■     ■  ■■■       ■      ■■■■■                                      \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("                                                                                 \n" +
                           "      ■■■■■■■■                     ■■■■   ■        ■  ■   ■  ■■■■  ■■■       \n" +
                           "     ■■■ ■■ ■■■                    ■   ■  ■      ■ ■   ■  ■  ■     ■  ■      \n" +
                           "    ■■■ ■■■■ ■■■        ■■■■■■     ■■■■   ■     ■  ■    ■■■  ■■■   ■■■           \n" +
                           "     ■■■    ■■■                    ■      ■     ■■■■      ■  ■     ■ ■     \n" +
                           "      ■■■■■■■■                     ■      ■■■■  ■  ■    ■■   ■■■■  ■  ■    \n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("                                                                                 \n" +
                           "      ■■■■■■■■                     ■■■■  ■■■■   ■■■■  ■■   ■■  ■   ■   \n" +
                           "     ■■■ ■■ ■■■                    ■     ■   ■  ■     ■ ■■■ ■   ■  ■   \n" +
                           "    ■■■ ■■■■ ■■■        ■■■■■■     ■■■   ■   ■  ■■■   ■  ■  ■    ■■■   \n" +
                           "     ■■■    ■■■                    ■     ■   ■  ■     ■     ■      ■   \n" +
                           "      ■■■■■■■■                     ■■■■  ■   ■  ■■■■  ■     ■    ■■    \n");
            Console.ResetColor();
            Console.SetCursorPosition(0,0);
            Console.ReadLine();
        }

    }
}
