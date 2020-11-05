using BIOC_mrowki.Models;
using BIOC_Mrowki.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIOC_Mrowki
{
    public partial class Form1 : Form
    {
        private Labirynth _labirynth;
        private Point _startCoordinates; 
        public Form1()
        {
            InitializeComponent();

            _labirynth = new Labirynth(16, 16);
            _labirynth.FullFill();
            DrawLabirynth();
            FillForm();
        }
        private void FillForm()
        {
            for (int i = 0; i < _labirynth.SizeX; i++)
            {
                for (int j = 0; j < _labirynth.SizeY; j++)
                {
                    var px = new PictureBox();
                    var field = _labirynth.Board[i, j];
                    px.BackColor = field.Color;
                    px.Width = field.With;
                    px.Height = field.Height;
                    px.Location =new Point( field.With * i, field.Height * j);

                    Controls.Add(px);
                }
            }
        }
        private void DrawLabirynth()
        {
            _labirynth.Board[0, 7] = new Start(0, 7);
            _labirynth.Board[15, 7] = new Finish(15, 7);
            for (int i = 0; i < _labirynth.SizeX; i++)
            {
                

                _labirynth.Board[i, 6] = new Wall(i, 6);

                _labirynth.Board[i, 8] = new Wall(i, 8);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
