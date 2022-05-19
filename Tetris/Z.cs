using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Z:Figure
    {
        public Z()
        {
            Matrix = new int[,] { { 7, 7, 0 }, { 0, 7, 7 }, { 0, 0, 0 } };
        }
        
    }
}
