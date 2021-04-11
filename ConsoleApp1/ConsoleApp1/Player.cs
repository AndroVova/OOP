using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
   static public class Player
   {
        static public Cell position = new Cell(0, 0);
        static public List<Bomb> bombs = new List<Bomb>();

        static public bool isAlive { get; private set; } = true;
        static public void OnMove(ConsoleKeyInfo movement, int fieldX, int fieldY)
        {
            switch (movement.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell((byte)(position.X - 1), position.Y)))
                            position.X--;
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell(position.X, (byte)(position.Y - 1))))
                            position.Y--;
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell((byte)(position.X + 1), position.Y)))
                            position.X++;
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell(position.X, (byte)(position.Y + 1))))
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

        public class Bomb
        {
            public Cell position;
            public byte explosionTime { get => _explosionTime; }
            private byte _explosionTime = 30;

            public Bomb(Cell position)
            {
                this.position = position;
            }

            public void Explosion()
            {
                if (_explosionTime == 0)
                {
                    Console.ForegroundColor = Console.BackgroundColor = ConsoleColor.Yellow;
                    Bang(' ');
                    Console.BackgroundColor = ConsoleColor.Black;
                    /*Console.SetCursorPosition(0, Plane.position.X + 1);*/

                    if (Player.position.X == position.X   && 
                        Player.position.Y == position.Y)
                            isAlive = false;

                    Thread.Sleep(100);
                    Bang('+');
                    Thread.Sleep(100);
                    Bang('·');
                    Thread.Sleep(100);
                    Bang(' ');
                    Console.ResetColor();
                }
                else
                    _explosionTime--;
            }
            private void Bang( char str)
            {
                Console.SetCursorPosition(position.Y, position.X);
                Console.Write(str);

                if (!Plane.walls.Any(el => el.position ==
                                           new Cell(this.position.X, (byte)(this.position.Y + 1))))
                {
                    if(Player.position.X == position.X && 
                       Player.position.Y == position.Y + 1)
                            isAlive = false;
                    Console.SetCursorPosition(position.Y + 1, position.X);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                     new Cell(position.X, (byte)(position.Y + 2))))
                    {
                        if(Player.position.X == position.X && 
                           Player.position.Y == position.Y + 2)
                                isAlive = false;
                        Console.SetCursorPosition(position.Y + 2, position.X);
                        Console.Write(str);
                    }
                }
                if (!Plane.walls.Any(el => el.position ==
                                           new Cell(this.position.X, (byte)(this.position.Y - 1))))
                {
                    if(Player.position.X == position.X && 
                       Player.position.Y == position.Y - 1)
                            isAlive = false;
                    Console.SetCursorPosition(position.Y - 1, position.X);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                     new Cell(position.X, (byte)(position.Y - 2))))
                    {
                        if(Player.position.X == position.X && 
                           Player.position.Y == position.Y - 2)
                                isAlive = false;
                        Console.SetCursorPosition(position.Y - 2, position.X);
                        Console.Write(str);
                    }
                }
                if (!Plane.walls.Any(el => el.position ==
                                           new Cell((byte)(this.position.X + 1), this.position.Y)))
                {
                    if(Player.position.X == position.X + 1 &&
                       Player.position.Y == position.Y)
                            isAlive = false;
                    Console.SetCursorPosition(position.Y, this.position.X + 1);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                     new Cell((byte)(this.position.X + 2), position.Y)))
                    {
                        if(Player.position.X == position.X + 2 &&
                           Player.position.Y == position.Y)
                                isAlive = false;
                        Console.SetCursorPosition(position.Y, position.X + 2);
                        Console.Write(str);
                    }
                }
                if (!Plane.walls.Any(el => el.position ==
                                           new Cell((byte)(this.position.X - 1), this.position.Y)))
                {
                    if(Player.position.X == position.X - 1 &&
                       Player.position.Y == position.Y)
                            isAlive = false;
                    Console.SetCursorPosition(position.Y, this.position.X - 1);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                     new Cell((byte)(this.position.X - 2), position.Y)))
                    {
                        if(Player.position.X == position.X - 2 &&
                           Player.position.Y == position.Y)
                                isAlive = false;
                        Console.SetCursorPosition(position.Y, position.X - 2);
                        Console.Write(str);
                    }
                }

                Console.SetCursorPosition(0, Plane.position.X + 1);
            }
        }
    }
}