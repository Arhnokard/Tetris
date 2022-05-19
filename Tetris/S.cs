using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class S:Figure
    {
        public S()
        {
            Matrix = new int[,] { { 0, 5, 5 },{ 5, 5, 0 },{ 0, 0, 0 } };
        }
        
    }
}
