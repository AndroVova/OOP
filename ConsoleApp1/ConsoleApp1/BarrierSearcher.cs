using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    static public class BarrierSearcher
    {
        static public bool HorizontalCanMove(sbyte dy, Cell position) =>  BarrierIsNear(-1, 0, position) &&
                                                                         BarrierIsNear( 1, 0, position) &&
                                                                        !BarrierIsNear( 0, dy, position);

        static public bool BarrierIsNear(sbyte dx, sbyte dy, Cell position, List<Plane.Wall> barrier) 
            => barrier.Any(el => el.position == new Cell((byte)(position.X + dx), (byte)(position.Y + dy)));

        static public bool BarrierIsNear(sbyte dx, sbyte dy, Cell position)
            => Plane.walls.Any(el => el.position == 
                                  new Cell((byte)(position.X + dx), (byte)(position.Y + dy))) || 
               Plane.bricks.Any(el => el.position == 
                                  new Cell((byte)(position.X + dx), (byte)(position.Y + dy))); 
    }
}
