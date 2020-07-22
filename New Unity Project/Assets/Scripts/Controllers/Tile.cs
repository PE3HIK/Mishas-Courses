using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class Tile : MonoBehaviour
    {
        public TileData Data;


        public void SetModel(GameObject tileModel)
        {
            Data.TileModel = Instantiate(tileModel, transform);
        }
        public void SetFurnitur(GameObject tileModel)
        {
            Data.Mebel = Instantiate(tileModel, transform);
        }
        public void SetDust(GameObject tileModel)
        {
            Data.Dust = Instantiate(tileModel, transform);
        }
    }
}