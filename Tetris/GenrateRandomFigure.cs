using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GenrateRandomFigure
    {
        Random random = new Random();
        public Figure Generate()
        {
            int num = random.Next(1, 7);
            switch (num)    
            {
                case (1):
                    { return new T(); }
                case (2):
                    { return new Rectangle(); }
                case (3):
                    { return new Z(); }
                case (4):
                    { return new S(); }
                case (5):
                    { return new I(); }
                case (6):
                    { return new J(); }
                case (7):
                    { return new L(); }
                default:
                    return new T();
            }

        }
    }
}
