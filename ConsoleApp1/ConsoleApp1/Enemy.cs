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
        public void OnMove(Enemy enemy)
        {
           /* var path = PathFinding.CalculateIdealPath(enemy);
            if (Program.isHard  &&
                path.Count != 1 && 
                path.Count < 17 && 
                new Cell((byte)(path[path.Count - 1].X), 
                         (byte)(path[path.Count - 1].Y)) == Player.position)
            {
                var step = path[1];
                position.X = (byte)step.X;
                position.Y = (byte)step.Y;
            }
            else*/
                NormalOnMove();

            if (Player.position == position)
                Player.isAlive = false;
            if (!Player.isAlive)
            {
                reverseVerticalMovement = false;
                reverseHorizontalMovement = false;
            }
                    
            Program.teleport.TeleportEnemy();
        }
        public void NormalOnMove()
        {
            if (!Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) &&
                !Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X - 1), position.Y)) && !reverseVerticalMovement)
                position.X--;
            else
                reverseVerticalMovement = true;

            if (!Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) &&
                !Plane.bricks.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) && reverseVerticalMovement)
                position.X++;
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
        }        
    }
}
