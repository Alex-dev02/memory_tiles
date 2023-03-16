using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MemoryTiles.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemoryTiles.ViewModels
{
    public class OptionsMenuViewModel : ObservableObject
    {
        private int _height;
        private int _width;

        public ICommand IncreaseHeightCommand { get; }
        public ICommand DecreaseHeightCommand { get; }
        public ICommand IncreaseWidthCommand { get; }
        public ICommand DecreaseWidthCommand { get; }
        public ICommand SaveGridSizeCommand { get; }
        
        public OptionsMenuViewModel()
        {
            _height = 6;
            _width = 6;
            IncreaseHeightCommand = new RelayCommand(IncreaseHeight);
            DecreaseHeightCommand = new RelayCommand(DecreaseHeight);
            IncreaseWidthCommand = new RelayCommand(IncreaseWidth);
            DecreaseWidthCommand = new RelayCommand(DecreaseWidth);
            SaveGridSizeCommand = new RelayCommand(SaveGridSize);
        }
        public void SaveGridSize()
        {
            ContextService.CacheGridSizeOption(_height, _width);
        }
        private void IncreaseHeight()
        {
            if (_height >= 12)
                Height = 5;
            else
                Height++;
        }
        private void DecreaseHeight()
        {
            if (_height <= 5)
                Height = 12;
            else
                Height--;
        }
        private void IncreaseWidth()
        {
            if (_width >= 12)
                Width = 5;
            else
                Width++;
        }
        private void DecreaseWidth()
        {
            if (_width <= 5)
                Width = 12;
            else
                Width--;
        }
        public int Height
        {
            get 
            { 
                return _height;
            }
            set
            {
                SetProperty(ref _height, value); 
            }
        }
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                SetProperty(ref _width, value);
            }
        }
    }
}
