using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BIOC_mrowki.Models
{
    public class Labirynth
    {
        public int SizeY { get; }

        public Field[,] Board { get; }
        public int SizeX { get; }
        public Labirynth(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            Board = new Field[sizeX,sizeY];
        }
        public void FullFill()
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    Board[i, j] = new Field(i,j);
                }
            }
        }
    }
}
