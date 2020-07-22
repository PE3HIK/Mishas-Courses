using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Controllers
{
    public class TileMatrixController : MonoBehaviour
    {
        [SerializeField] private Tile _tilePrefab;
        public Tile[,] GenerateMatrix(int x , int y)
        {
            var tiles = new Tile[x,y];
            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var position = new Vector3(i, 0, -j);
                    var tile = Instantiate(_tilePrefab, position, Quaternion.identity,transform);
                    tile.Data.Index = new MatrixIndex(i, j);
                    tiles[i, j] = tile;
                }
            }
            return tiles;
        }
    }
}