using BIOC_mrowki.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIOC_Mrowki.Models
{
    public class Finish : Field
    {
        public Finish(int x, int y) : base(x, y)
        {
        }

        public override Color Color => Color.Red;
    }
}
