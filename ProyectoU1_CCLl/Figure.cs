using System.Drawing;
using System.Windows.Forms;

namespace ProyectoU1_CCLl
{
    internal abstract class Figure
    {
        public double rotation = 0;
        public float scale = 1;
        public PointF position = new PointF(0, 0);

        public abstract void draw(PictureBox canvas);
    }
}