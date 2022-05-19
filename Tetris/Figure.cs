using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Figure
    {
        internal int CoordinareX = 6;
        internal int CoordinareY = 0;
        public int[,] Matrix;
        public virtual void Rotate() 
        { 
            int[,] newMatrix = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = Matrix[j, (newMatrix.GetLength(0) - 1) - i];
                }
            }
            Matrix = newMatrix;
        }


        public void MoveLeft()
        {
            CoordinareX--;
        }
        public void MoveRight()
        {
            CoordinareX++;
        }
        public void MoveDown()
        {
            CoordinareY++;
        }
    }
}
