using System;

namespace Models
{
    [Serializable]
    public struct MatrixIndex 
    {
        public int X;
        public int Y;

        public MatrixIndex(int x, int y)
        {
            Y = y;
            X = x;
        }
    }
}