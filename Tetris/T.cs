using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class T:Figure
    {
        public T() 
        {
            Matrix = new int[,] { { 0,0,0 },{6,6,6 },{0,6,0 } };
            CoordinareY = -1;
        }
       
    }
}
