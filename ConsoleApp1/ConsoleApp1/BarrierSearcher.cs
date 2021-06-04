using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    static public class BarrierSearcher
    {
        static public bool HorizontalCanMove(sbyte y, Cell position) =>  BarrierIsNear(-1, 0, position) &&
                                                                         BarrierIsNear( 1, 0, position) &&
                                                                        !BarrierIsNear( 0, y, position);

        static public bool BarrierIsNear(sbyte x, sbyte y, Cell position, List<Plane.Wall> barrier) 
            => barrier.Any(el => el.position == new Cell((byte)(position.X + x), (byte)(position.Y + y)));

        static public bool BarrierIsNear(sbyte x, sbyte y, Cell position)
            => Plane.walls.Any(el => el.position == 
                                  new Cell((byte)(position.X + x), (byte)(position.Y + y))) || 
               Plane.bricks.Any(el => el.position == 
                                  new Cell((byte)(position.X + x), (byte)(position.Y + y))); 


    }
}
