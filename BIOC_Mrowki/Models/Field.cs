using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BIOC_mrowki.Models
{
    public class Field
    {
        public virtual Color Color { get => Color.White; }

        public int With => 40;
        public int Height => 40;

        public int X { get; set; }
        public int Y { get; set; }
        public Feromon F { get; set; }

        public Field( int x, int y)
        {
            X = x;
            Y = y;

        }
    }
}
