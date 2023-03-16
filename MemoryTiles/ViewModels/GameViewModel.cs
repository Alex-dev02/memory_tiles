using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemoryTiles.CacheServices;
using MemoryTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemoryTiles.ViewModels
{
    public class GameViewModel : ObservableObject
    {
        private Game _game;
        private User _user;
        public List<List<Game.Tile>> Grid { get; set; }
        public ICommand ClickTileCommand { get; }
        public GameViewModel(bool isNewGame)
        {
            ClickTileCommand = new RelayCommand<object>(ClickTile);

            _user = new ContextService().GetCachedUser();

            if (isNewGame)
            {
                Tuple<int, int> gridSize = ContextService.GetCachedGridSize();
                _game = new Game(gridSize.Item1, gridSize.Item2);
            }
            else
                _game = GameCacheService.GetCachedGame(ref _user);
            Grid = _game.Grid;
        }
        public void ClickTile(object parameter)
        {
            //Grid[row][column].ShowImage();
            OnPropertyChanged(nameof(Grid));
        }
    }
}
