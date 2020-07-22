using System;
using UnityEngine;

namespace Controllers 
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private TileMatrixController _tileMatrixController;

        [SerializeField] private GameObject _tileModel;
        [SerializeField] private GameObject _furniturModel;
        [SerializeField] private GameObject _dustModel;

        private TilePathController _tilePathController = new TilePathController(); 
        
        private static int[,] Level = new int [10,7]
        {
            {0, 0, 0, 0, 0, 0, 0},
            {0, 1, 0, 1, 1, 1, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 1, 0, 1, 1, 1, 1},
            {0, 1, 0, 0, 0, 0, 0},
            {0, 1, 1, 1, 1, 1, 0},
            {0, 1, 1, 1, 1, 1, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {1, 1, 1, 1, 1, 1, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };

        public Tile[,] _tiles;

        public Tile _tempTile; 

        private void Start()
        {
            var  _x = Level.GetLength(0);
            var  _y = Level.GetLength(1);
            
            _tiles = _tileMatrixController.GenerateMatrix(_x, _y);
            
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    var tile = _tiles[i, j];
                    tile.SetModel(_tileModel);

                    if (Level[i, j] == 1)
                    {
                        tile.SetFurnitur(_furniturModel);
                    }
                    
                    if (Level[i, j] == 0)
                    {
                        tile.SetDust(_dustModel);
                    }
                }
            }

            
        }

        private void Update()
        {
            if (_tempTile != null)
            {
                var playerPosition = _tilePathController.GetPath(Directions.Up, _tempTile, _tiles);
                _tempTile = null;

                foreach (var tile in playerPosition)
                {
                    Destroy(tile.Data.Dust);
                }
            }
        }
        
    }
}