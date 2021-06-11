using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class DataReader 
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
            for (byte i = 0; i < arr.GetLength(0); i++)
            {
                for (byte j = 0; j < arr.GetLength(1); j++)
                {
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
                        Program.teleporterExists = true;
                    }
                    else if (arr[i, j] == "t")
                    {
                        Program.teleport.positionOut = new Cell(i, j);
                        Program.teleporterExists = true;
                    }
                }
            }
        }
        static public string[,] ConvertToArray(string[] str)
        {
            int rows = str.Length;
            int[] arrLength = new int[rows];
            int k = 0;
            foreach(var i in str)
            {
                arrLength[k++] = i.Length;
            }

            string[,] arr = new string[rows,arrLength.Max() ];
            for (byte j = 0; j < rows; j++)
            {
                for (byte i = 0; i < str[j].Length; i++)
                {
                    arr[j, i] = str[j].ToCharArray()[i].ToString();
                }
            }
            return arr;
        }
        static public string ConvertToString(string[] str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str[i].Length; j++)
                {
                    result += str[i][j];
                }
                result += "\n";
            }
            return result;
        }
        static public string ConvertToString(char[,] str)
        {
            string result = "";
            for (int i = 0; i < str.GetLength(0); i++)
            {
                for (int j = 0; j < str.GetLength(1); j++)
                {
                    result += str[i, j];
                }
                result += "\n";
            }
            return result;
        }

        static public string[] ReadTXT(string path) =>  File.ReadAllLines(path);
    }
}
