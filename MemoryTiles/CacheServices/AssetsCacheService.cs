using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.CacheServices
{
    public static class AssetsCacheService
    {
        public static List<string> GetImagesFullPaths()
        {
            return Directory.GetFiles(Environment.GetEnvironmentVariable("sourcePath") + @"\Assets").ToList();
        }
        public static string GetRelativePathForImageFromAbsolute(string absolutePath)
        {
            string relativePath = absolutePath.Split('\\')[absolutePath.Split('\\').Length - 1];
            return @"..\..\Assets\" + relativePath; 
        }
    }
}
