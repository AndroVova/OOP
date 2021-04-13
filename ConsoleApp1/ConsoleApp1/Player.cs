using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;

namespace ConsoleApp1
{
   static public class Player
   {
        static public Cell position = new Cell(0, 0);
        static public List<Bomb> bombs = new List<Bomb>();
        static public int score { get; private set; } = 0;
        static public bool isAlive { get; private set; } = true;
        static public void OnMove(ConsoleKeyInfo movement, int fieldX, int fieldY)
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
            SoundPlayer sound = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\steps.wav");
            sound.Play();
        }

        public class Bomb
        {
            public Cell position;
            public byte explosionTime { get => _explosionTime; }
            /*public byte explosionFrames { get => _explosionFrames; }*/

            private byte _explosionTime = 30;

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
                    SoundPlayer sound = new SoundPlayer(@"C:\Users\Vova\Desktop\work\oop\OOP\ConsoleApp1\ConsoleApp1\sound\explosion.wav");
                    sound.Play();
                    Console.ForegroundColor = Console.BackgroundColor = ConsoleColor.Yellow;
                   
                    Bang(' ');
                    Console.BackgroundColor = ConsoleColor.Black;

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

                //explosion in right axis
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell(this.position.X, (byte)(this.position.Y + 1))))
                {
                    if(explosionFramesR == 4) 
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                              new Cell(this.position.X, (byte)(this.position.Y + 1))));
                        score+=100;
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
                        score+=100;
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

                //explosion in left axis
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell(this.position.X, (byte)(this.position.Y - 1))))
                {                
                    if (explosionFramesL == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell(this.position.X, (byte)(this.position.Y - 1))));
                        score += 100;
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
                        score += 100;
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

                //explosion in bottom axis
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell((byte)(this.position.X + 1), this.position.Y)))
                {
                    if (explosionFramesB == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X + 1), this.position.Y)));
                        score += 100;
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
                            score+=100;
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

                //explosion in top axis
                if (Plane.bricks.Any(el => el.position ==
                                           new Cell((byte)(this.position.X - 1), this.position.Y)))
                {
                    if (explosionFramesT == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(this.position.X - 1), this.position.Y)));
                        score += 100;
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
                             score += 100;
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