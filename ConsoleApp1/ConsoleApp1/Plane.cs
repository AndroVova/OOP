using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    static public class Plane
    {
        static public Cell position = new Cell(0, 0);
        static public List<Wall> walls = new List<Wall>();

        static public void MakeField()
        {            
            string[,] arr = new string[position.X,
                                       position.Y];

            for (byte i = 0; i < arr.GetLength(0); i++)
            {
                for (byte j = 0; j < arr.GetLength(1); j++)
                {
                    Console.ResetColor();
                    if ((i < 1 || i == arr.GetLength(0) - 1) || (j <= 1 || j > arr.GetLength(1) - 3))
                    {
                        walls.Add(new Wall(new Cell(i, j)));
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(arr[i, j] = " ");
                    }
                    else if ((i >= 2 && i < position.X - 2) && (j >= 4 && j < position.Y - 4) && i % 2 == 0 && j % 2 == 0)
                    {
                        walls.Add(new Wall(new Cell(i,j)));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write("#");
                    }
                    else if (i == Player.position.X && j == Player.position.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}