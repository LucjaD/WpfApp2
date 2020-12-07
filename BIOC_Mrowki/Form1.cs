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
            _startCoordinates = new Point(13, 25);
            _finishCoordinates = new Point(2, 1);
            _labirynth = new Labirynth(30, 30);
            _map = new PictureBox[30, 30];

            //_startCoordinates = new Point(0,5);
            //_finishCoordinates = new Point(11,11);
            //_labirynth = new Labirynth(16,16);
            //_map = new PictureBox[16,16];
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
                    px.Location = new Point(field.With * i, field.Height * j);
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
                    _map[i, j].BackColor = _labirynth.Board[i, j].Color;

                }
            }
        }
        private void DrawLabirynth()
        {

            //for (int i = 0; i < _labirynth.SizeX; i++)
            //{
            //    _labirynth.Board[i, 0] = new Wall(i, 0); // rzad 1
            //    _labirynth.Board[i, 15] = new Wall(i, 15); // rzad 16
            //    _labirynth.Board[15, i] = new Wall(15, i); //kolumna 16
            //}
            ////2 i 3 rzad
            //_labirynth.Board[0, 1] = new Wall(0, 1);
            //_labirynth.Board[0, 2] = new Wall(0, 2);

            //_labirynth.Board[2, 2] = new Wall(2, 2);

            //_labirynth.Board[4, 1] = new Wall(4, 1);
            //_labirynth.Board[4, 2] = new Wall(4, 2);


            //_labirynth.Board[6, 2] = new Wall(6, 2);

            //_labirynth.Board[8, 1] = new Wall(8, 1);
            //_labirynth.Board[8, 2] = new Wall(8, 2);

            //_labirynth.Board[10, 1] = new Wall(10, 1);
            //_labirynth.Board[10, 2] = new Wall(10, 2);

            //_labirynth.Board[12, 1] = new Wall(12, 1);
            //_labirynth.Board[13, 2] = new Wall(13, 2);

            ////4 i 5 rzad
            //_labirynth.Board[0, 3] = new Wall(0, 3);
            //_labirynth.Board[0, 4] = new Wall(0, 4);

            //_labirynth.Board[2, 3] = new Wall(2, 3);
            //_labirynth.Board[2, 4] = new Wall(2, 4);

            //_labirynth.Board[3, 4] = new Wall(3, 4);
            //_labirynth.Board[4, 4] = new Wall(4, 4);
            //_labirynth.Board[5, 4] = new Wall(5, 4);

            //_labirynth.Board[6, 3] = new Wall(6, 3);
            //_labirynth.Board[7, 3] = new Wall(7, 3);

            //_labirynth.Board[9, 4] = new Wall(9, 4);

            //_labirynth.Board[10, 3] = new Wall(10, 3);
            //_labirynth.Board[10, 4] = new Wall(10, 4);

            //_labirynth.Board[11, 4] = new Wall(11, 4);
            //_labirynth.Board[12, 4] = new Wall(12, 4);

            //_labirynth.Board[13, 3] = new Wall(13, 3);
            //_labirynth.Board[13, 4] = new Wall(13, 4);

            ////6 i 7 rzad
            //_labirynth.Board[0, 5] = new Start(0, 5);
            //_labirynth.Board[0, 6] = new Wall(0, 6);

            //_labirynth.Board[2, 6] = new Wall(2, 6);
            //_labirynth.Board[3, 6] = new Wall(3, 6);
            //_labirynth.Board[4, 6] = new Wall(4, 6);
            //_labirynth.Board[5, 6] = new Wall(5, 6);
            //_labirynth.Board[6, 6] = new Wall(6, 6);

            //_labirynth.Board[7, 5] = new Wall(7, 5);
            //_labirynth.Board[7, 6] = new Wall(7, 6);

            //_labirynth.Board[8, 5] = new Wall(8, 5);
            //_labirynth.Board[8, 6] = new Wall(8, 6);

            //_labirynth.Board[10, 6] = new Wall(10, 6);

            //_labirynth.Board[12, 6] = new Wall(12, 6);
            //_labirynth.Board[13, 6] = new Wall(13, 6);

            ////8 i 9 rzad
            //_labirynth.Board[0, 7] = new Wall(0, 7);
            //_labirynth.Board[0, 8] = new Wall(0, 8);

            //_labirynth.Board[2, 8] = new Wall(2, 8);
            //_labirynth.Board[3, 8] = new Wall(3, 8);
            //_labirynth.Board[4, 8] = new Wall(4, 8);

            //_labirynth.Board[6, 8] = new Wall(6, 8);
            //_labirynth.Board[7, 8] = new Wall(7, 8);
            //_labirynth.Board[8, 8] = new Wall(8, 8);

            //_labirynth.Board[10, 7] = new Wall(10, 7);

            //_labirynth.Board[11, 8] = new Wall(11, 8);

            //_labirynth.Board[13, 7] = new Wall(13, 7);
            //_labirynth.Board[13, 8] = new Wall(13, 8);

            ////10 i 11 rzad
            //_labirynth.Board[0, 9] = new Wall(0, 9);
            //_labirynth.Board[0, 10] = new Wall(0, 10);

            //_labirynth.Board[2, 9] = new Wall(2, 9);
            //_labirynth.Board[2, 10] = new Wall(2, 10);

            //_labirynth.Board[4, 10] = new Wall(4, 10);
            //_labirynth.Board[5, 10] = new Wall(5, 10);
            //_labirynth.Board[6, 10] = new Wall(6, 10);

            //_labirynth.Board[8, 9] = new Wall(8, 9);
            //_labirynth.Board[8, 10] = new Wall(8, 10);

            //_labirynth.Board[9, 9] = new Wall(9, 9);
            //_labirynth.Board[10, 9] = new Wall(10, 9);
            //_labirynth.Board[11, 9] = new Wall(11, 9);
            //_labirynth.Board[12, 9] = new Wall(12, 9);

            //_labirynth.Board[13, 9] = new Wall(13, 9);
            //_labirynth.Board[13, 10] = new Wall(13, 10);

            ////12 i 13 rzad
            //_labirynth.Board[0, 11] = new Wall(0, 11);
            //_labirynth.Board[0, 12] = new Wall(0, 12);

            //_labirynth.Board[2, 11] = new Wall(2, 11);
            //_labirynth.Board[2, 12] = new Wall(2, 12);

            //_labirynth.Board[3, 12] = new Wall(3, 12);

            //_labirynth.Board[4, 11] = new Wall(4, 11);
            //_labirynth.Board[4, 12] = new Wall(4, 12);

            //_labirynth.Board[5, 12] = new Wall(5, 12);
            //_labirynth.Board[6, 12] = new Wall(6, 12);
            //_labirynth.Board[7, 12] = new Wall(7, 12);



            //_labirynth.Board[5, 8] = new Wall(5, 8);





            //_labirynth.Board[8, 11] = new Wall(8, 11);
            //_labirynth.Board[8, 12] = new Wall(8, 12);

            //_labirynth.Board[10, 11] = new Wall(10, 11);
            //_labirynth.Board[10, 12] = new Wall(10, 12);


            //_labirynth.Board[11, 11] = new Finish(11, 11);
            //_labirynth.Board[11, 12] = new Wall(11, 12);

            //_labirynth.Board[13, 11] = new Wall(13, 11);
            //_labirynth.Board[13, 12] = new Wall(13, 12);

            ////14 i 15 rzad
            //_labirynth.Board[0, 13] = new Wall(0, 13);
            //_labirynth.Board[0, 14] = new Wall(0, 14);

            //_labirynth.Board[2, 13] = new Wall(2, 13);

            //_labirynth.Board[4, 13] = new Wall(4, 13);
            //_labirynth.Board[4, 14] = new Wall(4, 14);

            //_labirynth.Board[6, 13] = new Wall(6, 13);

            //_labirynth.Board[8, 14] = new Wall(8, 14);

            //_labirynth.Board[10, 13] = new Wall(10, 13);
            //_labirynth.Board[11, 13] = new Wall(11, 13);
            //_labirynth.Board[12, 13] = new Wall(12, 13);
            //_labirynth.Board[13, 13] = new Wall(13, 13);





            for (int i = 0; i < _labirynth.SizeX; i++)
            {
                _labirynth.Board[i, 0] = new Wall(i, 0); // rzad 1
                _labirynth.Board[0, i] = new Wall(0, i); // kolumna 1
                _labirynth.Board[i, 29] = new Wall(i, 29); // rzad 30
                _labirynth.Board[29, i] = new Wall(29, i); //kolumna 30
            }

            // wall(kolumna|, rzad-)
            //2 i 3 rzad

            _labirynth.Board[2, 1] = new Finish(2, 1);
            _labirynth.Board[2, 2] = new Wall(2, 2);
            _labirynth.Board[3, 1] = new Wall(3, 1);
            _labirynth.Board[3, 2] = new Wall(3, 2);

            _labirynth.Board[5, 2] = new Wall(5, 2);

            _labirynth.Board[7, 1] = new Wall(7, 1);
            _labirynth.Board[7, 2] = new Wall(7, 2);

            _labirynth.Board[9, 2] = new Wall(9, 2);
            _labirynth.Board[10, 2] = new Wall(10, 2);
            _labirynth.Board[11, 2] = new Wall(11, 2);
            _labirynth.Board[12, 2] = new Wall(12, 2);
            _labirynth.Board[13, 2] = new Wall(13, 2);
            _labirynth.Board[14, 2] = new Wall(14, 2);

            _labirynth.Board[16, 2] = new Wall(16, 2);

            _labirynth.Board[17, 1] = new Wall(17, 1);

            _labirynth.Board[19, 2] = new Wall(19, 2);
            _labirynth.Board[20, 2] = new Wall(20, 2);

            _labirynth.Board[22, 2] = new Wall(22, 2);
            _labirynth.Board[23, 2] = new Wall(23, 2);
            _labirynth.Board[24, 2] = new Wall(24, 2);
            _labirynth.Board[25, 2] = new Wall(25, 2);
            _labirynth.Board[26, 2] = new Wall(26, 2);
            _labirynth.Board[27, 2] = new Wall(27, 2);

            //4 i 5 rzad

            _labirynth.Board[2, 3] = new Wall(2, 3);
            _labirynth.Board[3, 3] = new Wall(3, 3);

            _labirynth.Board[5, 3] = new Wall(5, 3);
            _labirynth.Board[5, 4] = new Wall(5, 4);

            _labirynth.Board[7, 3] = new Wall(7, 3);
            _labirynth.Board[7, 4] = new Wall(7, 4);

            _labirynth.Board[9, 3] = new Wall(9, 3);
            _labirynth.Board[9, 4] = new Wall(9, 4);

            _labirynth.Board[11, 4] = new Wall(11, 4);
            _labirynth.Board[12, 4] = new Wall(12, 4);
            _labirynth.Board[13, 4] = new Wall(13, 4);
            _labirynth.Board[14, 3] = new Wall(14, 3);
            _labirynth.Board[14, 4] = new Wall(14, 4);
            _labirynth.Board[15, 4] = new Wall(15, 4);
            _labirynth.Board[16, 4] = new Wall(16, 4);
            _labirynth.Board[17, 4] = new Wall(17, 4);
            _labirynth.Board[18, 3] = new Wall(18, 3);
            _labirynth.Board[18, 4] = new Wall(18, 4);
            _labirynth.Board[19, 4] = new Wall(19, 4);
            _labirynth.Board[20, 4] = new Wall(20, 4);
            _labirynth.Board[21, 4] = new Wall(21, 4);
            _labirynth.Board[22, 3] = new Wall(22, 3);
            _labirynth.Board[22, 4] = new Wall(22, 4);
            _labirynth.Board[23, 4] = new Wall(23, 4);

            _labirynth.Board[25, 4] = new Wall(25, 4);

            _labirynth.Board[27, 3] = new Wall(27, 3);
            _labirynth.Board[27, 4] = new Wall(27, 4);

            //6 i 7 rzad

            _labirynth.Board[1, 5] = new Wall(1, 5);

            _labirynth.Board[3, 5] = new Wall(3, 5);
            _labirynth.Board[3, 6] = new Wall(3, 6);

            _labirynth.Board[4, 5] = new Wall(4, 5);
            _labirynth.Board[5, 5] = new Wall(5, 5);

            _labirynth.Board[7, 5] = new Wall(7, 5);

            _labirynth.Board[9, 5] = new Wall(9, 5);
            _labirynth.Board[9, 6] = new Wall(9, 6);
            _labirynth.Board[10, 6] = new Wall(10, 6);
            _labirynth.Board[11, 6] = new Wall(11, 6);
            _labirynth.Board[12, 6] = new Wall(12, 6);
            _labirynth.Board[13, 6] = new Wall(13, 6);
            _labirynth.Board[14, 6] = new Wall(14, 6);
            _labirynth.Board[15, 6] = new Wall(15, 6);
            _labirynth.Board[16, 6] = new Wall(16, 6);
            _labirynth.Board[17, 6] = new Wall(17, 6);
            _labirynth.Board[18, 6] = new Wall(18, 6);
            _labirynth.Board[19, 6] = new Wall(19, 6);
            _labirynth.Board[20, 6] = new Wall(20, 6);
            _labirynth.Board[21, 6] = new Wall(21, 6);
            _labirynth.Board[22, 6] = new Wall(22, 6);
            _labirynth.Board[23, 6] = new Wall(23, 6);
            _labirynth.Board[24, 6] = new Wall(24, 6);
            _labirynth.Board[25, 5] = new Wall(25, 5);
            _labirynth.Board[25, 6] = new Wall(25, 6);

            _labirynth.Board[27, 5] = new Wall(27, 5);
            _labirynth.Board[27, 6] = new Wall(27, 6);

            //8 i 9 rzad

            _labirynth.Board[2, 7] = new Wall(2, 7);
            _labirynth.Board[2, 8] = new Wall(2, 8);

            _labirynth.Board[4, 8] = new Wall(4, 8);

            _labirynth.Board[5, 7] = new Wall(5, 7);
            _labirynth.Board[6, 7] = new Wall(6, 7);
            _labirynth.Board[6, 8] = new Wall(6, 8);
            _labirynth.Board[7, 7] = new Wall(7, 7);
            _labirynth.Board[8, 7] = new Wall(8, 7);

            _labirynth.Board[10, 8] = new Wall(10, 8);
            _labirynth.Board[11, 8] = new Wall(11, 8);
            _labirynth.Board[12, 8] = new Wall(12, 8);
            _labirynth.Board[13, 8] = new Wall(13, 8);
            _labirynth.Board[14, 8] = new Wall(14, 8);
            _labirynth.Board[15, 8] = new Wall(15, 8);
            _labirynth.Board[16, 8] = new Wall(16, 8);

            _labirynth.Board[18, 7] = new Wall(18, 7);
            _labirynth.Board[18, 8] = new Wall(18, 8);

            _labirynth.Board[20, 8] = new Wall(20, 8);
            _labirynth.Board[21, 8] = new Wall(21, 8);
            _labirynth.Board[22, 8] = new Wall(22, 8);
            _labirynth.Board[23, 8] = new Wall(23, 8);

            _labirynth.Board[25, 7] = new Wall(25, 7);
            _labirynth.Board[25, 8] = new Wall(25, 8);

            _labirynth.Board[27, 7] = new Wall(27, 7);
            _labirynth.Board[27, 8] = new Wall(27, 8);


            //10 i 11 rzad


            _labirynth.Board[2, 10] = new Wall(2, 10);

            _labirynth.Board[4, 9] = new Wall(4, 9);
            _labirynth.Board[4, 10] = new Wall(4, 10);

            _labirynth.Board[6, 9] = new Wall(6, 9);
            _labirynth.Board[6, 10] = new Wall(6, 10);

            _labirynth.Board[8, 9] = new Wall(8, 9);
            _labirynth.Board[8, 10] = new Wall(8, 10);
            _labirynth.Board[9, 9] = new Wall(9, 9);
            _labirynth.Board[9, 10] = new Wall(9, 10);

            _labirynth.Board[11, 10] = new Wall(11, 10);

            _labirynth.Board[13, 9] = new Wall(13, 9);

            _labirynth.Board[14, 10] = new Wall(14, 10);

            _labirynth.Board[16, 9] = new Wall(16, 9);
            _labirynth.Board[16, 10] = new Wall(16, 10);

            _labirynth.Board[18, 9] = new Wall(18, 9);
            _labirynth.Board[18, 10] = new Wall(18, 10);

            _labirynth.Board[20, 10] = new Wall(20, 10);

            _labirynth.Board[22, 9] = new Wall(22, 9);
            _labirynth.Board[23, 9] = new Wall(23, 9);

            _labirynth.Board[25, 9] = new Wall(25, 9);
            _labirynth.Board[25, 10] = new Wall(25, 10);

            _labirynth.Board[27, 9] = new Wall(27, 9);
            _labirynth.Board[27, 10] = new Wall(27, 10);

            //12 i 13 rzad

            _labirynth.Board[2, 11] = new Wall(2, 11);
            _labirynth.Board[2, 12] = new Wall(2, 12);

            _labirynth.Board[4, 11] = new Wall(4, 11);
            _labirynth.Board[4, 12] = new Wall(4, 12);

            _labirynth.Board[6, 11] = new Wall(6, 11);
            _labirynth.Board[6, 12] = new Wall(6, 12);

            _labirynth.Board[8, 11] = new Wall(8, 11);
            _labirynth.Board[8, 12] = new Wall(8, 12);

            _labirynth.Board[10, 12] = new Wall(10, 12);

            _labirynth.Board[11, 11] = new Wall(11, 11);
            _labirynth.Board[12, 11] = new Wall(12, 11);

            _labirynth.Board[14, 11] = new Wall(14, 11);
            _labirynth.Board[14, 12] = new Wall(14, 12);

            _labirynth.Board[16, 11] = new Wall(16, 11);

            _labirynth.Board[18, 11] = new Wall(18, 11);
            _labirynth.Board[18, 12] = new Wall(18, 12);

            _labirynth.Board[20, 11] = new Wall(20, 11);
            _labirynth.Board[20, 12] = new Wall(20, 12);

            _labirynth.Board[21, 11] = new Wall(21, 11);

            _labirynth.Board[23, 11] = new Wall(23, 11);
            _labirynth.Board[23, 12] = new Wall(23, 12);

            _labirynth.Board[25, 12] = new Wall(25, 12);
            _labirynth.Board[26, 12] = new Wall(26, 12);
            _labirynth.Board[27, 11] = new Wall(27, 11);
            _labirynth.Board[27, 12] = new Wall(27, 12);

            //14 i 15 rzad

            _labirynth.Board[2, 13] = new Wall(2, 13);
            _labirynth.Board[2, 14] = new Wall(2, 14);

            _labirynth.Board[4, 13] = new Wall(4, 13);
            _labirynth.Board[4, 14] = new Wall(4, 14);

            _labirynth.Board[6, 13] = new Wall(6, 13);
            _labirynth.Board[6, 14] = new Wall(6, 14);

            _labirynth.Board[8, 13] = new Wall(8, 13);

            _labirynth.Board[10, 13] = new Wall(10, 13);
            _labirynth.Board[11, 13] = new Wall(11, 13);
            _labirynth.Board[12, 13] = new Wall(12, 13);
            _labirynth.Board[13, 13] = new Wall(13, 13);
            _labirynth.Board[14, 13] = new Wall(14, 13);

            _labirynth.Board[16, 13] = new Wall(16, 13);
            _labirynth.Board[16, 14] = new Wall(16, 14);

            _labirynth.Board[18, 13] = new Wall(18, 13);
            _labirynth.Board[18, 14] = new Wall(18, 14);

            _labirynth.Board[19, 14] = new Wall(19, 14);

            _labirynth.Board[21, 13] = new Wall(21, 13);
            _labirynth.Board[21, 14] = new Wall(21, 14);

            _labirynth.Board[22, 13] = new Wall(22, 13);
            _labirynth.Board[23, 13] = new Wall(23, 13);

            _labirynth.Board[25, 13] = new Wall(25, 13);
            _labirynth.Board[25, 14] = new Wall(25, 14);

            _labirynth.Board[27, 13] = new Wall(27, 13);
            _labirynth.Board[27, 14] = new Wall(27, 14);


            //16 i 17 rzad

            _labirynth.Board[2, 15] = new Wall(2, 15);
            _labirynth.Board[2, 16] = new Wall(2, 16);
            _labirynth.Board[3, 16] = new Wall(3, 16);
            _labirynth.Board[4, 16] = new Wall(4, 16);
            _labirynth.Board[5, 16] = new Wall(5, 16);
            _labirynth.Board[6, 15] = new Wall(6, 15);
            _labirynth.Board[6, 16] = new Wall(6, 16);
            _labirynth.Board[7, 16] = new Wall(7, 16);
            _labirynth.Board[8, 15] = new Wall(8, 15);
            _labirynth.Board[8, 16] = new Wall(8, 16);

            _labirynth.Board[9, 15] = new Wall(9, 15);
            _labirynth.Board[10, 15] = new Wall(10, 15);

            _labirynth.Board[12, 15] = new Wall(12, 15);

            _labirynth.Board[13, 16] = new Wall(13, 16);

            _labirynth.Board[14, 15] = new Wall(14, 15);
            _labirynth.Board[14, 16] = new Wall(14, 16);

            _labirynth.Board[15, 15] = new Wall(15, 15);

            _labirynth.Board[16, 15] = new Wall(16, 15);
            _labirynth.Board[16, 16] = new Wall(16, 16);

            _labirynth.Board[18, 15] = new Wall(18, 15);
            _labirynth.Board[18, 16] = new Wall(18, 16);

            _labirynth.Board[20, 16] = new Wall(20, 16);

            _labirynth.Board[21, 15] = new Wall(21, 15);
            _labirynth.Board[21, 16] = new Wall(21, 16);

            _labirynth.Board[23, 15] = new Wall(23, 15);
            _labirynth.Board[24, 15] = new Wall(24, 15);
            _labirynth.Board[25, 15] = new Wall(25, 15);

            _labirynth.Board[27, 16] = new Wall(27, 16);

            //18 i 19 rzad

            _labirynth.Board[1, 18] = new Wall(1, 18);
            _labirynth.Board[2, 18] = new Wall(2, 18);
            _labirynth.Board[3, 18] = new Wall(3, 18);
            _labirynth.Board[4, 18] = new Wall(4, 18);
            _labirynth.Board[5, 18] = new Wall(5, 18);
            _labirynth.Board[6, 18] = new Wall(6, 18);

            _labirynth.Board[8, 17] = new Wall(8, 17);
            _labirynth.Board[8, 18] = new Wall(8, 18);

            _labirynth.Board[10, 17] = new Wall(10, 17);

            _labirynth.Board[11, 17] = new Wall(11, 17);
            _labirynth.Board[11, 18] = new Wall(11, 18);

            _labirynth.Board[13, 17] = new Wall(13, 17);
            _labirynth.Board[13, 18] = new Wall(13, 18);

            _labirynth.Board[15, 18] = new Wall(15, 18);

            _labirynth.Board[17, 18] = new Wall(17, 18);

            _labirynth.Board[18, 17] = new Wall(18, 17);

            _labirynth.Board[20, 18] = new Wall(20, 18);

            _labirynth.Board[22, 17] = new Wall(22, 17);
            _labirynth.Board[23, 17] = new Wall(23, 17);
            _labirynth.Board[24, 17] = new Wall(24, 17);
            _labirynth.Board[25, 17] = new Wall(25, 17);
            _labirynth.Board[26, 17] = new Wall(26, 17);
            _labirynth.Board[27, 17] = new Wall(27, 17);

            //20 i 21 rzad

            _labirynth.Board[2, 20] = new Wall(2, 20);

            _labirynth.Board[4, 20] = new Wall(4, 20);

            _labirynth.Board[6, 20] = new Wall(6, 20);
            _labirynth.Board[7, 20] = new Wall(7, 20);

            _labirynth.Board[9, 19] = new Wall(9, 19);

            _labirynth.Board[11, 19] = new Wall(11, 19);
            _labirynth.Board[11, 20] = new Wall(11, 20);

            _labirynth.Board[12, 20] = new Wall(12, 20);
            _labirynth.Board[13, 20] = new Wall(13, 20);

            _labirynth.Board[15, 19] = new Wall(15, 19);

            _labirynth.Board[17, 19] = new Wall(17, 19);
            _labirynth.Board[17, 20] = new Wall(17, 20);

            _labirynth.Board[19, 19] = new Wall(19, 19);
            _labirynth.Board[20, 19] = new Wall(20, 19);
            _labirynth.Board[21, 19] = new Wall(21, 19);
            _labirynth.Board[22, 19] = new Wall(22, 19);
            _labirynth.Board[23, 19] = new Wall(23, 19);
            _labirynth.Board[24, 19] = new Wall(24, 19);

            _labirynth.Board[26, 19] = new Wall(26, 19);
            _labirynth.Board[27, 19] = new Wall(27, 19);
            _labirynth.Board[28, 19] = new Wall(28, 19);


            //22 i 23 rzad

            _labirynth.Board[2, 21] = new Wall(2, 21);
            _labirynth.Board[2, 22] = new Wall(2, 22);

            _labirynth.Board[3, 22] = new Wall(3, 22);
            _labirynth.Board[4, 22] = new Wall(4, 22);
            _labirynth.Board[5, 22] = new Wall(5, 22);

            _labirynth.Board[7, 21] = new Wall(7, 21);
            _labirynth.Board[7, 22] = new Wall(7, 22);

            _labirynth.Board[9, 21] = new Wall(9, 21);
            _labirynth.Board[9, 22] = new Wall(9, 22);

            _labirynth.Board[10, 22] = new Wall(10, 22);

            _labirynth.Board[12, 21] = new Wall(12, 21);
            _labirynth.Board[12, 22] = new Wall(12, 22);

            _labirynth.Board[14, 22] = new Wall(14, 22);

            _labirynth.Board[15, 21] = new Wall(15, 21);

            _labirynth.Board[17, 21] = new Wall(17, 21);
            _labirynth.Board[18, 21] = new Wall(18, 21);
            _labirynth.Board[19, 21] = new Wall(19, 21);
            _labirynth.Board[20, 21] = new Wall(20, 21);

            _labirynth.Board[21, 22] = new Wall(21, 22);

            _labirynth.Board[22, 21] = new Wall(22, 21);
            _labirynth.Board[23, 21] = new Wall(23, 21);
            _labirynth.Board[24, 21] = new Wall(24, 21);
            _labirynth.Board[25, 21] = new Wall(25, 21);
            _labirynth.Board[26, 21] = new Wall(26, 21);
            _labirynth.Board[27, 21] = new Wall(27, 21);
            _labirynth.Board[27, 22] = new Wall(27, 22);


            //24 i 25 rzad

            _labirynth.Board[1, 24] = new Wall(1, 24);
            _labirynth.Board[2, 24] = new Wall(2, 24);
            _labirynth.Board[3, 24] = new Wall(3, 24);

            _labirynth.Board[5, 24] = new Wall(5, 24);

            _labirynth.Board[7, 24] = new Wall(7, 24);

            _labirynth.Board[9, 23] = new Wall(9, 23);

            _labirynth.Board[11, 24] = new Wall(11, 24);

            _labirynth.Board[13, 23] = new Wall(13, 23);
            _labirynth.Board[14, 23] = new Wall(14, 23);

            _labirynth.Board[16, 23] = new Wall(16, 23);
            _labirynth.Board[17, 23] = new Wall(17, 23);
            _labirynth.Board[18, 23] = new Wall(18, 23);
            _labirynth.Board[18, 24] = new Wall(18, 24);
            _labirynth.Board[19, 23] = new Wall(19, 23);
            _labirynth.Board[19, 24] = new Wall(19, 24);

            _labirynth.Board[21, 23] = new Wall(21, 23);
            _labirynth.Board[21, 24] = new Wall(21, 24);

            _labirynth.Board[23, 23] = new Wall(23, 23);
            _labirynth.Board[23, 24] = new Wall(23, 24);

            _labirynth.Board[25, 23] = new Wall(25, 23);
            _labirynth.Board[25, 24] = new Wall(25, 24);

            _labirynth.Board[27, 23] = new Wall(27, 23);
            _labirynth.Board[27, 24] = new Wall(27, 24);

            //26 i 27 rzad

            _labirynth.Board[2, 26] = new Wall(2, 26);

            _labirynth.Board[3, 25] = new Wall(3, 25);

            _labirynth.Board[5, 25] = new Wall(5, 25);
            _labirynth.Board[5, 26] = new Wall(5, 26);

            _labirynth.Board[7, 26] = new Wall(7, 26);

            _labirynth.Board[9, 25] = new Wall(9, 25);
            _labirynth.Board[9, 26] = new Wall(9, 26);

            _labirynth.Board[11, 25] = new Wall(11, 25);

            _labirynth.Board[12, 25] = new Wall(12, 25);
            _labirynth.Board[12, 26] = new Wall(12, 26);

            _labirynth.Board[13, 25] = new Start(13, 25);
            _labirynth.Board[13, 26] = new Wall(13, 26);

            _labirynth.Board[14, 25] = new Wall(14, 25);
            _labirynth.Board[14, 26] = new Wall(14, 26);

            _labirynth.Board[15, 25] = new Wall(15, 25);
            _labirynth.Board[15, 26] = new Wall(15, 26);

            _labirynth.Board[16, 25] = new Wall(16, 25);
            _labirynth.Board[16, 26] = new Wall(16, 26);

            _labirynth.Board[18, 25] = new Wall(18, 25);
            _labirynth.Board[18, 26] = new Wall(18, 26);

            _labirynth.Board[20, 26] = new Wall(20, 26);

            _labirynth.Board[22, 25] = new Wall(22, 25);
            _labirynth.Board[23, 25] = new Wall(23, 25);
            _labirynth.Board[24, 25] = new Wall(24, 25);

            _labirynth.Board[26, 26] = new Wall(26, 26);

            _labirynth.Board[27, 25] = new Wall(27, 25);
            _labirynth.Board[27, 26] = new Wall(27, 26);


            //28 i 29 rzad

            _labirynth.Board[2, 27] = new Wall(2, 27);
            _labirynth.Board[3, 27] = new Wall(3, 27);
            _labirynth.Board[4, 27] = new Wall(4, 27);
            _labirynth.Board[5, 27] = new Wall(5, 27);
            _labirynth.Board[6, 27] = new Wall(6, 27);
            _labirynth.Board[7, 27] = new Wall(7, 27);

            _labirynth.Board[9, 27] = new Wall(9, 27);
            _labirynth.Board[10, 27] = new Wall(10, 27);

            _labirynth.Board[12, 27] = new Wall(12, 27);

            _labirynth.Board[14, 28] = new Wall(14, 28);

            _labirynth.Board[16, 27] = new Wall(16, 27);

            _labirynth.Board[18, 27] = new Wall(18, 27);

            _labirynth.Board[20, 27] = new Wall(20, 27);
            _labirynth.Board[21, 27] = new Wall(21, 27);
            _labirynth.Board[22, 27] = new Wall(22, 27);
            _labirynth.Board[23, 27] = new Wall(23, 27);
            _labirynth.Board[24, 27] = new Wall(24, 27);
            _labirynth.Board[25, 27] = new Wall(25, 27);
            _labirynth.Board[26, 27] = new Wall(26, 27);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!_ant.selectMove(_labirynth))
            {
                counter++;
                iterator.Text = $"Mrówek które przeżyły tą mękę razem ze mną było: {counter}";
                _ant = new Ant(_startCoordinates.X, _startCoordinates.Y);

            }
            LostFeromon();

            RefreshView();

        }


        private void LostFeromon()
        {
            foreach (var item in _labirynth.Board)
            {
                if (item is Feromon f)
                {
                    if (f.Ant == _ant)
                    {
                        f.Value -= 10;
                    }
                    else
                    {
                        f.Value -= 1;

                    }
                    if (f.Value <= 0)
                    {
                        var x = item.X;
                        var y = item.Y;
                        _labirynth.Board[x, y] = new Field(x, y);
                    }


                }

            }
        }
    }
}
