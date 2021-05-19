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

                    if (openList.FirstOrDefault(l => l.X == neighborSquare.X &&
                                                     l.Y == neighborSquare.Y) == null)
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

        static List<Location> GetNeighborSquares(int x, int y, List<Location> openList)
        {
            List<Location> list = new List<Location>();

            if ((!Plane.walls.Any(el => el.position == new Cell((byte)x, (byte)(y + 1))) &&
                !Plane.bricks.Any(el => el.position == new Cell((byte)x, (byte)(y + 1)))) ||
                 Plane.empty.Any(el => el.position == new Cell((byte)x, (byte)(y + 1))) &&
                     !Program.enemies.Any(el => el.position == new Cell((byte)x, (byte)(y + 1))))
            {
                Location node = openList.Find(el => el.X == x && el.Y == y + 1);
                if (node == null) list.Add(new Location() { X = x, Y = y + 1 });
                else list.Add(node);
            }

            if ((!Plane.walls.Any(el => el.position == new Cell((byte)x, (byte)(y - 1))) &&
                !Plane.bricks.Any(el => el.position == new Cell((byte)x, (byte)(y - 1)))) ||
                 Plane.empty.Any(el => el.position == new Cell((byte)x, (byte)(y - 1))) &&
                    !Program.enemies.Any(el => el.position == new Cell((byte)x, (byte)(y - 1))))
            {
                Location node = openList.Find(el => el.X == x && el.Y == y - 1);
                if (node == null) list.Add(new Location() { X = x, Y = y - 1 });
                else list.Add(node);
            }

            if ((!Plane.walls.Any(el => el.position == new Cell((byte)(x - 1), (byte)y)) &&
                !Plane.bricks.Any(el => el.position == new Cell((byte)(x - 1), (byte)y))) ||
                 Plane.empty.Any(el => el.position == new Cell((byte)(x - 1), (byte)y)) &&
                 !Program.enemies.Any(el => el.position == new Cell((byte)(x - 1), (byte)y)))
            {
                Location node = openList.Find(el => el.X == x - 1 && el.Y == y);
                if (node == null) list.Add(new Location() { X = x - 1, Y = y });
                else list.Add(node);
            }

            if ((!Plane.walls.Any(el => el.position == new Cell((byte)(x + 1), (byte)y)) &&
                !Plane.bricks.Any(el => el.position == new Cell((byte)(x + 1), (byte)y))) ||
                 Plane.empty.Any(el => el.position == new Cell((byte)(x + 1), (byte)y)) &&
                 !Program.enemies.Any(el => el.position == new Cell((byte)(x + 1), (byte)y)))
            {
                Location node = openList.Find(el => el.X == x + 1 && el.Y == y);
                if (node == null) list.Add(new Location() { X = x + 1, Y = y });
                else list.Add(node);
            }
            return list;
        }

        static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
    }
}
