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
        private readonly Point _startCoordinates;
        private readonly Point _finishCoordinates;
        private Ant _ant;
        private PictureBox[,] _map;
        public Form1()
        {
            InitializeComponent();
            _startCoordinates = new Point(0, 7);
            _finishCoordinates = new Point(15, 7);
            _labirynth = new Labirynth(16, 16);
            _map = new PictureBox[16, 16];
            _labirynth.FullFill();
            DrawLabirynth();
            FillForm();
            timer1.Start();

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
                    _map[i, j] = px; 
                    Controls.Add(px);
                }
            }
        }
        private void RefreshView()
        {
            for (int i = 0; i < _labirynth.SizeX; i++)
            {
                for (int j = 0; j < _labirynth.SizeY; j++)
                {
                    _map[i,j].BackColor = _labirynth.Board[i, j].Color;

                }
            }
        }
        private void DrawLabirynth()
        {
            _labirynth.Board[0, 7] = new Start(_startCoordinates.X, _startCoordinates.Y);
            _labirynth.Board[15, 7] = new Finish(_finishCoordinates.X, _finishCoordinates.Y);
            for (int i = 0; i < _labirynth.SizeX; i++)
            {
                

                _labirynth.Board[i, 6] = new Wall(i, 6);

                _labirynth.Board[i, 8] = new Wall(i, 8);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshView();
            if (_ant == null)
            {
                _ant = new Ant(_startCoordinates.X, _startCoordinates.Y);
            }
           
            var to = _labirynth.Board[_ant.X + 1, _ant.Y];
            if (to is Finish)
            {
                _ant = null;
            }
            else _ant.Move(_labirynth, new Point(_ant.X + 1, _ant.Y));
        }
    }
}
