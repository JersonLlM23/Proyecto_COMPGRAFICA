using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caiza_Carlos_Leccion1
{
    internal class Figure6 : Figure
    {
        public float radius =50;

        override public void draw(PictureBox canvas)
        {
            Graphics graph = canvas.CreateGraphics();
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Black))
            {
                const int LEVELS = 1;

                float scaled_r = radius * scale;

                PointF v1 = new PointF(scaled_r * (float)Math.Cos(this.rotation),
                    scaled_r * (float)Math.Sin(this.rotation));       // at 0° (1,0) (with no rotation)
                PointF v2 = new PointF(scaled_r * (float)Math.Cos(this.rotation + Math.PI / 3),
                    scaled_r * (float)Math.Sin(this.rotation + Math.PI / 3));    // at 60° (0.5, sqrt(3)/2) (with no rotation)

                int rings = LEVELS;
                int max_ring_draw = rings + 2;

                GraphicsState gs = graph.Save();
                using (GraphicsPath clipPath = new GraphicsPath())
                {
                    // ensure overlapping ellipses create a proper union (no holes)
                    clipPath.FillMode = FillMode.Winding;

                    float r_extra = scaled_r + 1; // space for the borders to draw properly
                    // inclusion areas
                    for (int i = -max_ring_draw; i <= max_ring_draw; i++)
                    {
                        for (int j = -max_ring_draw; j <= max_ring_draw; j++)
                        {
                            int k = -i - j;
                            int hexDist = Math.Max(Math.Max(Math.Abs(i), Math.Abs(j)), Math.Abs(k));
                            if (hexDist <= LEVELS)
                            {
                                float x = position.X + i * v1.X + j * v2.X;
                                float y = position.Y + i * v1.Y + j * v2.Y;
                                RectangleF circle = new RectangleF(x - r_extra, y - r_extra, r_extra * 2, r_extra * 2);
                                clipPath.AddEllipse(circle);
                            }
                        }
                    }
                    graph.Clear(Color.White);
                    graph.SetClip(clipPath, CombineMode.Replace);

                    for (int i = -max_ring_draw; i <= max_ring_draw; i++)
                    {
                        for (int j = -max_ring_draw; j <= max_ring_draw; j++)
                        {
                            int k = -i - j;

                            float x = position.X + i * v1.X + j * v2.X;
                            float y = position.Y + i * v1.Y + j * v2.Y;

                            float dx = x - position.X;
                            float dy = y - position.Y;

                            int hexDist = Math.Max(Math.Max(Math.Abs(i), Math.Abs(j)), Math.Abs(k));
                            if (hexDist <= max_ring_draw)
                            {
                                RectangleF circle = new RectangleF(x - scaled_r, y - scaled_r, scaled_r * 2, scaled_r * 2);
                                graph.DrawEllipse(pen, circle);
                            }
                        }
                    }
                    // restore previous clipping
                    graph.Restore(gs);

                    pen.DashPattern = new float[] { 4f, 2f };
                    graph.DrawEllipse(pen, position.X - scaled_r * (LEVELS + 1), position.Y - scaled_r * (LEVELS + 1),
                        scaled_r * (LEVELS + 1) * 2, scaled_r * (LEVELS + 1) * 2);

                }
            }
        }
    }
}
