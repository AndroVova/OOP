using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Location
{
    public int X;
    public int Y;
    public int F;
    public int G;
    public int H;
    public Location Parent;
}
class PathFinding : MonoBehaviour
{
    public GameObject Player;
    public LayerMask BarrierLayer;
    public Location GetTargetPosition(GameObject Player)
    {
        Location target;
        if (Player != null)
        {
            target = new Location
            {
                X = (int)Mathf.Round(Player.transform.position.x),
                Y = (int)Mathf.Round(Player.transform.position.y)
            };
        }
        else
        {
            target = new Location
            {
                X = (int)Mathf.Round(transform.position.x),
                Y = (int)Mathf.Round(transform.position.y)
            };
        }
        return target;
    }
    public List<Location> CalculateIdealPath()
    {

        Location start = new Location
        {
           X = (int)Mathf.Round(transform.position.x),
           Y = (int)Mathf.Round(transform.position.y)
        };
        Location target = GetTargetPosition(Player);
        
        Location current = null;
        List<Location> openList = new List<Location>();
        List<Location> closedList = new List<Location>();
        int g = 0;

        openList.Add(start);

        while (openList.Count > 0)
        {
            int lowest = openList.Min(el => el.F);
            current = openList.First(el => el.F == lowest);

            closedList.Add(current);

            openList.Remove(current);

            if (closedList.FirstOrDefault(el => el.X == target.X && 
                                                el.Y == target.Y) != null)
                break;

            List<Location> neighborSquares = GetNeighborSquares(current, openList);
            g = current.G + 1;

            foreach (Location neighborSquare in neighborSquares)
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

    List<Location> GetNeighborSquares(Location current, List<Location> openList)
    {
        List<Location> list = new List<Location>();
        
        GetNeighborSquare( 0,  1, current, list, openList);
        GetNeighborSquare( 0, -1, current, list, openList);
        GetNeighborSquare(-1,  0, current, list, openList);
        GetNeighborSquare( 1,  0, current, list, openList);

        return list;
    }

    private void GetNeighborSquare(int x, int y, Location current, List<Location> list, List<Location> openList)
    {
        if (!Physics2D.OverlapCircle(new Vector2(current.X + x, current.Y + y), 0, BarrierLayer))
        {
            Location node = openList.Find(el => el.X == current.X + x && 
                                                el.Y == current.Y + y);
            if (node == null)
                list.Add(new Location() 
                {
                    X = current.X + x, 
                    Y = current.Y + y 
                });
            else
                list.Add(node);
        }
    }

    int ComputeHScore(int x, int y, int targetX, int targetY)
    {
        return Math.Abs(targetX - x) + Math.Abs(targetY - y);
    }

    void OnDrawGizmos()
    {
        var truePath = CalculateIdealPath();
        if (truePath != null)
            foreach (var item in truePath)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(new Vector2(item.X, item.Y), 0.2f);
            }
    }
}
