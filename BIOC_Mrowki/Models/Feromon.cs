using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIOC_mrowki.Models
{
    public class Feromon : Field
    {
        public int Value { get; set; }
        public override Color Color => Color.DarkKhaki;
        public Ant Ant { get; set; }

        public Feromon(int x, int y, int value, Ant ant) : base(x, y)
        {
            Value = value;
            Ant = ant;

        }
    }
}
