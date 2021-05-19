using System.Linq;


namespace ConsoleApp1
{
    public class Enemy
    {
        public Cell position = new Cell();
        public bool isAlive = true;
        public bool reverseMovement = false ;
        
        public Enemy(Cell position)
        {
            this.position = position;
        }
        public void OnMove(Enemy enemy)
        {
            /*var path = PathFinding.CalculateIdealPath(enemy);
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
                                       new Cell((byte)(position.X - 1), position.Y)) && !reverseMovement)
                position.X--;
            else
                reverseMovement = true;

            if (!Plane.walls.Any(el => el.position ==
                                       new Cell((byte)(position.X + 1), position.Y)) && reverseMovement)
                position.X++;
            else
<<<<<<< HEAD
<<<<<<< HEAD
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


=======
=======
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
                reverseMovement = false;
            
            if(Player.position == position)            
                Player.isAlive = false;
            Program.teleport.TeleportEnemy();
>>>>>>> parent of 0010415 (redesigned menu and added simple settings)
        }        
    }
}
