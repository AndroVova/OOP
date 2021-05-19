using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp1
{
    public class Teleporter
    {
        public Cell positionIn = new Cell();
        public Cell positionOut = new Cell();

        public Teleporter(Cell positionIn, Cell positionOut)
        {
            this.positionIn = positionIn;
            this.positionOut = positionOut;
        }

        public List<Teleporter> teleporters = new List<Teleporter>();
        public int isOut = 0;

        public void TeleportPlayer()
        {
            if(Player.position == positionIn)
                Player.position = positionOut;
            else if (Player.position == positionOut)
                Player.position = positionIn;
        }
        public void TeleportEnemy()
        {
            if (Program.enemies.Any(el => el.position == positionIn) && isOut == 0)
            {
                for (int i = 0; i < Program.enemies.Count; i++)
                    if (Program.enemies[i].position == positionIn)
                    {
                        Program.enemies[i].position = positionOut;
                        isOut++;
                    }
            }
            else if (Program.enemies.Any(el => el.position == positionOut) && isOut++ == 2)
            {
                for (int i = 0; i < Program.enemies.Count; i++)
                    if (Program.enemies[i].position == positionOut)
                    {
                        Program.enemies[i].position = positionIn;
                        isOut = 0;
                    }
            }
        }
    }
}
