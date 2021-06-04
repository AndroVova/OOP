using System.Linq;


namespace ConsoleApp1
{
    public class Enemy
    {
        public Cell position = new Cell();
        public bool reverseVerticalMovement = false;
        public bool reverseHorizontalMovement = false;
        
        public Enemy(Cell position)
        {
            this.position = position;
        }
        public void Move()
        {
            if (!Program.isHard)
                NormalMove();
            else
            {
                var path = PathFinding.CalculateIdealPath(this);
                if (path.Count != 1 &&
                    path.Count < 17 &&
                    new Cell((byte)(path[path.Count - 1].X),
                             (byte)(path[path.Count - 1].Y)) == Player.position)
                {
                    var step = path[1];
                    position.X = (byte)step.X;
                    position.Y = (byte)step.Y;
                }
                else
                    NormalMove();
            }

            if (Player.position == position)
                Player.isAlive = false;
                    
            Program.teleport.TeleportEnemy(this);
        }
        

        public void NormalMove()
        {
            if (!BarrierSearcher.BarrierIsNear( -1, 0 , position) && !reverseVerticalMovement)
                position.X--;
            else
                reverseVerticalMovement = true;

            if (!BarrierSearcher.BarrierIsNear(1, 0, position) && reverseVerticalMovement)
                position.X++;
            else
                reverseVerticalMovement = false;
            
            if (BarrierSearcher.HorizontalCanMove(-1, position) && !reverseHorizontalMovement)
                position.Y -= 1;
            else
                reverseHorizontalMovement = true;

            if (BarrierSearcher.HorizontalCanMove( 1, position) && reverseHorizontalMovement)
                position.Y += 1;
            else
                reverseHorizontalMovement = false;
        }        
    }
}
