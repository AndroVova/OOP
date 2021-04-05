using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Plane.position.X = 15;
            Plane.position.Y = 49;

            Player.position.X = 3;
            Player.position.Y = 36;

            int score = 0;
            Plane.MakeField();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score: {score}");
            Console.CursorVisible = false;

            while(Player.IsAlive())
            {

                DrawBombs();
                DrawPlayerMovement();
                Thread.Sleep(100);  
            }
            Console.ReadKey();
        }

        static void DrawPlayerMovement()
        {
            if (Console.KeyAvailable)
            {
                Console.BackgroundColor = Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.SetCursorPosition(Player.position.Y,
                                          Player.position.X);

                ConsoleKeyInfo str = Console.ReadKey();
                Player.OnMove(str,
                              Plane.position.X,
                              Plane.position.Y);

                Console.SetCursorPosition(Player.position.Y,
                                          Player.position.X);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(" ");
                Console.SetCursorPosition(0, Plane.position.X + 1);
                Console.ResetColor();
            }
        }
        static void DrawBombs()
        {
            for (int i = 0; i < Player.bombs.Count; i++) 
            {
                if (Player.bombs[i].explosionTime == 0)
                {
                    Player.bombs[i].Explosion();
                    Player.bombs.Remove(Player.bombs[i--]);
                }
                else
                {
                    Player.bombs[i].Explosion();
                    Console.SetCursorPosition(Player.bombs[i].position.Y,
                                              Player.bombs[i].position.X);
                    Console.Write('@');
                    Console.SetCursorPosition(0, Plane.position.X + 1);
                }
            }
        }
    }
}