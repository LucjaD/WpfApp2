using BIOC_Mrowki.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIOC_mrowki.Models
{
    public class Ant : Field
    {
        private const int _lostFeromon = 10;
        bool backMode;

        public override Color Color => Color.Khaki;
        public Ant(int x, int y) : base(x, y)
        {

        }

        public bool Move(Labirynth labirynth, Point to)
        {
            if (labirynth.Board[to.X, to.Y] is Finish)
            {
                labirynth.Board[X, Y] = new Feromon(X, Y, _lostFeromon, this);
                return false;
            }
            if (!backMode)
            {
                labirynth.Board[to.X, to.Y] = this;
                labirynth.Board[X, Y] = new Feromon(X, Y, _lostFeromon, this);
                X = to.X;
                Y = to.Y;

            }
            else
            {
                labirynth.Board[to.X, to.Y] = this;
                labirynth.Board[X, Y] = new Field(X, Y);
                X = to.X;
                Y = to.Y;
            }
            return true;
        }

        public bool selectMove(Labirynth labirynth)
        {
            double p1 = 0;
            List<double> m1 = new List<double>();
            List<double> m2 = new List<double>();
            var points = getPossibleMoves(labirynth);
            var poss = new Random();
            var possInt = poss.Next(0, 99);
            var propability = 100 / points.Count;

            for (int i = 0; i < points.Count; i++)
            {
            //    if (labirynth.Board[points[i].X, points[i].Y] is Feromon f)
            //    {
            //        m1.Add(f.Value);
            //    }
            //    else
            //    {
            //        m2.Add(1);
            //    }
            //}
            //p1 = (Math.Pow(m1[i] + Feromon.k, Feromon.h)) / (Math.Pow(m1[i] + Feromon.k, Feromon.h) + Math.Pow(m2[i] + Feromon.k, Feromon.h));

            if (possInt >= i * propability && possInt <= (i + 1) * propability)
                {

                    return Move(labirynth, points[i]);
                }
            }
            throw new Exception();

        }

        public List<Point> getPossibleMoves(Labirynth labirynth)
        {

            var points = new List<Point>();
            if (!backMode)
            {


                if (X != labirynth.SizeX - 1 && isPermittedField(X+1, Y, labirynth))
                {
                    points.Add(new Point(X + 1, Y));
                }
                if (X != 0 && isPermittedField(X - 1, Y, labirynth))
                {
                    points.Add(new Point(X - 1, Y));

                }
                if (Y != 0 && isPermittedField(X, Y-1, labirynth))
                {
                    points.Add(new Point(X, Y - 1));

                }
                if (Y != labirynth.SizeY - 1 && isPermittedField(X, Y+1, labirynth))
                {
                    points.Add(new Point(X, Y + 1));

                }
            }
            if (points.Count == 0)
            {
                return GoBack(labirynth, points);


            }

            return points;

        }


        public bool isPermittedField(int X, int Y, Labirynth labirynth)
        {
            if (labirynth.Board[X, Y] is Wall) return false;
            if (labirynth.Board[X, Y] is Feromon f4 && f4.Ant == this) return false;
            return true;
        }

        public bool isFeromone(int X, int Y, Labirynth labirynth)
        {
            return labirynth.Board[X, Y] is Feromon;
        }





        public List<Point> GoBack(Labirynth labirynth, List<Point> points)
        {
            var backPoints = new List<Point>();
            backMode = true;
            int counter = 0;

            if (isPermittedField(X + 1, Y, labirynth))
            {
                counter++;
                backPoints.Add(new Point(X + 1, Y));
            }
            if (isPermittedField(X - 1, Y, labirynth))
            {
                counter++;
                backPoints.Add(new Point(X - 1, Y));
            }
            if (isPermittedField(X, Y-1, labirynth))
            {
                counter++;
                backPoints.Add(new Point(X, Y - 1));
            }
            if (isPermittedField(X , Y+1, labirynth))
            {
                counter++;
                backPoints.Add(new Point(X, Y + 1));
            }

            if (counter >= 2)
            {
                backMode = false;
                return backPoints;
            }


            if (isFeromone(X+1, Y, labirynth))
            {
                points.Add(new Point(X + 1, Y));

            }
            if (isFeromone(X - 1, Y, labirynth))
            {
                points.Add(new Point(X - 1, Y));

            }
            if (isFeromone(X , Y-1, labirynth))
            {
                points.Add(new Point(X, Y - 1));

            }
            if (isFeromone(X , Y + 1, labirynth))
            {
                points.Add(new Point(X, Y + 1));

            }
           
            return points;
        }

        
    }

}
