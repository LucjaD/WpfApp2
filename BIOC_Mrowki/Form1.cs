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
        int counter;



        public Form1()
        {
            InitializeComponent();
            _startCoordinates = new Point(0, 5);
            _finishCoordinates = new Point(11, 11);
            _labirynth = new Labirynth(16, 16);
            _map = new PictureBox[16, 16];
            _labirynth.FullFill();
            DrawLabirynth();
            FillForm();
            timer1.Start();
            _ant = new Ant(_startCoordinates.X, _startCoordinates.Y);
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
            //_labirynth.Board[0, 7] = new Start(_startCoordinates.X, _startCoordinates.Y);
            //_labirynth.Board[15, 7] = new Finish(_finishCoordinates.X, _finishCoordinates.Y);
            //for (int i = 0; i < _labirynth.SizeX; i++)
            //{


            //    _labirynth.Board[i, 6] = new Wall(i, 6);

            //    _labirynth.Board[i, 8] = new Wall(i, 8);

            //}






            for (int i = 0; i < _labirynth.SizeX; i++)
            {
                _labirynth.Board[i, 0] = new Wall(i, 0); // rzad 1
                _labirynth.Board[i, 15] = new Wall(i, 15); // rzad 16
                _labirynth.Board[15, i] = new Wall(15, i); //kolumna 16
            }
            //2 i 3 rzad
            _labirynth.Board[0, 1] = new Wall(0, 1);
            _labirynth.Board[0, 2] = new Wall(0, 2);

            _labirynth.Board[2, 2] = new Wall(2, 2);

            _labirynth.Board[4, 1] = new Wall(4, 1);
            _labirynth.Board[4, 2] = new Wall(4, 2);


            _labirynth.Board[6, 2] = new Wall(6, 2);

            _labirynth.Board[8, 1] = new Wall(8, 1);
            _labirynth.Board[8, 2] = new Wall(8, 2);

            _labirynth.Board[10, 1] = new Wall(10, 1);
            _labirynth.Board[10, 2] = new Wall(10, 2);

            _labirynth.Board[12, 1] = new Wall(12, 1);
            _labirynth.Board[13, 2] = new Wall(13, 2);

            //4 i 5 rzad
            _labirynth.Board[0, 3] = new Wall(0, 3);
            _labirynth.Board[0, 4] = new Wall(0, 4);

            _labirynth.Board[2, 3] = new Wall(2, 3);
            _labirynth.Board[2, 4] = new Wall(2, 4);

            _labirynth.Board[3, 4] = new Wall(3, 4);
            _labirynth.Board[4, 4] = new Wall(4, 4);
            _labirynth.Board[5, 4] = new Wall(5, 4);

            _labirynth.Board[6, 3] = new Wall(6, 3);
            _labirynth.Board[7, 3] = new Wall(7, 3);

            _labirynth.Board[9, 4] = new Wall(9, 4);

            _labirynth.Board[10, 3] = new Wall(10, 3);
            _labirynth.Board[10, 4] = new Wall(10, 4);

            _labirynth.Board[11, 4] = new Wall(11, 4);
            _labirynth.Board[12, 4] = new Wall(12, 4);

            _labirynth.Board[13, 3] = new Wall(13, 3);
            _labirynth.Board[13, 4] = new Wall(13, 4);

            //6 i 7 rzad
            _labirynth.Board[0, 5] = new Start(0, 5);
            _labirynth.Board[0, 6] = new Wall(0, 6);

            _labirynth.Board[2, 6] = new Wall(2, 6);
            _labirynth.Board[3, 6] = new Wall(3, 6);
            _labirynth.Board[4, 6] = new Wall(4, 6);
            _labirynth.Board[5, 6] = new Wall(5, 6);
            _labirynth.Board[6, 6] = new Wall(6, 6);

            _labirynth.Board[7, 5] = new Wall(7, 5);
            _labirynth.Board[7, 6] = new Wall(7, 6);

            _labirynth.Board[8, 5] = new Wall(8, 5);
            _labirynth.Board[8, 6] = new Wall(8, 6);

            _labirynth.Board[10, 6] = new Wall(10, 6);

            _labirynth.Board[12, 6] = new Wall(12, 6);
            _labirynth.Board[13, 6] = new Wall(13, 6);

            //8 i 9 rzad
            _labirynth.Board[0, 7] = new Wall(0, 7);
            _labirynth.Board[0, 8] = new Wall(0, 8);

            _labirynth.Board[2, 8] = new Wall(2, 8);
            _labirynth.Board[3, 8] = new Wall(3, 8);
            _labirynth.Board[4, 8] = new Wall(4, 8);

            _labirynth.Board[6, 8] = new Wall(6, 8);
            _labirynth.Board[7, 8] = new Wall(7, 8);
            _labirynth.Board[8, 8] = new Wall(8, 8);

            _labirynth.Board[10, 7] = new Wall(10, 7);

            _labirynth.Board[11, 8] = new Wall(11, 8);

            _labirynth.Board[13, 7] = new Wall(13, 7);
            _labirynth.Board[13, 8] = new Wall(13, 8);

            //10 i 11 rzad
            _labirynth.Board[0, 9] = new Wall(0, 9);
            _labirynth.Board[0, 10] = new Wall(0, 10);

            _labirynth.Board[2, 9] = new Wall(2, 9);
            _labirynth.Board[2, 10] = new Wall(2, 10);

            _labirynth.Board[4, 10] = new Wall(4, 10);
            _labirynth.Board[5, 10] = new Wall(5, 10);
            _labirynth.Board[6, 10] = new Wall(6, 10);

            _labirynth.Board[8, 9] = new Wall(8, 9);
            _labirynth.Board[8, 10] = new Wall(8, 10);

            _labirynth.Board[9, 9] = new Wall(9, 9);
            _labirynth.Board[10, 9] = new Wall(10, 9);
            _labirynth.Board[11, 9] = new Wall(11, 9);
            _labirynth.Board[12, 9] = new Wall(12, 9);

            _labirynth.Board[13, 9] = new Wall(13, 9);
            _labirynth.Board[13, 10] = new Wall(13, 10);

            //12 i 13 rzad
            _labirynth.Board[0, 11] = new Wall(0, 11);
            _labirynth.Board[0, 12] = new Wall(0, 12);

            _labirynth.Board[2, 11] = new Wall(2, 11);
            _labirynth.Board[2, 12] = new Wall(2, 12);

            _labirynth.Board[3, 12] = new Wall(3, 12);

            _labirynth.Board[4, 11] = new Wall(4, 11);
            _labirynth.Board[4, 12] = new Wall(4, 12);

            _labirynth.Board[5, 12] = new Wall(5, 12);
            _labirynth.Board[6, 12] = new Wall(6, 12);
            _labirynth.Board[7, 12] = new Wall(7, 12);
            
            
            
            _labirynth.Board[5, 8] = new Wall(5, 8);
            
            
            
            
            
            _labirynth.Board[8, 11] = new Wall(8, 11);
            _labirynth.Board[8, 12] = new Wall(8, 12);

            _labirynth.Board[10, 11] = new Wall(10, 11);
            _labirynth.Board[10, 12] = new Wall(10, 12);


            _labirynth.Board[11, 11] = new Finish(11, 11);
            _labirynth.Board[11, 12] = new Wall(11, 12);

            _labirynth.Board[13, 11] = new Wall(13, 11);
            _labirynth.Board[13, 12] = new Wall(13, 12);

            //14 i 15 rzad
            _labirynth.Board[0, 13] = new Wall(0, 13);
            _labirynth.Board[0, 14] = new Wall(0, 14);

            _labirynth.Board[2, 13] = new Wall(2, 13);

            _labirynth.Board[4, 13] = new Wall(4, 13);
            _labirynth.Board[4, 14] = new Wall(4, 14);

            _labirynth.Board[6, 13] = new Wall(6, 13);

            _labirynth.Board[8, 14] = new Wall(8, 14);

            _labirynth.Board[10, 13] = new Wall(10, 13);
            _labirynth.Board[11, 13] = new Wall(11, 13);
            _labirynth.Board[12, 13] = new Wall(12, 13);
            _labirynth.Board[13, 13] = new Wall(13, 13);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
              
            if (!_ant.selectMove(_labirynth))
            {
                counter++;
                iterator.Text = $"Mrówek które przeżyły tą mękę razem ze mną: {counter}";
                _ant = new Ant(_startCoordinates.X, _startCoordinates.Y);
            }
             
            RefreshView();

        }

    }
}
