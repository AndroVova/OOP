using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Location
    {
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public Location Parent;
    }

    class PathFinding
    {
        static public List<Location> CalculateIdealPath(Enemy enemy)
        {
            var start = new Location
            {
                X = enemy.position.X,
                Y = enemy.position.Y
            };
            var target = new Location
            {
                X = Player.position.X,
                Y = Player.position.Y
            };

            Location current = null;
            var openList = new List<Location>();
            var closedList = new List<Location>();
            int g = 0;

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowest = openList.Min(el => el.F);
                current = openList.First(el => el.F == lowest);

                closedList.Add(current);

                openList.Remove(current);

                if (closedList.FirstOrDefault(el => el.X == target.X && el.Y == target.Y) != null)
                    break;

                var neighborSquares = GetNeighborSquares(current.X, current.Y, openList);
                g = current.G + 1;

                foreach (var neighborSquare in neighborSquares)
                {
                    if (closedList.FirstOrDefault(el => el.X == neighborSquare.X &&
                                                        el.Y == neighborSquare.Y) != null)
                        continue;

                    if (openList.FirstOrDefault(el => el.X == neighborSquare.X &&
                                                      el.Y == neighborSquare.Y) == null)
                    {
                        neighborSquare.G = g;
                        neighborSquare.H = ComputeHScore(neighborSquare.X, neighborSquare.Y, target.X, target.Y);
                        neighborSquare.F = neighborSquare.G + neighborSquare.H;
                        neighborSquare.Parent = current;

                        openList.Insert(0, neighborSquare);

                    }
                }
            }
            List<Location> truePath = new List<Location>();
            while (current != null)
            {
                truePath.Insert(0, current);
                current = current.Parent;
            }
            return truePath;
        }

       

        static private List<Location> GetNeighborSquares(int x, int y, List<Location> openList)
        {
            List<Location> resultList = new List<Location>();
            Cell position = new Cell((byte)x, (byte)y);
            NeighborSquare( 0,  1, position, openList, resultList);

            NeighborSquare( 0, -1, position, openList, resultList);

            NeighborSquare(-1,  0, position, openList, resultList);

            NeighborSquare( 1,  0, position, openList, resultList);

            return resultList;
        }

        static private void NeighborSquare(sbyte x, sbyte y, Cell position, List<Location> openList, List<Location> list)
        {
            if (!BarrierSearcher.BarrierIsNear(x, y, position) &&
                !Program.enemies.Any(el => el.position == new Cell((byte)(position.X + x), (byte)(position.Y + y))))
            {
                Location node = openList.Find(el => el.X == position.X + x &&
                                                    el.Y == position.Y + y);
                if (node == null)
                    list.Add(new Location()
                    {
                        X = position.X + x,
                        Y = position.Y + y
                    });
                else
                    list.Add(node);
            }
        }

        static private int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
    }
}
