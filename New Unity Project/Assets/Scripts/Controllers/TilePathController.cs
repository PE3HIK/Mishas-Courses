using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class TilePathController
    {

        public List<Tile> GetPath(Directions direction, Tile playerTile, Tile[,] tiles)
        {
            var tileList = new List<Tile>();

            if (direction == Directions.Down)
            {
                var tempPlayerTileIndex = playerTile.Data.Index;

                for (int i = tempPlayerTileIndex.Y; i < tiles.GetLength(1); i++)
                {
                    if (tiles[tempPlayerTileIndex.X, i].Data.IsEmpty)
                    {
                        tileList.Add(tiles[tempPlayerTileIndex.X, i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (direction == Directions.Up)
            {
                var tempPlayerTileIndex = playerTile.Data.Index;

                for (int i = tempPlayerTileIndex.Y; i > 0; i--)
                {
                    if (tiles[tempPlayerTileIndex.X, i].Data.IsEmpty)
                    {
                        tileList.Add(tiles[tempPlayerTileIndex.X, i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (direction == Directions.Right)
            {
                var tempPlayerTileIndex = playerTile.Data.Index;

                for (int i = tempPlayerTileIndex.X; i < tiles.GetLength(0); i++)
                {
                    if (tiles[i, tempPlayerTileIndex.Y].Data.IsEmpty)
                    {
                        tileList.Add(tiles[i, tempPlayerTileIndex.Y]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (direction == Directions.Left)
            {
                var tempPlayerTileIndex = playerTile.Data.Index;

                for (int i = tempPlayerTileIndex.X; i > 0 ; i--)
                {
                    if (tiles[i, tempPlayerTileIndex.Y].Data.IsEmpty)
                    {
                        tileList.Add(tiles[i, tempPlayerTileIndex.Y]);
                    }
                    else
                    {
                        break;
                    }
                }  
            }
            
            return tileList; 
        }
    }
}