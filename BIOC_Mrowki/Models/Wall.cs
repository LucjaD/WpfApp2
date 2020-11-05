using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIOC_mrowki.Models
{
    public class Wall : Field
    {
        public override Color Color { get => Color.Black; }
        public Wall(int x, int y) : base(x, y)
        {
        }
    }
}
