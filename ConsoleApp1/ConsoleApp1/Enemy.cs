using System.Linq;


namespace ConsoleApp1
{
    public class Enemy
    {
        public Cell position = new Cell();
        public bool isAlive = true;
        public bool reverseVerticalMovement = false ;
        public bool reverseHorizontalMovement = false;
        
        public Enemy(Cell position)
        {
            this.position = position;
        }
        
        public void OnMove()
        {
            if (!Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) &&
                !Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) && !reverseVerticalMovement)
                position.X-=1;
            else
                reverseVerticalMovement = true;

            if (!Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) &&
                !Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) && reverseVerticalMovement)
                position.X+=1;
            else
                reverseVerticalMovement = false;

            if ((Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) &&
                Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) ||
                Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) &&
                Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y))) &&
                !Plane.walls.Any(el => el.position ==
                                       new Cell(position.X, (byte)(position.Y - 1))) &&
                !Plane.bricks.Any(el => el.position ==
                                       new Cell(position.X, (byte)(position.Y - 1))) && !reverseHorizontalMovement)
                position.Y -= 1;
            else
                reverseHorizontalMovement = true;


            if ((Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) &&
                Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) ||
                Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) &&
                Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)))&&
                !Plane.walls.Any(el => el.position ==
                                       new Cell(position.X, (byte)(position.Y + 1))) &&
                !Plane.bricks.Any(el => el.position ==
                                       new Cell(position.X, (byte)(position.Y + 1))) && reverseHorizontalMovement)
                position.Y += 1;
            else
                reverseHorizontalMovement = false;

            if (Player.position == position)            
                Player.isAlive = false;
            Program.teleport.TeleportEnemy();
        }        
    }
}
