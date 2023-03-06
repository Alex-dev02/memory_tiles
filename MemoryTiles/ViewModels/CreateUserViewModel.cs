using MemoryTiles.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTiles.ViewModels
{
    public class CreateUserViewModel
    {
        private int _imageURIListIndex = 0;
        private List<string> _imageURIs = AssetsCacheService.GetImagesFullPaths();
        public string ImageURI
        {
            get
            {
                return _imageURIs[_imageURIListIndex];
            }
        }
    }
}
