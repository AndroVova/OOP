using System;
using System.Threading;

namespace ConsoleApp1
{
    static public class Menu
    {
        static private int position;

        static public bool isSelected = false;
        static public bool isBack = false;

        static public int currentSection = 0;

        static private string startGameText =
                                   ("       ███████ ████████  █████  ██████  ████████      ██████   █████  ███    ███ ███████ \n" +
                                    "       ██         ██    ██   ██ ██   ██    ██        ██       ██   ██ ████  ████ ██      \n" +
                                    "       ███████    ██    ███████ ██████     ██        ██   ███ ███████ ██ ████ ██ █████   \n" +
                                    "            ██    ██    ██   ██ ██   ██    ██        ██    ██ ██   ██ ██  ██  ██ ██      \n" +
                                    "       ███████    ██    ██   ██ ██   ██    ██         ██████  ██   ██ ██      ██ ███████ \n");



        static private string settingsText =
                              ("       ███████ ███████ ████████ ████████ ██ ███    ██  ██████  ███████  \n" +
                               "       ██      ██         ██       ██    ██ ████   ██ ██       ██       \n" +
                               "       ███████ █████      ██       ██    ██ ██ ██  ██ ██   ███ ███████  \n" +
                               "            ██ ██         ██       ██    ██ ██  ██ ██ ██    ██      ██  \n" +
                               "       ███████ ███████    ██       ██    ██ ██   ████  ██████  ███████  \n");



        static private string exitText =
                          ("       ███████ ██   ██ ██ ████████  \n" +
                           "       ██       ██ ██  ██    ██     \n" +
                           "       █████     ███   ██    ██     \n" +
                           "       ██       ██ ██  ██    ██     \n" +
                           "       ███████ ██   ██ ██    ██     \n");

        static private string controlsText = ("       ██████  ██████  ███    ██ ████████ ██████   ██████  ██      ███████    \n" +
                                              "      ██      ██    ██ ████   ██    ██    ██   ██ ██    ██ ██      ██         \n" +
                                              "      ██      ██    ██ ██ ██  ██    ██    ██████  ██    ██ ██      ███████    \n" +
                                              "      ██      ██    ██ ██  ██ ██    ██    ██   ██ ██    ██ ██           ██    \n" +
                                              "       ██████  ██████  ██   ████    ██    ██   ██  ██████  ███████ ███████    \n");


        static private string gameSpeedSettingText = (
        "       ██████   █████  ███    ███ ███████     ███████ ██████  ███████ ███████ ██████   \n" +
        "      ██       ██   ██ ████  ████ ██          ██      ██   ██ ██      ██      ██   ██  \n" +
        "      ██   ███ ███████ ██ ████ ██ █████       ███████ ██████  █████   █████   ██   ██  \n" +
        "      ██    ██ ██   ██ ██  ██  ██ ██               ██ ██      ██      ██      ██   ██  \n" +
        "       ██████  ██   ██ ██      ██ ███████     ███████ ██      ███████ ███████ ██████   \n");

        static private string highSpeedText =
            (
        "      ██   ██ ██  ██████  ██   ██    \n" +
        "      ██   ██ ██ ██       ██   ██    \n" +
        "      ███████ ██ ██   ███ ███████    \n" +
        "      ██   ██ ██ ██    ██ ██   ██    \n" +
        "      ██   ██ ██  ██████  ██   ██    \n");

        static private string normalSpeedText =
            (
        "      ███    ██  ██████  ██████  ███    ███  █████  ██       \n" +
        "      ████   ██ ██    ██ ██   ██ ████  ████ ██   ██ ██       \n" +
        "      ██ ██  ██ ██    ██ ██████  ██ ████ ██ ███████ ██       \n" +
        "      ██  ██ ██ ██    ██ ██   ██ ██  ██  ██ ██   ██ ██       \n" +
        "      ██   ████  ██████  ██   ██ ██      ██ ██   ██ ███████  \n");


        static private string slowSpeedText = (

        "      ███████ ██       ██████  ██     ██    \n" +
        "      ██      ██      ██    ██ ██     ██    \n" +
        "      ███████ ██      ██    ██ ██  █  ██    \n" +
        "           ██ ██      ██    ██ ██ ███ ██    \n" +
        "      ███████ ███████  ██████   ███ ███     \n");

