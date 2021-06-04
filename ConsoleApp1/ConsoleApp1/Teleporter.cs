
namespace ConsoleApp1
{
    public class Teleporter
    {
        public Cell positionIn = new Cell();
        public Cell positionOut = new Cell();

        public Teleporter()
        {

        }
        public Teleporter(Cell positionIn, Cell positionOut)
        {
            this.positionIn = positionIn;
            this.positionOut = positionOut;
        }

  //    public List<Teleporter> teleporters = new List<Teleporter>();
        public int isOut = 0;

        public void TeleportPlayer()
        {
            if(Player.position == positionIn)
                Player.position = positionOut;
            else if (Player.position == positionOut)
                Player.position = positionIn;
        }
        public void TeleportEnemy(Enemy enemy)
        {
            if (enemy.position == positionIn && isOut == 0)
            {               
                enemy.position = positionOut;                   
            }
            else if (enemy.position == positionOut && isOut++ == 1)
            {               
                enemy.position = positionIn;
                isOut = 0;                
            }
        }
    }
}
