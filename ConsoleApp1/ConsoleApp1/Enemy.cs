using System.Linq;


namespace ConsoleApp1
{
    public static class Enemy
    {
        static public Cell position = new Cell();
        static public bool isAlive = true;
        static public bool reverseMovement = false ;

        static public void OnMove()
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
            
            if(Player.position == position)
            {
                Player.isAlive = false;
            } 
            /*Console.ResetColor();
            Console.SetCursorPosition(0, Plane.position.X + 1);*/
            //Console.WriteLine(position.X +" : " + position.Y);
        }
    }
}