        static private string resultsText = (
        "       ██████  ███████ ███████ ██    ██ ██      ████████ ███████ \n" +
        "       ██   ██ ██      ██      ██    ██ ██         ██    ██      \n" +
        "       ██████  █████   ███████ ██    ██ ██         ██    ███████ \n" +
        "       ██   ██ ██           ██ ██    ██ ██         ██         ██ \n" +
        "       ██   ██ ███████ ███████  ██████  ███████    ██    ███████\n");

        static private string backText =
        "       ██████   █████   ██████ ██   ██ \n" +
        "       ██   ██ ██   ██ ██      ██  ██  \n" +
        "       ██████  ███████ ██      █████   \n" +
        "       ██   ██ ██   ██ ██      ██  ██  \n" +
        "       ██████  ██   ██  ██████ ██   ██ \n";

        static private string level_1_Text =
        "       ██      ███████ ██    ██ ███████ ██           ██   \n" +
        "       ██      ██      ██    ██ ██      ██          ███   \n" +
        "       ██      █████   ██    ██ █████   ██           ██   \n" +
        "       ██      ██       ██  ██  ██      ██           ██   \n" +
        "       ███████ ███████   ████   ███████ ███████      ██   \n";

        static private string level_2_Text =
        "       ██      ███████ ██    ██ ███████ ██          ██████  \n" +
        "       ██      ██      ██    ██ ██      ██               ██ \n" +
        "       ██      █████   ██    ██ █████   ██           █████  \n" +
        "       ██      ██       ██  ██  ██      ██          ██      \n" +
        "       ███████ ███████   ████   ███████ ███████     ███████ \n";

        static private string level_3_Text =
        "       ██      ███████ ██    ██ ███████ ██          ██████  \n" +
        "       ██      ██      ██    ██ ██      ██               ██ \n" +
        "       ██      █████   ██    ██ █████   ██           █████  \n" +
        "       ██      ██       ██  ██  ██      ██               ██ \n" +
        "       ███████ ███████   ████   ███████ ███████     ██████  \n";

        static private string hardLevelText =
        "       ██   ██  █████  ██████  ██████  \n" +
        "       ██   ██ ██   ██ ██   ██ ██   ██ \n" +
        "       ███████ ███████ ██████  ██   ██ \n" +
        "       ██   ██ ██   ██ ██   ██ ██   ██ \n" +
        "       ██   ██ ██   ██ ██   ██ ██████  \n";

        static private string EasyLevelText =
        "       ███████  █████  ███████ ██    ██ \n" +
        "       ██      ██   ██ ██       ██  ██  \n" +
        "       █████   ███████ ███████   ████   \n" +
        "       ██      ██   ██      ██    ██    \n" +
        "       ███████ ██   ██ ███████    ██   \n";

