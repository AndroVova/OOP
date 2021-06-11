using System;
using System.IO;

namespace ConsoleApp1
{
    class Create
    {
        static public Cell position = new Cell(4,4);
        static public char[,] field;
        static public byte height;
        static public byte width;

        static private bool playerExists = false;
        static private bool teleportInExists = false;
        static private bool teleportOutExists = false;
        static public bool exit = false;

        static public int enemyExists = 0;



        static byte GetByteNumber()
        {
            byte number;
            do
            {
                if (height == 0)
                    Console.WriteLine("Enter Height:");
                else
                    Console.WriteLine("Enter Width:");
                number = Convert.ToByte(Console.ReadLine());
            } while (number > 255 || number < 10 );
            return number;
        }

        static public void CreateField()
        {
            char[,] arr = GetField();

            PaintBorder(arr);

            MakeControls();

            while (!exit)
                DrawCursor();
                
            Console.Clear();
            Console.CursorVisible = false;
            Console.Write("DO YOU WANNA SAVE IT?");
            Menu.MakeMenu(Menu.yesNoSelection);
            if (Menu.currentSection == (int)Menu.Sections.first)
            {
                SaveField(DataReader.ConvertToString(field));
            }
        }

        static public void MakeControls()
        {
            Console.ResetColor();
            Console.SetCursorPosition(width + 10, 2);
            Console.Write("PRESS TO PLANT");
            Console.SetCursorPosition(width + 10, 3);
            Console.Write("P - player");
            Console.SetCursorPosition(width + 10, 4);
            Console.Write("E - enemy");
            Console.SetCursorPosition(width + 10, 5);
            Console.Write("T - teleporter");
            Console.SetCursorPosition(width + 10, 6);
            Console.Write("H - wall");
            Console.SetCursorPosition(width + 10, 7);
            Console.Write("B - brick");
            Console.SetCursorPosition(width + 10, 8);
            Console.Write("C - clear");
            Console.SetCursorPosition(width + 10, 9);
            Console.Write("ESC - Exit");
        }
        static public char[,] GetField()
        {

            height = GetByteNumber();
            width = GetByteNumber();
            Console.Clear();

            field = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i < 1 || i == height - 1 ||
                        j < 2 || j >= width - 2)
                    {
                        field[i, j] = '#';
                    }
                    else
                        field[i, j] = ' ';
                }
            }
            return field;
        }

        static public void MoveCursor(ConsoleKeyInfo movement, char[,] arr)
        {
            switch (movement.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (CanMove(arr, -1, 0, position))
                    {
                        position.X--;
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (CanMove(arr, 0, -1, position))
                    {
                        position.Y--;
                    }
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (CanMove(arr, 1, 0, position))
                    {
                        position.X++;
                    }
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (CanMove(arr, 0, 1, position))
                    {
                        position.Y++;
                    }
                    break;
                case ConsoleKey.B:
                    ClearCell();
                    field[position.X, position.Y] = '░';
                    DrawSymbol('░', ConsoleColor.Black, ConsoleColor.White);
                    break;
                case ConsoleKey.H:
                    ClearCell();
                    field[position.X, position.Y] = 'W';
                    DrawSymbol(' ', ConsoleColor.White, ConsoleColor.Black);
                    break;
                case ConsoleKey.C:
                    ClearCell();
                    field[position.X, position.Y] = ' ';
                    DrawSymbol(' ', ConsoleColor.Black, ConsoleColor.Black);
                    break;
                case ConsoleKey.E:
                    ClearCell();
                    field[position.X, position.Y] = 'e';
                    DrawSymbol('☻', ConsoleColor.Black, ConsoleColor.Blue);
                    enemyExists++;
                    break;
                case ConsoleKey.P:
                    ClearCell();
                    if (!playerExists)
                    {
                        field[position.X, position.Y] = 'P';
                        DrawSymbol('☻', ConsoleColor.Black, ConsoleColor.Green);
                        playerExists = true;
                    }
                    break;
                case ConsoleKey.T:
                    ClearCell();
                    if (!teleportInExists)
                    {
                        field[position.X, position.Y] = 'T';                        
                        teleportInExists = true;
                    }
                    else if (!teleportOutExists)
                    {
                        field[position.X, position.Y] = 't';
                        teleportOutExists = true;
                    }
                    DrawSymbol('▀', ConsoleColor.Cyan, ConsoleColor.DarkMagenta);
                    break;
                case ConsoleKey.Escape:
                    Console.ForegroundColor = ConsoleColor.White;
                    ExitCheck();
                    break;
            }
        }
        static void ClearCell()
        {
            if (field[position.X, position.Y] == 'P')
                playerExists = false;
            if (field[position.X, position.Y] == 'T')
                teleportInExists = false;
            if (field[position.X, position.Y] == 't')
                teleportOutExists = false;
            if (field[position.X, position.Y] == 'e')
                enemyExists--;
        }
        static private void ExitCheck()
        {
            if (playerExists && enemyExists > 0)
                exit = true;
            else if (!playerExists && enemyExists == 0)
            {
                Console.SetCursorPosition(1, height + 1);
                Console.WriteLine("Plant enemy and player");
            }
            else if (!playerExists)
            {
                Console.SetCursorPosition(1, height + 1);
                Console.WriteLine("Plant player          ");
            }
            else if (enemyExists == 0)
            {
                Console.SetCursorPosition(1, height + 1);
                Console.WriteLine("Plant enemy           ");
            }
        }
        static public void DrawCursor()
        {
            Console.SetCursorPosition(position.Y,
                                      position.X);
            if (Console.KeyAvailable)
            {
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, field.GetLength(0) + 1);

                ConsoleKeyInfo str = Console.ReadKey();
                MoveCursor(str, field);

                Console.SetCursorPosition(position.Y,
                                          position.X);
                Console.ResetColor();

            }
        }

        static public void DrawSymbol(char str, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            
            Console.SetCursorPosition(position.Y,
                                      position.X);
            Console.Write(str);
            Console.SetCursorPosition(position.Y,
                                      position.X);
        }
        static public void PaintBorder(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.ResetColor();
                    if (arr[i, j] == '#')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        static public bool CanMove(char[,] arr, int x, int y, Cell position) => arr[position.X + x, position.Y + y] != '#';

        static public void SaveField(string level)
        {
            string path = @"Levels\level4.txt";
            using (StreamWriter sw = File.CreateText(path))
                sw.Write(level);
        }
    }
}

