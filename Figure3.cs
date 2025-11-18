using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Caiza_Carlos_Leccion1
{
    internal class Figure3: Figure
    {
        public float radius = 150;

        override public void draw(PictureBox canvas)
        {

            float star_inner_radius = radius / 2.618f;
            float star_fat_inner_radius = radius / 1.618f;
            float poligon_inner_radius = radius / 1.272f;
            float center_circle_radius = radius / 11;

            Graphics graph = canvas.CreateGraphics();
            graph.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Black))
            {
                GraphicsState gs_default = graph.Save();
                using (GraphicsPath clipPath_poligons = new GraphicsPath())
                using (GraphicsPath clipPath_lines = new GraphicsPath())
                using (GraphicsPath clipPath_diamonds = new GraphicsPath())
                using (GraphicsPath clipPath_center_circle = new GraphicsPath())
                {
                    graph.ResetTransform();
                    graph.RotateTransform((float)rotation, MatrixOrder.Append);
                    graph.ScaleTransform(scale, scale, MatrixOrder.Append);
                    graph.TranslateTransform(position.X, position.Y, MatrixOrder.Append);

                    // POLIGONS CLIP PATH
                    for (int i = 0; i < 5; i++)
                    {
                        const double angle_offset = 2 * Math.PI / 20;
                        double angle_start = 2 * (float)Math.PI / 5 * i + angle_offset;
                        double angle_end = 2 * (float)Math.PI / 5 * (i + 1) - angle_offset;

                        float radius_extra = radius * 1.1f;

                        PointF[] area = new PointF[] {
                            new PointF(0, 0),
                            new PointF((float)(radius_extra * Math.Cos(angle_start)), (float)(radius_extra * Math.Sin(angle_start))),
                            new PointF((float)(radius_extra * Math.Cos(angle_end)), (float)(radius_extra * Math.Sin(angle_end))),
                        };

                        //graph.FillPolygon(Brushes.Black, area);
                        clipPath_poligons.AddPolygon(area);

                    }
                    //LINE CLIP PATH
                    for (int i = 0; i < 5; i++)
                    {
                        double angle_start = 2 * (float)Math.PI / 5 * i;
                        double angle_end = 2 * (float)Math.PI / 5 * (i + 1);
                        float radius_extra = radius * 1.1f;
                        PointF[] area = new PointF[] {
                            new PointF(0, 0),
                            new PointF((float)(radius_extra * Math.Cos(angle_start)), (float)(radius_extra * Math.Sin(angle_start))),
                            new PointF((float)(radius_extra * Math.Cos(angle_end)), (float)(radius_extra * Math.Sin(angle_end))),
                        };
                        //graph.FillPolygon(Brushes.Black, area);
                        clipPath_lines.AddPolygon(area);
                    }
                    // DIAMONDS CLIP PATH
                    for (int i = 0; i < 5; i++)
                    {
                        double angle = 2 * Math.PI / 5 * i;
                        float s_base = (float)Math.Sin(angle);
                        float c_base = (float)Math.Cos(angle);


                        double angle_offset = Math.PI / 10;

                        double alpha = Math.PI / 2;
                        double gamma = Math.PI - angle_offset - alpha;
                        float displaced_radius = (float)(poligon_inner_radius / Math.Sin(gamma) * Math.Sin(alpha));

                        float s_start = (float)Math.Sin(angle - angle_offset);
                        float c_start = (float)Math.Cos(angle - angle_offset);

                        float s_end = (float)Math.Sin(angle + angle_offset);
                        float c_end = (float)Math.Cos(angle + angle_offset);

                        PointF[] area = new PointF[]
                        {
                            new PointF(radius * c_base, radius * s_base),
                            new PointF(displaced_radius * c_start, displaced_radius * s_start),
                            new PointF(star_fat_inner_radius * c_base, star_fat_inner_radius * s_base),
                            new PointF(displaced_radius * c_end, displaced_radius * s_end),
                        };
                        //graph.FillPolygon(Brushes.Black, area);
                        clipPath_diamonds.AddPolygon(area);

                    }
                    // CENTER CLIP PATH
                    clipPath_center_circle.AddEllipse(new RectangleF(0 - center_circle_radius, 0 - center_circle_radius,
                    center_circle_radius * 2, center_circle_radius * 2));



                    graph.Clear(Color.White);
                    //CENTER CIRCLE
                    graph.DrawEllipse(pen, 0 - center_circle_radius, 0 - center_circle_radius,
                        center_circle_radius * 2, center_circle_radius * 2);

                    graph.SetClip(clipPath_poligons);
                    // POLIGONS
                    for (int i = 0; i < 5; i++)
                    {
                        float angle_start = 2 * (float)Math.PI / 5 * i;
                        float angle_end = 2 * (float)Math.PI / 5 * (i + 1);
                        float angle_middle = 2 * (float)Math.PI / 5 * (i + 0.5f);

                        float ss = (float)Math.Sin(angle_start);
                        float se = (float)Math.Sin(angle_end);
                        float sm = (float)Math.Sin(angle_middle);
                        float cs = (float)Math.Cos(angle_start);
                        float ce = (float)Math.Cos(angle_end);
                        float cm = (float)Math.Cos(angle_middle);

                        // STAR
                        graph.DrawLine(
                            pen,
                            star_inner_radius * cs, star_inner_radius * ss,
                            radius * cm, radius * sm
                        );
                        graph.DrawLine(
                            pen,
                            radius * cm, radius * sm,
                            star_inner_radius * ce, star_inner_radius * se
                        );

                        //FAT STAR
                        graph.DrawLine(
                            pen,
                            star_fat_inner_radius * cs, star_fat_inner_radius * ss,
                            radius * cm, radius * sm
                        );
                        graph.DrawLine(
                            pen,
                            radius * cm, radius * sm,
                            star_fat_inner_radius * ce, star_fat_inner_radius * se
                        );
                        // POLIGON
                        graph.DrawLine(
                            pen,
                            poligon_inner_radius * cs, poligon_inner_radius * ss,
                            radius * cm, radius * sm
                        );
                        graph.DrawLine(
                            pen,
                            radius * cm, radius * sm,
                            poligon_inner_radius * ce, poligon_inner_radius * se
                        );

                    }

                    graph.SetClip(clipPath_lines);
                    graph.SetClip(clipPath_center_circle, CombineMode.Exclude);
                    graph.SetClip(clipPath_diamonds, CombineMode.Exclude);
                    // LINES
                    for (int i = 0; i < 5; i++)
                    {
                        double angle = 2 * Math.PI / 5 * i;

                        for (int j = -2; j < 3; j++)
                        {
                            double angle_offset = 2 * Math.PI / 40 * j;

                            double alpha = Math.PI / 2;
                            double gamma = Math.PI - angle_offset - alpha;
                            float current_radius = (float)(poligon_inner_radius / Math.Sin(gamma) * Math.Sin(alpha));

                            float s = (float)Math.Sin(angle + angle_offset);
                            float c = (float)Math.Cos(angle + angle_offset);
                            graph.DrawLine(
                                pen,
                                0, 0,
                                current_radius * c, current_radius * s
                            );

                        }
                    }

                    graph.ResetClip();
                    graph.SetClip(clipPath_center_circle, CombineMode.Exclude);
                    // DIAMONDS and the other lines idk
                    for (int i = 0; i < 5; i++)
                    {
                        double angle = 2 * Math.PI / 5 * i;
                        float s_base = (float)Math.Sin(angle);
                        float c_base = (float)Math.Cos(angle);

                        // DIAMONDS
                        for (int j = -2; j < 3; j++)
                        {
                            if (j == 0)
                                continue;   // no straight line

                            double angle_offset = 2 * Math.PI / 40 * j;

                            double alpha = Math.PI / 2;
                            double gamma = Math.PI - angle_offset - alpha;
                            float current_radius = (float)(poligon_inner_radius / Math.Sin(gamma) * Math.Sin(alpha));

                            float s_offset = (float)Math.Sin(angle + angle_offset);
                            float c_offset = (float)Math.Cos(angle + angle_offset);
                            graph.DrawLine(
                                pen,
                                star_fat_inner_radius * c_base, star_fat_inner_radius * s_base,
                                current_radius * c_offset, current_radius * s_offset
                            );
                            graph.DrawLine(
                                pen,
                                radius * c_base, radius * s_base,
                                current_radius * c_offset, current_radius * s_offset
                            );

                        }
                        //LINES
                        const double point_angle_difference = Math.PI / 10;
                        float side_point_distance = (float)(3 * center_circle_radius * Math.Sin(Math.PI - 2 * point_angle_difference) / Math.Sin(point_angle_difference));
                        float angle_l = 2 * (float)Math.PI / 5 * (i + 0.25f);
                        float angle_middle = 2 * (float)Math.PI / 5 * (i + 0.5f);
                        float angle_r = 2 * (float)Math.PI / 5 * (i + 0.75f);

                        float s_l = (float)Math.Sin(angle_l);
                        float c_l = (float)Math.Cos(angle_l);
                        float s_m = (float)Math.Sin(angle_middle);
                        float c_m = (float)Math.Cos(angle_middle);
                        float s_r = (float)Math.Sin(angle_r);
                        float c_r = (float)Math.Cos(angle_r);

                        graph.DrawLine(
                            pen,
                            0,0,
                            3 * center_circle_radius * c_m, 3 * center_circle_radius * s_m
                            );
                        graph.DrawLine(
                            pen,
                            3 * center_circle_radius * c_m, 3 * center_circle_radius * s_m,
                            side_point_distance * c_l, side_point_distance * s_l
                            );
                        graph.DrawLine(
                            pen,
                            3 * center_circle_radius * c_m, 3 * center_circle_radius * s_m,
                            side_point_distance * c_r, side_point_distance * s_r
                            );
                    }
                }
            }
        }

    }
}
