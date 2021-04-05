using System;
using System.Threading;
namespace ConsoleApp1
{
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

                Console.SetCursorPosition(position.Y, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y + 1, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X + 1);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y - 1, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X - 1);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y + 2, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X + 2);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y - 2, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X - 2);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;

                Console.SetCursorPosition(0, Plane.position.X + 1);

                Thread.Sleep(100);

                Console.SetCursorPosition(position.Y, position.X);
                Console.Write("+");
                Console.SetCursorPosition(position.Y + 1, position.X);
                Console.Write("+");
                Console.SetCursorPosition(position.Y, position.X + 1);
                Console.Write("+");
                Console.SetCursorPosition(position.Y - 1, position.X);
                Console.Write("+");
                Console.SetCursorPosition(position.Y, position.X - 1);
                Console.Write("+");
                Console.SetCursorPosition(position.Y + 2, position.X);
                Console.Write("+");
                Console.SetCursorPosition(position.Y, position.X + 2);
                Console.Write("+");
                Console.SetCursorPosition(position.Y - 2, position.X);
                Console.Write("+");
                Console.SetCursorPosition(position.Y, position.X - 2);
                Console.Write("+");

                Console.SetCursorPosition(0, Plane.position.X + 1);

                Thread.Sleep(100);

                Console.SetCursorPosition(position.Y, position.X);
                Console.Write("·");
                Console.SetCursorPosition(position.Y + 2, position.X);
                Console.Write("·");
                Console.SetCursorPosition(position.Y, position.X + 2);
                Console.Write("·");
                Console.SetCursorPosition(position.Y - 2, position.X);
                Console.Write("·");
                Console.SetCursorPosition(position.Y, position.X - 2);
                Console.Write("·");
                Console.SetCursorPosition(position.Y + 1, position.X);
                Console.Write("·");
                Console.SetCursorPosition(position.Y, position.X + 1);
                Console.Write("·");
                Console.SetCursorPosition(position.Y - 1, position.X);
                Console.Write("·");
                Console.SetCursorPosition(position.Y, position.X - 1);
                Console.Write("·");

                Console.SetCursorPosition(0, Plane.position.X + 1);


                Thread.Sleep(100);

                Console.SetCursorPosition(position.Y, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y + 1, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X + 1);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y - 1, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X - 1);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y + 2, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X + 2);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y - 2, position.X);
                Console.Write(" ");
                Console.SetCursorPosition(position.Y, position.X - 2);
                Console.Write(" ");

                Console.SetCursorPosition(0, Plane.position.X + 1);

                Console.ResetColor();

                //Console.SetCursorPosition(0, 0);
                //Plane.MakeField();
            }
            else
                _explosionTime--;
        }
    }
}