using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        GenrateRandomFigure genRanFig = new GenrateRandomFigure();
        Figure figure;
        GameControl control = new GameControl();
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init() 
        {
            label1.Text ="Score:"+ control.Score;
            this.KeyDown += new KeyEventHandler(keyFunc);
            figure = genRanFig.Generate();
            control.Supplement(figure);
            timer1.Interval = control.Interval;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            Invalidate();
        }

        private void keyFunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    {
                        control.ClearArea(figure);
                        figure.MoveLeft();
                        if (control.HorizontalCollision(figure))
                        {
                            figure.MoveRight();
                        }
                        control.Supplement(figure);
                        Invalidate();
                        break;
                    }
                case Keys.S:
                    {
                        control.ClearArea(figure);
                        figure.MoveDown();
                        if (control.VerticalCollision(figure))
                        {
                            figure.CoordinareY -= 1;
                            control.Supplement(figure);
                            control.ErasingLines(figure);
                            label1.Text = "Score:" + control.Score;
                            figure = genRanFig.Generate();
                        }
                        else
                        {
                            control.Supplement(figure);
                        }
                        Invalidate();
                        break;
                    }
                case Keys.D:
                    {
                        control.ClearArea(figure);
                        figure.MoveRight();
                        if (control.HorizontalCollision(figure))
                        {
                            figure.MoveLeft();
                        }
                        control.Supplement(figure);
                        Invalidate();
                        break;
                    }
                case Keys.W:
                    {
                        control.ClearArea(figure);
                        if (figure.CoordinareX < 0 || figure.CoordinareX + (figure.Matrix.GetLength(1) - 1) >= 12 || figure.CoordinareY + (figure.Matrix.GetLength(0) - 1) >= 20 || figure.CoordinareY < 0)
                        {
                            break;
                        }
                        if (!control.RotateCollision(figure))
                        {
                            figure.Rotate();
                        }
                        control.Supplement(figure);
                        Invalidate();
                        break;
                    }
                case Keys.Space:
                    {
                        timer1.Interval = 10;
                        break;
                    }
                
            }
        }
        
        private void update(object sender, EventArgs e)
        {
            control.ClearArea(figure);
            figure.MoveDown();
            if (control.VerticalCollision(figure))
            {
               figure.CoordinareY -= 1;
               control.Supplement(figure);
                control.ErasingLines(figure);
                label1.Text = "Score:" + control.Score;
                timer1.Interval = control.Interval;
               figure = genRanFig.Generate();
                if (control.VerticalCollision(figure))
                {
                    timer1.Tick-= new EventHandler(update);
                    timer1.Stop();
                    this.KeyDown -= new KeyEventHandler(keyFunc);
                    MessageBox.Show("Ваш результат:" + control.Score);
                    control.NewGame();
                    Init();
                }
            }
            control.Supplement(figure);
            Invalidate();
        }
        
        private void OnPaint(object sender, PaintEventArgs e)
        {
            Field.DrawField(e.Graphics);
            control.DrawMap(e.Graphics);
        }
    }
}
