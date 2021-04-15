using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Enemy
    {
        public static Cell position = new Cell();
        public static bool isAlive { get; set; } = true;
        public static bool reverseMovement = false ;
        public static void OnMove()
        {
            if (!Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) && !reverseMovement)
                position.X--;
            else
                reverseMovement = true;

            if (!Plane.walls.Any(el => el.position ==
                                      new Cell((byte)(position.X + 1), position.Y)) && reverseMovement)
                position.X++;
            else
                reverseMovement = false;
            Console.ResetColor();
            Console.SetCursorPosition(0, Plane.position.X + 1);
            Console.WriteLine(position.X +" : " + position.Y);
        }
    }
}