        static private string DifficultyText =
        "       ██████  ██ ███████ ███████ ██  ██████ ██    ██ ██      ████████ ██    ██ \n" +
        "       ██   ██ ██ ██      ██      ██ ██      ██    ██ ██         ██     ██  ██  \n" +
        "       ██   ██ ██ █████   █████   ██ ██      ██    ██ ██         ██      ████   \n" +
        "       ██   ██ ██ ██      ██      ██ ██      ██    ██ ██         ██       ██    \n" +
        "       ██████  ██ ██      ██      ██  ██████  ██████  ███████    ██       ██    \n";
        static private string ByeText = ("\n" +
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
        static public string bomberManText =
                   "\n" +
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
                   "\n";


        static public string enterNameText =
        "\n" +
        "\n" +
        "       ██████  ██       █████  ██    ██ ███████ ██████         ███████ ███    ██ ████████ ███████ ██████  \n" +
        "       ██   ██ ██      ██   ██  ██  ██  ██      ██   ██        ██      ████   ██    ██    ██      ██   ██ \n" +
        "       ██████  ██      ███████   ████   █████   ██████         █████   ██ ██  ██    ██    █████   ██████  \n" +
        "       ██      ██      ██   ██    ██    ██      ██   ██        ██      ██  ██ ██    ██    ██      ██   ██ \n" +
        "       ██      ███████ ██   ██    ██    ███████ ██   ██ ▄█     ███████ ██   ████    ██    ███████ ██   ██ \n" +
        "\n" +
        "\n" +
        "               ██    ██  ██████  ██    ██ ██████      ███    ██  █████  ███    ███ ███████  \n" +
        "                ██  ██  ██    ██ ██    ██ ██   ██     ████   ██ ██   ██ ████  ████ ██       \n" +
        "                 ████   ██    ██ ██    ██ ██████      ██ ██  ██ ███████ ██ ████ ██ █████    \n" +
        "                  ██    ██    ██ ██    ██ ██   ██     ██  ██ ██ ██   ██ ██  ██  ██ ██       \n" +
        "                  ██     ██████   ██████  ██   ██     ██   ████ ██   ██ ██      ██ ███████  \n";
         static public string loseText = (
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

        static public string winText = (
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

        static public string[] menu = new string[] {startGameText, settingsText, resultsText, exitText};
        static public string[] settings = new string[] { controlsText, gameSpeedSettingText, DifficultyText, backText };
        static public string[] gameSpeedSettings = new string[] { highSpeedText, normalSpeedText, slowSpeedText,backText };
        static public string[] levelSelection = new string[] { level_1_Text, level_2_Text, level_3_Text, backText };
        static public string[] difficultySeceltion = new string[] { EasyLevelText, hardLevelText, backText };


        static public void MakeMenu(string[] items)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach(string i in items)
            {
                Console.WriteLine(i);
            }
            Console.SetCursorPosition(0, 0);


            ViewCurrentSection(items);
            while (!isSelected)
            {
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                MovementInMenu(key, items);
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
                    position = 2;
                else 
                    position = currentSection * 6 + 2;

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
        static public void MovementInMenu(ConsoleKeyInfo key , string[] items)
        {
            switch (key.Key) 
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        currentSection--;
                        if (currentSection < 0)
                            currentSection = items.Length - 1;
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        currentSection++;
                        if (currentSection > items.Length - 1)
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
                          ("\n"+
                           "\n" +
                           "           ██    ██ ██████                            ██     ██     ██ ████      \n" +
                           "           ██    ██ ██   ██                           ██     ██    ██ ██████     \n" +
                           "           ██    ██ ██████                  █████     ██  █  ██   ██    ██       \n" +
                           "           ██    ██ ██                                ██ ███ ██  ██     ██       \n" +
                           "            ██████  ██                                 ███ ███  ██      ██       \n" +
                           "\n" +
                           "\n" +
                           "   ██      ███████ ███████ ████████                    █████      ██   ██       \n" +
                           "   ██      ██      ██         ██                      ██   ██    ██   ██        \n" +
                           "   ██      █████   █████      ██            █████     ███████   ██   ███████    \n" +
                           "   ██      ██      ██         ██                      ██   ██  ██     ██        \n" +
                           "   ███████ ███████ ██         ██                      ██   ██ ██       ██       \n" +
                           "\n"+
                           "\n" +
                           "   ██████   ██████  ██     ██ ███    ██               ███████     ██ ██         \n" +
                           "   ██   ██ ██    ██ ██     ██ ████   ██               ██         ██  ██         \n" +
                           "   ██   ██ ██    ██ ██  █  ██ ██ ██  ██     █████     ███████   ██   ██         \n" +
                           "   ██   ██ ██    ██ ██ ███ ██ ██  ██ ██                    ██  ██  ██████       \n" +
                           "   ██████   ██████   ███ ███  ██   ████               ███████ ██    ████        \n" +
                           "\n" +
                           "\n" +
                           "   ██████  ██  ██████  ██   ██ ████████               ██████      ██    ██   \n" +
                           "   ██   ██ ██ ██       ██   ██    ██                  ██   ██    ██      ██  \n" +
                           "   ██████  ██ ██   ███ ███████    ██        █████     ██   ██   ██   ███████ \n" +
                           "   ██   ██ ██ ██    ██ ██   ██    ██                  ██   ██  ██        ██  \n" +
                           "   ██   ██ ██  ██████  ██   ██    ██                  ██████  ██        ██   \n" +
                           "\n" +
                           "\n" +
                           "   ██████   ██████  ███    ███ ██████                ███████ \n" +
                           "   ██   ██ ██    ██ ████  ████ ██   ██               ██      \n" +
                           "   ██████  ██    ██ ██ ████ ██ ██████      █████     █████   \n" +
                           "   ██   ██ ██    ██ ██  ██  ██ ██   ██               ██      \n" +
                           "   ██████   ██████  ██      ██ ██████                ███████ \n" );
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                                                                                 \n" +
                               "      ■■■■■■■■                     ■■■■   ■        ■  ■   ■  ■■■■  ■■■       \n" +
                               "     ■■■ ■■ ■■■                    ■   ■  ■      ■ ■   ■  ■  ■     ■  ■      \n" +
                               "    ■■■ ■■■■ ■■■        ■■■■■■     ■■■■   ■     ■  ■    ■■■  ■■■   ■■■           \n" +
                               "     ■■■    ■■■                    ■      ■     ■■■■      ■  ■     ■ ■     \n" +
                               "      ■■■■■■■■                     ■      ■■■■  ■  ■    ■■   ■■■■  ■  ■    \n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("                                                                        \n" +
                               "      ■■■■■■■■                     ■■■■  ■■■■   ■■■■  ■■   ■■  ■   ■   \n" +
                               "     ■■■ ■■ ■■■                    ■     ■   ■  ■     ■ ■■■ ■   ■  ■   \n" +
                               "    ■■■ ■■■■ ■■■        ■■■■■■     ■■■   ■   ■  ■■■   ■  ■  ■    ■■■   \n" +
                               "     ■■■    ■■■                    ■     ■   ■  ■     ■     ■      ■   \n" +
                               "      ■■■■■■■■                     ■■■■  ■   ■  ■■■■  ■     ■    ■■    \n");
                Console.ResetColor();
                Console.SetCursorPosition(0,0);
                Console.ReadLine();
                Console.Clear();
                currentSection = 1;
                isSelected = true;
        }
        
        static public void MakeMenuStructure()
        {
            bool gameIsActive = true;
            while (gameIsActive)
            {
                Media.mainTheme.PlayLooping();
                MakeMenu(menu);
                Console.Clear();

                if (currentSection == 0)
                {
                    StartGameButton();
                    if(isBack)
                        continue;
                }
                else if (currentSection == 1)
                {
                    currentSection = 0;
                    MakeMenu(settings);
                    Console.Clear();
                    switch (currentSection)
                    {
                        case 0:
                            ViewControls();                            
                            continue;
                        case 1:
                            GameSpeedButton();
                            continue;
                        case 2:
                            DifficultyButton();
                            continue;
                        case 3:
                            currentSection = 1;
                            continue;
                    }
                }
                else if (currentSection == 2)
                {
                    Program.DrawRating();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (currentSection == 3)
                {
                    Console.SetWindowSize(100, 30);
                    Program.TextAnimation(ByeText);
                    gameIsActive = false;
                }

                Console.ReadKey();
                Console.ResetColor();
                Program.ResetLevel();
            }
        }

        static private void StartGameButton()
        {
            isBack = false;
            MakeMenu(levelSelection);
            Console.Clear();
            switch (currentSection)
            {
                case 0:
                    Program.level1 = true;
                    break;
                case 1:
                    Program.level2 = true;
                    break;
                case 2:
                    Program.level3 = true;
                    break;
                
                case 3:
                    isBack = true;
                    currentSection = 0;
                    break;
            }
            if (!isBack)
                Program.Game();
        }
        static private void GameSpeedButton()
        {
            MakeMenu(gameSpeedSettings);
            Console.Clear();
            switch (currentSection)

            {
                case 0:
                    Program.gameSpeed = 40;
                    break;
                case 1:
                    Program.gameSpeed = 60;
                    break;
                case 2:
                    Program.gameSpeed = 80;
                    break;
                case 3:
                    currentSection = 1;
                    isSelected = true;
                    break;
            }
        }
        static private void DifficultyButton()
        {
            MakeMenu(difficultySeceltion);
            Console.Clear();
            switch (currentSection)
            {
                case 0:
                    Program.isHard = false;
                    break;
                case 1:
                    Program.isHard = true;
                    break;
                case 2:
                    currentSection = 1;
                    isSelected = true;
                    break;
            }
        }
    }
}
