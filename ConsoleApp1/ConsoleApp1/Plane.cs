using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    static public class Plane
    {
        static public Cell position = new Cell(0, 0);
        static public List<Wall> walls = new List<Wall>();
        static public List<Wall> bricks = new List<Wall>();

        static public void MakeField()
        {
            LoadLevel();
            Console.SetCursorPosition(0, 0);
            for (byte i = 0; i < position.X; i++)
            {
                for (byte j = 0; j < position.Y; j++)
                {
                    Console.ResetColor();
                    if (BarrierSearcher.BarrierIsNear(0,0,new Cell(i,j),walls))
                    {
                        if ((i < 1 || i == position.X - 1) ||
                            (j < 2 || j  > position.Y - 3))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else
                            Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else if (BarrierSearcher.BarrierIsNear(0, 0, new Cell(i, j), bricks))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("░");
                    }
                    else if (i == Player.position.X &&
                             j == Player.position.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("☻");
                    }
                    else if (Program.enemies.Any(el => el.position.X == i &&
                                                       el.position.Y == j))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("☻");
                    }
                    else if ((i == Program.teleport.positionIn.X && j == Program.teleport.positionIn.Y) ||
                             (i == Program.teleport.positionOut.X && j == Program.teleport.positionOut.Y))
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("▀");
                    }
                    else
                        Console.Write(" ");

                   
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        static private void LoadLevel()
        {
            string[] str;
            if (Program.level1)
                str = WorkWithFile.ReadTXT(Media.level1);
            else if (Program.level2)
                str = WorkWithFile.ReadTXT(Media.level2);
            else
                str = WorkWithFile.ReadTXT(Media.level3);

            var field = WorkWithFile.ConvertToArray(str);
            WorkWithFile.IdentifyCells(field);
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