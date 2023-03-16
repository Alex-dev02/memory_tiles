using MemoryTiles.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.CacheServices
{
    public static class GameCacheService
    {
        public static void CacheGame(ref Game game, ref User user)
        {
            string pathToUserDir = Environment.GetEnvironmentVariable("cachePath") + @"\" + user.Name;
            if (!File.Exists(pathToUserDir))
                Directory.CreateDirectory(pathToUserDir);

            string pathToWriteCachedGame = pathToUserDir + @"\Game.json";
            File.WriteAllText(
                pathToWriteCachedGame,
                JsonConvert.SerializeObject(game, Formatting.Indented)
                );
        }

        public static Game GetCachedGame(ref User user)
        {
            string pathToGameDir = Environment.GetEnvironmentVariable("cachePath") + @"\" + user.Name + @"\Game.json";
            return JsonConvert.DeserializeObject<Game>(File.ReadAllText(pathToGameDir));
        }

    }
}
