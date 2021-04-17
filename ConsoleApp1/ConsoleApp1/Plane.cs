using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    static public class Plane
    {
        static public Cell position = new Cell(0, 0);
        static public List<Wall> walls = new List<Wall>();
        static public List<Wall> bricks = new List<Wall>();

        static public void MakeField()
        {            

            for (byte i = 0; i < position.X; i++)
            {
                for (byte j = 0; j < position.Y; j++)
                {
                    Console.ResetColor();
                    if ((i < 1 || i == position.X - 1) ||
                        (j < 2 || j > position.Y - 3))
                    {
                        walls.Add(new Wall(new Cell(i, j)));
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }
                    else if ((i >= 2 && i < position.X - 2) &&
                             (j >= 4 && j < position.Y - 4) &&
                              i % 2 == 0 &&
                              j % 2 == 0)
                    {
                        walls.Add(new Wall(new Cell(i, j)));
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else if (i == Player.position.X &&
                             j == Player.position.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("☻");
                    }
                    else if (i == Enemy.position.X &&
                             j == Enemy.position.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("@");
                    }
                    else if (i >= 1 && i <= position.X       && 
                            ((j >= 2              && j <= 3) || 
                            ((j <= position.Y - 3 && j >= position.Y - 4)))) 
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        /*bricks.Add(new Wall(new Cell(i, j)));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("#");*/
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
        public class Wall
        {
            public Cell position;

            public Wall(Cell position)
            {
                this.position = position;
            }
        }
    }
}