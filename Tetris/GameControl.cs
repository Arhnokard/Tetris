using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameControl
    {
        public int Score = 0;
        int _removedLines = 0;
        int[,] _map = new int[20, 12];
        public int Interval = 600;
        int _size = 25;
        public void Supplement(Figure figure)
        {
            for (int i = 0; i < figure.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < figure.Matrix.GetLength(1); j++)
                {
                    if (figure.Matrix[i, j] != 0)
                    {
                        if (figure.CoordinareY + i >= 0 && figure.CoordinareX + j >= 0 && figure.CoordinareX < 13 && figure.CoordinareY + i < 21)
                        {
                            _map[figure.CoordinareY + i, figure.CoordinareX + j] = figure.Matrix[i, j];
                        }
                    }
                }
            }

        }
        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] != 0)
                    {
                        switch (_map[i, j])
                        {
                            case (1):
                                {
                                    g.FillRectangle(Brushes.DarkBlue, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            case (2):
                                {
                                    g.FillRectangle(Brushes.Yellow, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            case (3):
                                {
                                    g.FillRectangle(Brushes.Gray, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            case (4):
                                {
                                    g.FillRectangle(Brushes.Green, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            case (5):
                                {
                                    g.FillRectangle(Brushes.Purple, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            case (6):
                                {
                                    g.FillRectangle(Brushes.Red, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            case (7):
                                {
                                    g.FillRectangle(Brushes.Orange, 25 + j * _size, 25 + i * _size, _size, _size);
                                    g.DrawRectangle(Pens.Black, 25 + j * _size, 25 + i * _size, _size, _size);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
        }
        public void ClearArea(Figure figure)
        {
            for (int i = 0; i < figure.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < figure.Matrix.GetLength(1); j++)
                {
                    if (figure.Matrix[i, j] != 0)
                    {
                        if (figure.CoordinareY + i >= 0 && figure.CoordinareX + j >= 0 && figure.CoordinareX + j < 12 && figure.CoordinareY + i < 20)
                        {
                            _map[figure.CoordinareY + i, figure.CoordinareX + j] = 0;
                        }
                    }

                }
            }
        }

        public bool HorizontalCollision(Figure figure)
        {
            for (int i = 0; i < figure.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < figure.Matrix.GetLength(1); j++)
                {
                    if (figure.Matrix[i, j] != 0)
                    {
                        if (figure.CoordinareX + j < 0 || figure.CoordinareX + j >=_map.GetLength(1) || _map[figure.CoordinareY + i, figure.CoordinareX + j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool VerticalCollision(Figure figure)
        {
            for (int i = 0; i < figure.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < figure.Matrix.GetLength(1); j++)
                {
                    if (figure.Matrix[i, j] != 0)
                    {
                        if (figure.CoordinareY + i >= _map.GetLength(0) || _map[figure.CoordinareY + i, figure.CoordinareX + j] != 0)
                        {

                            return true;
                        }

                    }
                }
            }
            return false;
        }
        public bool RotateCollision(Figure figure) 
        {
            for (int i = 0; i < figure.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < figure.Matrix.GetLength(1); j++)
                {
                    if (figure.Matrix[i,j]!=0 && _map[figure.CoordinareY+(figure.Matrix.GetLength(0)-1)-j,figure.CoordinareX+i]!=0)
                    {
                        return true;
                    } 
                    
                }
            }
            return false;
        }
        public void ErasingLines(Figure figure)
        {
            int count = 0;
            for (int i = figure.CoordinareY; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] != 0)
                    {
                        count++;
                    }    
                }
                if (count==_map.GetLength(1))
                {
                    for (int k = i; k >= 1; k--)
                    {
                        for (int j = 0; j < _map.GetLength(1); j++)
                        {
                            _map[k, j] = _map[k - 1, j];
                        }
                    }
                    _removedLines++;
                    Score = 10 * _removedLines;
                    if (_removedLines % 5 == 0)
                    {
                        if (Interval > 60)
                            Interval -= 10;
                    }
                }
                count = 0;

            }
            
        }
        public void NewGame() 
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    _map[i, j] = 0;
                }
            }
            Score = 0;
            Interval = 600;
            _removedLines = 0;
        }
    }
}
