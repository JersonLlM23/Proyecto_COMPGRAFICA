using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caiza_Carlos_Leccion1
{
    internal abstract class Figure
    {
        public double rotation = 0;
        public float scale = 1;
        public PointF position = new Point(0, 0);

        public abstract void draw(PictureBox canvas);
    }
}
