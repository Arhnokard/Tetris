using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class J:Figure
    {
        public J() 
        {
            Matrix = new int[,] { { 0, 0, 0 }, { 2, 2, 2 }, { 0, 0, 2 } };
        }
       
    }
}
