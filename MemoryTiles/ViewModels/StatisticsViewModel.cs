using CommunityToolkit.Mvvm.ComponentModel;
using MemoryTiles.CacheServices;
using MemoryTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.ViewModels
{
    public class StatisticsViewModel : ObservableObject
    {
        private User _user;

        public int PlayedGames { get; }

        public int GamesWon { get; }
        public string Username { get; }

        public StatisticsViewModel()
        {
            _user = new ContextService().GetCachedUser();
            PlayedGames = _user.PlayedGames;
            GamesWon = _user.GamesWon;
            Username = _user.Name;
        }
    }
}
