﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
   static public class Player
   {
        static public Cell position = new Cell(0, 0);
        static public List<Bomb> bombs = new List<Bomb>();
        static public string name;
        static public int usedBombs = 0;
        static public bool isAlive { get; set; } = true;
        static public void OnMove(ConsoleKeyInfo movement)
        {
            switch (movement.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell((byte)(position.X - 1), position.Y)) &&
                            !Plane.bricks.Any(el => el.position ==
                                                   new Cell((byte)(position.X - 1), position.Y)))
                            position.X--;
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell(position.X, (byte)(position.Y - 1))) &&
                            !Plane.bricks.Any(el => el.position ==
                                                   new Cell(position.X, (byte)(position.Y - 1))))
                            position.Y--;
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell((byte)(position.X + 1), position.Y)) &&
                            !Plane.bricks.Any(el => el.position ==
                                                   new Cell((byte)(position.X + 1), position.Y)))
                            position.X++;
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        if (!Plane.walls.Any(el => el.position == 
                                                   new Cell(position.X, (byte)(position.Y + 1))) &&
                            !Plane.bricks.Any(el => el.position ==
                                                   new Cell(position.X, (byte)(position.Y + 1))))
                            position.Y++;
                        break;
                    }
                case ConsoleKey.E:
                    {
                        if (bombs.All(el => el.position != position))
                        {
                            usedBombs++;
                            bombs.Add(new Bomb(position));
                        }
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        isAlive = false;
                        break;
                    }
            }
            Program.teleport.TeleportPlayer();
        }

        public class Bomb
        {
            public Cell position;
            public short explosionTime { get => _explosionTime; }

            private short _explosionTime = 18;

            private byte explosionFramesR = 1;
            private byte explosionFramesL = 1;
            private byte explosionFramesB = 1;
            private byte explosionFramesT = 1;

            public Bomb(Cell position)
            {
                this.position = position;
            }

            public void Explosion()
            {
                if (_explosionTime == 0)
                {
                    Media.explosionSound.Play();
                    Console.ForegroundColor = Console.BackgroundColor = ConsoleColor.Yellow;
                   
                    Bang(' ');
                    Console.BackgroundColor = ConsoleColor.Black;

                         if(Player.position.X == position.X &&
                            Player.position.Y == position.Y)
                                isAlive = false;
                         for (int i = 0; i < Program.enemies.Count; i++)
                             if(Program.enemies.Any(el => el.position.X == position.X &&
                                                          el.position.Y == position.Y))
                        {
                            Program.enemies.Remove(new Enemy(new Cell(position.X,
                                                                      position.Y)));
                        }                                

                    Thread.Sleep(50);
                    Bang('+');
                    Thread.Sleep(50);
                    Bang('·');
                    Thread.Sleep(50);
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
                RightBang(str);
                LeftBang(str);
                DownBang(str);
                UpBang(str);                
            }

            private void RightBang(char str)
            {
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell(this.position.X, (byte)(this.position.Y + 1))))
                {
                    if (explosionFramesR == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                              new Cell(this.position.X, (byte)(this.position.Y + 1))));                      
                    }
                    explosionFramesR++;
                    Console.SetCursorPosition(position.Y + 1, position.X);
                    Console.Write(str);
                }
                else if (!Plane.bricks.Any(el => el.position ==
                                                 new Cell(this.position.X, (byte)(this.position.Y + 1))) &&
                          !Plane.walls.Any(el => el.position ==
                                                 new Cell(this.position.X, (byte)(this.position.Y + 1))) &&
                          Plane.bricks.Any(el => el.position ==
                                                 new Cell(this.position.X, (byte)(this.position.Y + 2))))
                {

                    if (explosionFramesR == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                              new Cell(this.position.X, (byte)(this.position.Y + 2))));
                    }
                    explosionFramesR++;

                    Console.SetCursorPosition(position.Y + 1, position.X);
                    Console.Write(str);
                    Console.SetCursorPosition(position.Y + 2, position.X);
                    Console.Write(str);
                }
                else if (!Plane.walls.Any(el => el.position ==
                                                     new Cell(this.position.X, (byte)(this.position.Y + 1))))
                {
                    if (Player.position.X == position.X &&
                        Player.position.Y == position.Y + 1)
                        isAlive = false;
                    else if (Program.enemies.Any(el => el.position.X == position.X &&
                                                       el.position.Y == position.Y + 1))
                    {
                        for (int i = 0; i < Program.enemies.Count; i++)
                            if (Program.enemies.Any(el => el.position.X == position.X &&
                                                          el.position.Y == position.Y + 1))
                            {
                                Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                                            new Cell(position.X, (byte)(position.Y + 1))));
                            }
                    }
                    Console.SetCursorPosition(position.Y + 1, position.X);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                               new Cell(position.X, (byte)(position.Y + 2))))
                    {
                        if (Player.position.X == position.X &&
                           Player.position.Y == position.Y + 2)
                            isAlive = false;
                        else if (Program.enemies.Any(el => el.position.X == position.X &&
                                                   el.position.Y == position.Y + 2))
                        {
                            for (int i = 0; i < Program.enemies.Count; i++)
                                if (Program.enemies.Any(el => el.position.X == position.X &&
                                                              el.position.Y == position.Y + 2))
                                {
                                    Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                               new Cell(this.position.X, (byte)(this.position.Y + 2))));
                                }
                        }
                        Console.SetCursorPosition(position.Y + 2, position.X);
                        Console.Write(str);
                    }
                }
            }
            private void LeftBang(char str)
            {
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell(this.position.X, (byte)(this.position.Y - 1))))
                {
                    if (explosionFramesL == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell(this.position.X, (byte)(this.position.Y - 1))));
                    }
                    explosionFramesL++;

                    Console.SetCursorPosition(position.Y - 1, position.X);
                    Console.Write(str);
                }
                else if (!Plane.bricks.Any(el => el.position ==
                                                 new Cell(this.position.X, (byte)(this.position.Y - 1))) &&
                         !Plane.walls.Any(el => el.position ==
                                                new Cell(this.position.X, (byte)(this.position.Y - 1))) &&
                          Plane.bricks.Any(el => el.position ==
                                                 new Cell(this.position.X, (byte)(this.position.Y - 2))))
                {
                    if (explosionFramesL == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell(this.position.X, (byte)(this.position.Y - 2))));
                    }
                    explosionFramesL++;
                    Console.SetCursorPosition(position.Y - 1, position.X);
                    Console.Write(str);
                    Console.SetCursorPosition(position.Y - 2, position.X);
                    Console.Write(str);
                }
                else if (!Plane.walls.Any(el => el.position ==
                                                new Cell(this.position.X, (byte)(this.position.Y - 1))))
                {
                    if (Player.position.X == position.X &&
                       Player.position.Y == position.Y - 1)
                        isAlive = false;

                    else if (Program.enemies.Any(el => el.position.X == position.X &&
                                                       el.position.Y == position.Y - 1))
                    {
                        for (int i = 0; i < Program.enemies.Count; i++)
                            if (Program.enemies.Any(el => el.position.X == position.X &&
                                                          el.position.Y == position.Y - 1))
                            {
                                Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                           new Cell(position.X, (byte)(position.Y - 1))));
                            }
                    }
                    Console.SetCursorPosition(position.Y - 1, position.X);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                               new Cell(position.X, (byte)(position.Y - 2))))
                    {
                        if (Player.position.X == position.X &&
                           Player.position.Y == position.Y - 2)
                            isAlive = false;
                        else if (Program.enemies.Any(el => el.position.X == position.X &&
                                                           el.position.Y == position.Y - 2))
                        {
                            for (int i = 0; i < Program.enemies.Count; i++)
                                if (Program.enemies.Any(el => el.position.X == position.X &&
                                                              el.position.Y == position.Y - 2))
                                {
                                    Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                                new Cell(position.X, (byte)(position.Y - 2))));
                                }
                        }
                        Console.SetCursorPosition(position.Y - 2, position.X);
                        Console.Write(str);
                    }
                }
            }
            private void DownBang(char str)
            {
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell((byte)(this.position.X + 1), this.position.Y)))
                {
                    if (explosionFramesB == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X + 1), this.position.Y)));
                    }
                    explosionFramesB++;
                    Console.SetCursorPosition(position.Y, position.X + 1);
                    Console.Write(str);
                }
                else if (!Plane.bricks.Any(el => el.position ==
                                                 new Cell((byte)(this.position.X + 1), this.position.Y)) &&
                         !Plane.walls.Any(el => el.position ==
                                                new Cell((byte)(this.position.X + 1), this.position.Y)) &&
                          Plane.bricks.Any(el => el.position ==
                                                 new Cell((byte)(this.position.X + 2), this.position.Y)))
                {
                    if (explosionFramesB == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                          new Cell((byte)(this.position.X + 2), this.position.Y)));
                    }
                    explosionFramesB++;
                    Console.SetCursorPosition(position.Y, position.X + 1);
                    Console.Write(str);
                    Console.SetCursorPosition(position.Y, position.X + 2);
                    Console.Write(str);
                }
                else if (!Plane.walls.Any(el => el.position ==
                                                new Cell((byte)(this.position.X + 1), this.position.Y)))
                {
                    if (Player.position.X == position.X + 1 &&
                       Player.position.Y == position.Y)
                        isAlive = false;

                    else if (Program.enemies.Any(el => el.position.X == position.X + 1 &&
                                                       el.position.Y == position.Y))
                    {
                        for (int i = 0; i < Program.enemies.Count; i++)
                            if (Program.enemies.Any(el => el.position.X == position.X + 1 &&
                                                          el.position.Y == position.Y))
                            {
                                Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                            new Cell((byte)(position.X + 1), position.Y)));
                            }
                    }
                    Console.SetCursorPosition(position.Y, this.position.X + 1);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                               new Cell((byte)(this.position.X + 2), position.Y)))
                    {
                        if (Player.position.X == position.X + 2 &&
                           Player.position.Y == position.Y)
                            isAlive = false;
                        else if (Program.enemies.Any(el => el.position.X == position.X + 2 &&
                                                           el.position.Y == position.Y))
                        {
                            for (int i = 0; i < Program.enemies.Count; i++)
                                if (Program.enemies.Any(el => el.position.X == position.X + 2 &&
                                                              el.position.Y == position.Y))
                                {
                                    Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X + 2), this.position.Y)));
                                }
                        }
                        Console.SetCursorPosition(position.Y, position.X + 2);
                        Console.Write(str);
                    }
                }
            }
            private void UpBang(char str)
            {
                if (Plane.bricks.Any(el => el.position ==
                                                           new Cell((byte)(this.position.X - 1), this.position.Y)))
                {
                    if (explosionFramesT == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X - 1), this.position.Y)));
                    }
                    explosionFramesT++;
                    Console.SetCursorPosition(position.Y, position.X - 1);
                    Console.Write(str);
                }
                else if (!Plane.bricks.Any(el => el.position ==
                                                 new Cell((byte)(this.position.X - 1), this.position.Y)) &&
                         !Plane.walls.Any(el => el.position ==
                                                 new Cell((byte)(this.position.X - 1), this.position.Y)) &&
                          Plane.bricks.Any(el => el.position ==
                                                 new Cell((byte)(this.position.X - 2), this.position.Y)))
                {
                    if (explosionFramesT == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X - 2), this.position.Y)));
                    }
                    explosionFramesT++;
                    Console.SetCursorPosition(position.Y, position.X - 1);
                    Console.Write(str);
                    Console.SetCursorPosition(position.Y, position.X - 2);
                    Console.Write(str);
                }
                else if (!Plane.walls.Any(el => el.position ==
                                                new Cell((byte)(this.position.X - 1), this.position.Y)))
                {
                    if (Player.position.X == position.X - 1 &&
                       Player.position.Y == position.Y)
                        isAlive = false;
                    else if (Program.enemies.Any(el => el.position.X == position.X - 1 &&
                                                      el.position.Y == position.Y))
                    {
                        for (int i = 0; i < Program.enemies.Count; i++)
                            if (Program.enemies.Any(el => el.position.X == position.X - 1 &&
                                                          el.position.Y == position.Y))
                            {
                                Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                           new Cell((byte)(this.position.X - 1), this.position.Y)));
                            }
                    }
                    Console.SetCursorPosition(position.Y, this.position.X - 1);
                    Console.Write(str);
                    if (!Plane.walls.Any(el => el.position ==
                                              new Cell((byte)(this.position.X - 2), position.Y)))
                    {
                        if (Player.position.X == position.X - 2 &&
                           Player.position.Y == position.Y)
                            isAlive = false;

                        else if (Program.enemies.Any(el => el.position.X == position.X - 2 &&
                                                         el.position.Y == position.Y))
                        {
                            for (int i = 0; i < Program.enemies.Count; i++)
                                if (Program.enemies.Any(el => el.position.X == position.X - 2 &&
                                                              el.position.Y == position.Y))
                                {
                                    Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X - 2), this.position.Y)));
                                }
                        }
                        Console.SetCursorPosition(position.Y, position.X - 2);
                        Console.Write(str);
                    }

                }
                Console.SetCursorPosition(0, Plane.position.X + 1);
            }

            public void ExplosionAnimation()
            {
                ThreadStart thread1 = new ThreadStart(Explosion);
                Thread thread = new Thread(thread1);
                thread.Start();
                Console.SetCursorPosition(0, Plane.position.X + 1);
                thread.Join(150);
            }
        }
    }
}