using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace ConsoleApp1
{
    class WorkWithFile
    {
        private readonly string path = "GameResult.json";

        public List<GameResults> ReadJSON()
        {
            if (!File.Exists(path))
                return new List<GameResults>();
           using (StreamReader file = File.OpenText(path))
            {
                var serializer = new JsonSerializer();
                var GameResults = (List<GameResults>)serializer.Deserialize(file, typeof(List<GameResults>));
                return GameResults;
            }
        }

        public void AddResults(GameResults gameResult)
        {
            List<GameResults> gameResults = ReadJSON();
            gameResults.Add(gameResult);
            File.WriteAllText(path, JsonConvert.SerializeObject(gameResults));
        }

        static public void IdentifyCells(string[,] arr)
        {
            Plane.position = new Cell((byte)arr.GetLength(0), (byte)arr.GetLength(1));
            //Teleporter teleporter = new Teleporter();
            for (byte i = 0; i < arr.GetLength(0); i++)
            {
                for (byte j = 0; j < arr.GetLength(1); j++)
                {
                    Console.ResetColor();
                    if (arr[i, j] == "#" || arr[i, j] == "W")
                    {
                        Plane.walls.Add(new Plane.Wall(new Cell(i, j)));
                    }
                    if (arr[i, j] == "░")
                    {
                        Plane.bricks.Add(new Plane.Wall(new Cell(i, j)));
                    }
                    else if (arr[i, j] == "P")
                    {
                        Player.position = new Cell(i, j);
                    }
                    else if (arr[i, j] == "e")
                    {
                        Enemy enemy = new Enemy(new Cell(i, j));
                        Program.enemies.Add(enemy);
                        Program.enemiesNumber++;
                    }
                    else if (arr[i, j] == "T")
                    {
                        Program.teleport.positionIn = new Cell(i, j);
                    }
                    else if (arr[i, j] == "t")
                    {
                        Program.teleport.positionOut = new Cell(i, j);
                    }
                }
                Console.WriteLine();
            }
        }
        static public string[,] ConvertToArray(string[] str)
        {
            int j1 = str.Length;

            string[,] arr = new string[j1, str[0].Length];

            for (byte j = 0; j < j1; j++)
            {
                for (byte i = 0; i < str[0].Length; i++)
                {
                    arr[j, i] = str[j].ToCharArray()[i].ToString();
                }
            }
            return arr;
        }

        static public string[] ReadTXT(string path) =>  File.ReadAllLines(path);
        





    }
}
