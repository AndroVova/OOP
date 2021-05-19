using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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
    }
}
