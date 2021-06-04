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
                        if (!BarrierSearcher.BarrierIsNear(-1, 0, position))
                            position.X--;
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        if (!BarrierSearcher.BarrierIsNear(0, -1, position))
                            position.Y--;
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        if (!BarrierSearcher.BarrierIsNear(1, 0, position))
                            position.X++;
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        if (!BarrierSearcher.BarrierIsNear(0, 1, position))
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

                    DeathFromBang(0, 0);

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
                AllSidesBang(str,  0,  1, explosionFramesR);
                explosionFramesR++;

                AllSidesBang(str,  0, -1, explosionFramesL);
                explosionFramesL++;

                AllSidesBang(str,  1,  0, explosionFramesB);
                explosionFramesB++;

                AllSidesBang(str, -1,  0, explosionFramesT);
                explosionFramesT++;
            }

            private void AllSidesBang(char str, sbyte x, sbyte y, byte explosionFrame )
            {
                if (BarrierSearcher.BarrierIsNear(x, y, position, Plane.bricks))
                {
                    if (explosionFrame == 4)
                    {
                        Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                              new Cell((byte)(position.X + x), (byte)(position.Y + y))));
                    }
                    DrawFire(x, y, str);
                }

                else if (!BarrierSearcher.BarrierIsNear(x, y, position) &&
                          BarrierSearcher.BarrierIsNear((sbyte)(2 * x), (sbyte)(2 * y), position, Plane.bricks))
                {
                     if (explosionFrame == 4)
                     {
                         Plane.bricks.Remove(Plane.bricks.FirstOrDefault(el => el.position ==
                                                                               new Cell((byte)(position.X + 2 * x), (byte)(position.Y + 2 * y))));
                     }
                     DrawFire(x, y, str);
                     DrawFire((sbyte)(2*x), (sbyte)(2 * y), str);
                }

                else if (!BarrierSearcher.BarrierIsNear(x, y, position, Plane.walls))
                {
                     DeathFromBang(x, y);

                     DrawFire(x, y, str);
                     if (!BarrierSearcher.BarrierIsNear((sbyte)(2 * x), (sbyte)(2 * y), position, Plane.walls))
                     {
                        DeathFromBang((sbyte)(2 * x), (sbyte)(2 * y));

                        DrawFire((sbyte)(2 * x), (sbyte)(2 * y), str);
                     }
                 }
            }

            private void DrawFire(sbyte x, sbyte y, char str)
            {
                Console.SetCursorPosition(position.Y + y, position.X + x);
                Console.Write(str);
            }

            private void DeathFromBang(sbyte x , sbyte y)
            {
                if (Player.position.X == position.X + x && 
                    Player.position.Y == position.Y + y)
                    isAlive = false;
                else if (Program.enemies.Any(el => el.position.X == position.X + x &&  
                                                   el.position.Y == position.Y + y))
                {
                    Program.enemies.Remove(Program.enemies.FirstOrDefault(el => el.position ==
                                                                                new Cell((byte)(position.X + x), (byte)(position.Y + y))));
                }                    
            }

            public void ExplosionAnimation()
            {
                ThreadStart thread1 = new ThreadStart(Explosion);
                Thread thread = new Thread(thread1);
                thread.Start();
                Console.SetCursorPosition(0, Plane.position.X + 1);
                thread.Join( 145 );
            }
        }
    }
}