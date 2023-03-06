using MemoryTiles.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MemoryTiles.CacheServices
{
    public static class UserCacheService
    {
        // Method that will cache our user
        // It will save it as a json file under the directory Cache/UserName/Profile.json
        // Username will be a subdirectory named after the Username
        // Profile.json will contain the encoded data of the user
        public static void CacheUser(User user)
        {
            Directory.CreateDirectory(Environment.GetEnvironmentVariable("cachePath") + @"\" + user.Name);
            string pathToWriteCachedUser = Environment.GetEnvironmentVariable("cachePath") + @"\" + user.Name + @"\Profile.json";
            File.WriteAllText(
                pathToWriteCachedUser,
                JsonConvert.SerializeObject(user, Formatting.Indented)
                );
        }
        public static User LoadUser(string username)
        {
            string pathToUserJson = Environment.GetEnvironmentVariable("cachePath") + @"\" + username + @"\Profile.json";
            return JsonConvert.DeserializeObject<User>(File.ReadAllText(pathToUserJson));
        }
        public static List<string> GetCachedUsernames()
        {
            List<string> pathsToUserProfiles
                = new List<string>(Directory.GetDirectories(Environment.GetEnvironmentVariable("cachePath")));
            // Selecting only the username
            return pathsToUserProfiles.Select(x => x.Split('\\')[x.Split('\\').Length - 1]).ToList();
        }
        public static string GetAvatarImageURI(string username)
        {
            return LoadUser(username).PathToAvatar;
        }
    }
}
