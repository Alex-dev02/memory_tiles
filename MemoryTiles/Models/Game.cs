using MemoryTiles.CacheServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryTiles.Models
{
    public class Game
    {
        public class Tile
        {
            public string HiddenImageURI { get; set; }
            public string BlankImageURI { get; set; }
            public string ShownImageURI { get; private set; }
            public int Row;
            public int Column;
            public Tile(int row, int column)
            {
                Row = row;
                Column = column;
                HiddenImageURI = "";
                BlankImageURI = "";
                ShownImageURI = BlankImageURI;
            }
            public void ShowImage()
            {
                ShownImageURI = HiddenImageURI;
            }
            public void HideImage()
            {
                ShownImageURI = BlankImageURI;
            }
        }
        public List<List<Tile>> Grid { get; set; }
        private int _nRows;
        private int _nCols;
        public int GameLevel { get; set; }

        public Game(int nRows = 6, int nCols = 6)
        {
            Grid = new List<List<Tile>>();
            GameLevel = 1;
            _nRows = nRows;
            _nCols = nCols;
            List<string> imagesURIs = PrepareImageURIs();
            imagesURIs.AddRange(imagesURIs);
            Random random = new Random();
            imagesURIs = imagesURIs.OrderBy(a => random.Next()).ToList<string>();
            CreateGrid(ref imagesURIs);
        }
        private void CreateGrid(ref List<string> imageURIs)
        {
            for (int i = 0; i < _nRows; i++)
            {
                this.Grid.Add(new List<Tile>());
                for (int j = 0; j < _nCols; j++)
                {
                    Grid[i].Add(new Tile(i, j));
                    Grid[i][j].HiddenImageURI = imageURIs[0];
                    imageURIs.RemoveAt(0);
                }
            }
        }
        private List<string> PrepareImageURIs()
        {
            int numberOfImagesToFetch = (_nRows * _nCols) / 2;
            List<string> assetsImageURIs = AssetsCacheService.GetImagesFullPaths();

            if (assetsImageURIs.Count > numberOfImagesToFetch)
                return assetsImageURIs.GetRange(0, numberOfImagesToFetch);

            Random random = new Random();

            while (true)
            {
                if (assetsImageURIs.Count >= numberOfImagesToFetch)
                    return assetsImageURIs;
                assetsImageURIs.Add(assetsImageURIs[random.Next(0, assetsImageURIs.Count)]);
            }
        }
    }
}
