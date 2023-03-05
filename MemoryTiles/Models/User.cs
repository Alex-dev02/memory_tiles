using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.Models
{
    public class User
    {
        public string Name { get; }
        public string PathToAvatar { get; }
        public int PlayedGames { get; set; }
        public int GamesWon { get; set; }

        public User(string name, string pathToAvatar, int playedGames, int gamesWon)
        {
            Name = name;
            PathToAvatar = pathToAvatar;
            PlayedGames = playedGames;
            GamesWon = gamesWon;
        }
    }
}
