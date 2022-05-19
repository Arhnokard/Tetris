using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class I:Figure
    {
        public I()
        {
            Matrix = new int[,] { {0,1,0,0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 } };
        }
        public override void Rotate()
        {
            int[,] newMatrix = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = Matrix[j, i];
                }
            }
            Matrix = newMatrix;
        }
    }
}
