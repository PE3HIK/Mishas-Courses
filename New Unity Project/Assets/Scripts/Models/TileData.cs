using UnityEngine;

namespace Models
{
    public struct TileData
    {
        public MatrixIndex Index;

        public bool IsEmpty
        {
            get
            {
                return Mebel == null;
            }
        }

        public bool IsDirty
        {
            get
            {
                return Dust != null;
            }
        }

        public GameObject Dust;
        public GameObject Mebel; 

        public GameObject TileModel;
        
    }
}