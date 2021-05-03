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
        
        public void OnMove()
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
                Player.isAlive = false;
            Program.teleport.TeleportEnemy();
        }        
    }
}
