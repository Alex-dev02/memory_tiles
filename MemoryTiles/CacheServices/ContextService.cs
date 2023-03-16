using MemoryTiles.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MemoryTiles.CacheServices
{
    public class ContextService
    {
        public User LoggedUser { get; private set; }

        public ContextService()
        {
            LoadUser();
        }

        public User GetCachedUser()
        {
            return this.LoggedUser;
        }
        public static void ClearContext()
        {
            DirectoryInfo directoryToClear = new DirectoryInfo("YourPath");

            foreach (FileInfo file in directoryToClear.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo directory in directoryToClear.GetDirectories())
            {
                directory.Delete(true);
            }
        }

        public static void CacheUsername(string username)
        {
            string pathToWriteUsername = Environment.GetEnvironmentVariable("cachePath") + @"\Context\User.json";
            File.WriteAllText(
                pathToWriteUsername,
                JsonConvert.SerializeObject(username, Formatting.Indented)
                );
        }
        private void LoadUser()
        {
            string pathToUserContext = Environment.GetEnvironmentVariable("cachePath") + @"\Context\User.json";
            if (!File.Exists(pathToUserContext))
                return;
            string cachedUsername = JsonConvert.DeserializeObject<string>(File.ReadAllText(pathToUserContext));
            this.LoggedUser = UserCacheService.LoadUser(cachedUsername);
        }

        public static void CacheGridSizeOption(int nRows, int nColumns)
        {
            Tuple<int, int> gridSize = new Tuple<int, int>(nRows, nColumns);
            string pathToWriteGridSize = Environment.GetEnvironmentVariable("cachePath") + @"\Context\GridSize.json";
            File.WriteAllText(
                pathToWriteGridSize,
                JsonConvert.SerializeObject(gridSize, Formatting.Indented)
                );
        }
        public static void DeleteCachedGridSize()
        {
            string pathToCachedGridSize = Environment.GetEnvironmentVariable("cachePath") + @"\Context\GridSize.json";
            if (!File.Exists(pathToCachedGridSize))
                return;
            File.Delete(pathToCachedGridSize);
        }
        public static Tuple<int, int> GetCachedGridSize()
        {
            string pathToCachedGridSize = Environment.GetEnvironmentVariable("cachePath") + @"\Context\GridSize.json";
            if (!File.Exists(pathToCachedGridSize))
                return new Tuple<int, int>(6, 6);
            return JsonConvert.DeserializeObject<Tuple<int, int>>(File.ReadAllText(pathToCachedGridSize));
        }

    }
}
