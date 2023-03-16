using CommunityToolkit.Mvvm.ComponentModel;
using MemoryTiles.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.ViewModels
{
    public class MainMenuViewModel : ObservableObject
    {
        public MainMenuViewModel()
        {
            ContextService.DeleteCachedGridSize();
        }
    }
}
