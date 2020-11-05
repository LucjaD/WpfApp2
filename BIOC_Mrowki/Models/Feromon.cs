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
        public Feromon(int x, int y, int value) : base(x, y)
        {
            Value = value;
        }
    }
}
