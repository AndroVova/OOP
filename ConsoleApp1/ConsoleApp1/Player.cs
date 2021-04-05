using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
   static public class Player
   {
        static public Cell position = new Cell(0, 0);
        static public List<Bomb> bombs = new List<Bomb>();

        

        static private bool isAlive = true;
        static public void OnMove(ConsoleKeyInfo movement, int fieldX, int fieldY)
        {
            switch (movement.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        Cell nextPosition = new Cell(Convert.ToByte(position.X - 1), position.Y);
                        if (!Plane.walls.Any(el => el.position.Equals(nextPosition)))
                            position.X--;
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        Cell nextPosition = new Cell(position.X, Convert.ToByte(position.Y - 1));
                        if (!Plane.walls.Any(el => el.position.Equals(nextPosition)))
                            position.Y--;
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        Cell nextPosition = new Cell(Convert.ToByte(position.X + 1), position.Y);
                        if (!Plane.walls.Any(el => el.position.Equals(nextPosition)))
                            position.X++;
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        Cell nextPosition = new Cell(position.X, Convert.ToByte(position.Y + 1));
                        if (!Plane.walls.Any(el => el.position.Equals(nextPosition)))
                            position.Y++;
                        break;
                    }
                case ConsoleKey.E:
                    {
                        if(bombs.All(el => el.position != position))
                            bombs.Add(new Bomb(position));
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        isAlive = false;
                        break;
                    }
            }
        }
        static public bool IsAlive() => isAlive;
    }
}