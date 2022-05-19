using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static class Field
    {
        public static void DrawField(Graphics g) 
        {
            g.DrawRectangle(Pens.Black, 25, 25, 300, 500);
        }
    }
}
