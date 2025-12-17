using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using PROYECTO_U2_CCLl.Modelo;

namespace PROYECTO_U2_CCLl.Controlador
{
    public class RenderizadorGDI
    {
        private readonly Graphics _g;
        private readonly int _width;
        private readonly int _height;

        // Cámara orbital simple
        private float _camRotXDeg = 20f;
        private float _camRotYDeg = 20f;
        private float _zoom = 1f;

        public RenderizadorGDI(Graphics g, int width, int height)
        {
            _g = g;
            _width = width;
            _height = height;
            _g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public void ActualizarRotacionCamara(float rotXDeg, float rotYDeg)
        {
            _camRotXDeg = rotXDeg;
            _camRotYDeg = rotYDeg;
        }

        public void ActualizarZoom(float zoom)
        {
            if (zoom < 0.1f) zoom = 0.1f;
            if (zoom > 10f) zoom = 10f;
            _zoom = zoom;
        }

        public void Limpiar(Color color)
        {
            _g.Clear(color);
        }

        public void DibujarEjes(int size)
        {
            var origen = Proyectar(new Vector3(0, 0, 0));
            var x = Proyectar(new Vector3(size, 0, 0));
            var y = Proyectar(new Vector3(0, size, 0));
            var z = Proyectar(new Vector3(0, 0, size));

            using (var pX = new Pen(Color.Red, 2)) _g.DrawLine(pX, origen, x);
            using (var pY = new Pen(Color.Lime, 2)) _g.DrawLine(pY, origen, y);
            using (var pZ = new Pen(Color.CornflowerBlue, 2)) _g.DrawLine(pZ, origen, z);
        }

        public void DibujarPiramide(float posX, float posY, float posZ,
                                     float baseSize, float altura,
                                     Color color, float rotXDeg, float rotYDeg, float rotZDeg,
                                     TipoMaterial material = TipoMaterial.Solido)
        {
            // Base cuadrada centrada en el origen local
            float half = baseSize / 2f;
            Vector3[] vertices = new Vector3[]
            {
                new Vector3(-half, 0, -half), // v0
                new Vector3( half, 0, -half), // v1
                new Vector3( half, 0,  half), // v2
                new Vector3(-half, 0,  half), // v3
                new Vector3( 0,    altura, 0) // v4 apex
            };

            // Transformación local: rotaciones
            Matrix3 rot = Matrix3.RotationZ(Deg2Rad(rotZDeg)) *
                          Matrix3.RotationY(Deg2Rad(rotYDeg)) *
                          Matrix3.RotationX(Deg2Rad(rotXDeg));
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = rot * vertices[i];

            // Traslación mundial
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = vertices[i] + new Vector3(posX, posY, posZ);

            // Proyección
            PointF[] pts = new PointF[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
                pts[i] = Proyectar(vertices[i]);

            if (material == TipoMaterial.Wireframe)
            {
                DibujarWireframe(pts, color);
            }
            else if (material == TipoMaterial.Solido)
            {
                DibujarSolido(pts, color);
            }
            else if (material == TipoMaterial.Translucido)
            {
                DibujarTranslucido(pts, color);
            }
            else // Phong
            {
                DibujarSolido(pts, color); // Por ahora igual a sólido; luego agregar iluminación
            }
        }

        private void DibujarWireframe(PointF[] pts, Color color)
        {
            using (var pen = new Pen(color, 2))
            {
                // Base
                _g.DrawLine(pen, pts[0], pts[1]);
                _g.DrawLine(pen, pts[1], pts[2]);
                _g.DrawLine(pen, pts[2], pts[3]);
                _g.DrawLine(pen, pts[3], pts[0]);

                // Caras hacia vértice
                _g.DrawLine(pen, pts[0], pts[4]);
                _g.DrawLine(pen, pts[1], pts[4]);
                _g.DrawLine(pen, pts[2], pts[4]);
                _g.DrawLine(pen, pts[3], pts[4]);
            }

            // Dibujar vértices como puntos
            using (var brush = new SolidBrush(color))
            {
                foreach (var pt in pts)
                {
                    _g.FillEllipse(brush, pt.X - 3, pt.Y - 3, 6, 6);
                }
            }
        }

        private void DibujarSolido(PointF[] pts, Color color)
        {
            using (var brush = new SolidBrush(color))
            using (var pen = new Pen(Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B), 1))
            {
                // Dibujar caras como polígonos (aproximación simple)
                // Base
                PointF[] base4 = new[] { pts[0], pts[1], pts[2], pts[3] };
                _g.FillPolygon(brush, base4);
                _g.DrawPolygon(pen, base4);

                // Caras triangulares hacia el vértice
                PointF[] cara1 = new[] { pts[0], pts[1], pts[4] };
                PointF[] cara2 = new[] { pts[1], pts[2], pts[4] };
                PointF[] cara3 = new[] { pts[2], pts[3], pts[4] };
                PointF[] cara4 = new[] { pts[3], pts[0], pts[4] };

                _g.FillPolygon(brush, cara1);
                _g.DrawPolygon(pen, cara1);
                _g.FillPolygon(brush, cara2);
                _g.DrawPolygon(pen, cara2);
                _g.FillPolygon(brush, cara3);
                _g.DrawPolygon(pen, cara3);
                _g.FillPolygon(brush, cara4);
                _g.DrawPolygon(pen, cara4);
            }
        }

        private void DibujarTranslucido(PointF[] pts, Color color)
        {
            Color colorTrans = Color.FromArgb(128, color); // 50% transparencia
            using (var brush = new SolidBrush(colorTrans))
            using (var pen = new Pen(color, 2))
            {
                // Base
                PointF[] base4 = new[] { pts[0], pts[1], pts[2], pts[3] };
                _g.FillPolygon(brush, base4);
                _g.DrawPolygon(pen, base4);

                // Caras triangulares
                PointF[] cara1 = new[] { pts[0], pts[1], pts[4] };
                PointF[] cara2 = new[] { pts[1], pts[2], pts[4] };
                PointF[] cara3 = new[] { pts[2], pts[3], pts[4] };
                PointF[] cara4 = new[] { pts[3], pts[0], pts[4] };

                _g.FillPolygon(brush, cara1);
                _g.DrawPolygon(pen, cara1);
                _g.FillPolygon(brush, cara2);
                _g.DrawPolygon(pen, cara2);
                _g.FillPolygon(brush, cara3);
                _g.DrawPolygon(pen, cara3);
                _g.FillPolygon(brush, cara4);
                _g.DrawPolygon(pen, cara4);
            }
        }

        private PointF Proyectar(Vector3 v)
        {
            // Cámara: rotación orbital aplicada a la escena (equivalente a rotar el mundo)
            Matrix3 cam = Matrix3.RotationY(Deg2Rad(_camRotYDeg)) *
                          Matrix3.RotationX(Deg2Rad(_camRotXDeg));
            Vector3 vc = cam * v;

            // Proyección en perspectiva simple
            float fov = 1.0f; // escala de perspectiva
            float z = vc.Z + 300f; // desplazar para que esté delante
            float invz = 1f / Math.Max(1f, z);
            float sx = (_width / 2f) + vc.X * fov * invz * 200f * _zoom;
            float sy = (_height / 2f) - vc.Y * fov * invz * 200f * _zoom;
            return new PointF(sx, sy);
        }

        private static float Deg2Rad(float deg) => (float)(Math.PI / 180.0) * deg;

        private struct Vector3
        {
            public float X, Y, Z;
            public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }
            public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        private struct Matrix3
        {
            // Column-major 3x3
            public float m00, m01, m02;
            public float m10, m11, m12;
            public float m20, m21, m22;

            public static Matrix3 RotationX(float rad)
            {
                float c = (float)Math.Cos(rad), s = (float)Math.Sin(rad);
                return new Matrix3
                {
                    m00 = 1,
                    m01 = 0,
                    m02 = 0,
                    m10 = 0,
                    m11 = c,
                    m12 = -s,
                    m20 = 0,
                    m21 = s,
                    m22 = c
                };
            }
            public static Matrix3 RotationY(float rad)
            {
                float c = (float)Math.Cos(rad), s = (float)Math.Sin(rad);
                return new Matrix3
                {
                    m00 = c,
                    m01 = 0,
                    m02 = s,
                    m10 = 0,
                    m11 = 1,
                    m12 = 0,
                    m20 = -s,
                    m21 = 0,
                    m22 = c
                };
            }
            public static Matrix3 RotationZ(float rad)
            {
                float c = (float)Math.Cos(rad), s = (float)Math.Sin(rad);
                return new Matrix3
                {
                    m00 = c,
                    m01 = -s,
                    m02 = 0,
                    m10 = s,
                    m11 = c,
                    m12 = 0,
                    m20 = 0,
                    m21 = 0,
                    m22 = 1
                };
            }

            public static Vector3 operator *(Matrix3 m, Vector3 v)
            {
                return new Vector3(
                    m.m00 * v.X + m.m01 * v.Y + m.m02 * v.Z,
                    m.m10 * v.X + m.m11 * v.Y + m.m12 * v.Z,
                    m.m20 * v.X + m.m21 * v.Y + m.m22 * v.Z
                );
            }

            public static Matrix3 operator *(Matrix3 a, Matrix3 b)
            {
                return new Matrix3
                {
                    m00 = a.m00 * b.m00 + a.m01 * b.m10 + a.m02 * b.m20,
                    m01 = a.m00 * b.m01 + a.m01 * b.m11 + a.m02 * b.m21,
                    m02 = a.m00 * b.m02 + a.m01 * b.m12 + a.m02 * b.m22,

                    m10 = a.m10 * b.m00 + a.m11 * b.m10 + a.m12 * b.m20,
                    m11 = a.m10 * b.m01 + a.m11 * b.m11 + a.m12 * b.m21,
                    m12 = a.m10 * b.m02 + a.m11 * b.m12 + a.m12 * b.m22,

                    m20 = a.m20 * b.m00 + a.m21 * b.m10 + a.m22 * b.m20,
                    m21 = a.m20 * b.m01 + a.m21 * b.m11 + a.m22 * b.m21,
                    m22 = a.m20 * b.m02 + a.m21 * b.m12 + a.m22 * b.m22
                };
            }
        }
    }
}