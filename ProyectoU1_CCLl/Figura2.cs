using ProyectoU1_CCLl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoU1_CCLl
{
    public partial class Figura2 : Form
    {
        private static Figura2 instancia = null;
        public static Figura2 Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                {
                    instancia = new Figura2();
                }
                return instancia;
            }
        }
        private Bitmap bitmapFig2;
        private Graphics graphicsFig2;

        // ====== RADIO Y TRANSFORMACIONES ======
        float R = 0f;          // radio actual (ya escalado)
        float R0 = 0f;         // radio original ingresado por el usuario
        float escala = 1f;     // factor de escala (1 = tamaño original)
        double rot = 0;        // rotación en radianes
        float offsetX = 0f;    // traslación en X
        float offsetY = 0f;    // traslación en Y
        const double DEG = Math.PI / 180.0;  // grados → radianes

        int pasoActual = 0;
        const int PASO_MAX = 11;

        public Figura2()
        {
            InitializeComponent();
        }

        void InitCanvas()
        {
            if (graphicsFig2 != null) graphicsFig2.Dispose();
            if (bitmapFig2 != null) bitmapFig2.Dispose();

            bitmapFig2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            graphicsFig2 = Graphics.FromImage(bitmapFig2);
            graphicsFig2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsFig2.Clear(Color.White);
        }

        PointF CentroBase() => new PointF(pictureBox2.Width / 2f, pictureBox2.Height / 2f);

        // Centro afectado por traslación
        PointF Centro()
        {
            var c0 = CentroBase();
            return new PointF(c0.X + offsetX, c0.Y + offsetY);
        }

        // =========================================
        // ========== PASO 1: ESTRELLA 5 ===========
        // =========================================

        // Estrella simple de 5 puntas (pentagrama)
        void Paso1_Estrella5()
        {
            var c = Centro();
            int n = 5;
            PointF[] pent = new PointF[n];

            double ang0 = Math.PI / 2;
            double step = 2 * Math.PI / n;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * step + rot;
                float r = R;
                float rr = r * escala;

                pent[i] = new PointF(
                    c.X + rr * (float)Math.Cos(ang),
                    c.Y - rr * (float)Math.Sin(ang));
            }

            int[] orden = { 0, 2, 4, 1, 3 };
            PointF[] estrella = new PointF[5];
            for (int i = 0; i < 5; i++)
                estrella[i] = pent[orden[i]];

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, estrella);

            pictureBox2.Image = bitmapFig2;
        }

        // PASO 2: Estrella de 5 puntas (verde)
        void Paso2_Estrella5()
        {
            var c = Centro();
            int n = 5;
            float k = 0.72f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k;

            PointF[] pts = new PointF[10];
            double ang0 = Math.PI / 2;
            double paso = Math.PI / 5.0;

            for (int i = 0; i < 10; i++)
            {
                double ang = ang0 + paso * i + rot;
                float r = (i % 2 == 0) ? Rint2 : Rext2;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 3: Estrella de 5 puntas (amarilla)
        void Paso3_Estrella5()
        {
            var c = Centro();
            int n = 5;

            float k2 = 1.0f;
            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float k3 = 0.53f;
            float Rext3 = Rint3 / k3;

            PointF[] pts = new PointF[10];

            double ang0 = Math.PI / 2;
            double paso = Math.PI / 5.0;

            for (int i = 0; i < 10; i++)
            {
                double ang = ang0 + paso * i + rot;
                float r = (i % 2 == 0) ? Rint3 : Rext3;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 4: Estrella de 5 puntas
        void Paso4_Estrella5()
        {
            var c = Centro();
            int n = 5;

            float k3 = 0.82f;
            float k2 = 0.88f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float Rint4 = Rext3;
            float k4 = 0.6f;
            float Rext4 = Rint4 / k4;

            PointF[] pts = new PointF[10];

            double ang0 = Math.PI / 2;
            double paso = Math.PI / 5.0;

            for (int i = 0; i < 10; i++)
            {
                double ang = ang0 + paso * i + rot;
                float r = (i % 2 == 0) ? Rext4 : Rint4;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 5: Estrella de 5 puntas negra
        void Paso5_Estrella5_Negra()
        {
            var c = Centro();
            int n = 5;

            float k4 = 0.88f;
            float k3 = 0.9f;
            float k2 = 0.9f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float Rint4 = Rext3;
            float Rext4 = Rint4 / k4;

            float Rint5 = Rext4;
            float k5 = 0.74f;
            float Rext5 = Rint5 / k5;

            PointF[] pts = new PointF[10];

            double ang0 = -Math.PI / 2;
            double paso = Math.PI / 5.0;

            for (int i = 0; i < 10; i++)
            {
                double ang = ang0 + paso * i + rot;
                float r = (i % 2 == 0) ? Rext5 : Rint5;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.0f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 6: Polígono regular de 10 lados
        void Paso6_Decagono()
        {
            var c = Centro();
            int n = 10;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float Rdec = Rext3 * 1.64f;

            PointF[] poly = new PointF[n];

            double ang0 = Math.PI / 2.0;
            double paso = 2 * Math.PI / n;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * paso + rot;
                float rr = Rdec;

                poly[i] = new PointF(
                    c.X + rr * (float)Math.Cos(ang),
                    c.Y - rr * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.0f))
                graphicsFig2.DrawPolygon(p, poly);
        }

        // PASO 7: Pentágono exterior
        void Paso7_Pentagono_Exterior()
        {
            var c = Centro();
            int n = 5;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float Rdec = Rext3 * 1.6f;
            float Rpent = Rdec * 1.7f;

            PointF[] pent = new PointF[n];

            double ang0 = Math.PI / 2.0;
            double paso = 2 * Math.PI / n;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * paso + rot;

                pent[i] = new PointF(
                    c.X + Rpent * (float)Math.Cos(ang),
                    c.Y - Rpent * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pent);
        }

        // PASO 8: Decágono exterior
        void Paso8_Decagono_Verde()
        {
            var c = Centro();
            int n = 10;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float RdecRojo = Rext3 * 1.65f;
            float RdecVerde = RdecRojo * 1.65f;

            PointF[] poly = new PointF[n];

            double paso = 2 * Math.PI / n;
            double ang0 = Math.PI / 2.0;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * paso + rot;

                poly[i] = new PointF(
                    c.X + RdecVerde * (float)Math.Cos(ang),
                    c.Y - RdecVerde * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, poly);
        }

        // PASO 9: Pentágono exterior inclinado (izquierda)
        void Paso9_Pentagono_Exterior_Inclinado()
        {
            var c = Centro();
            int n = 5;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float RdecRojo = Rext3 * 1.53f;
            float factorVerde = 1.19f;
            float RdecVerde = RdecRojo * factorVerde;

            float Rpent = RdecVerde * 2.01f;

            PointF[] pent = new PointF[n];

            double paso = 2 * Math.PI / n;
            double ang0 = Math.PI / 2.0 + 0.315;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * paso + rot;

                pent[i] = new PointF(
                    c.X + Rpent * (float)Math.Cos(ang),
                    c.Y - Rpent * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pent);
        }

        // PASO 10: Pentágono exterior inclinado (derecha)
        void Paso10_Pentagono_Exterior_Derecha()
        {
            var c = Centro();
            int n = 5;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float RdecRojo = Rext3 * 1.59f;
            float factorVerde = 1.15f;
            float RdecVerde = RdecRojo * factorVerde;

            float Rpent = RdecVerde * 2.01f;

            PointF[] pent = new PointF[n];

            double paso = 2 * Math.PI / n;
            double ang0 = Math.PI / 2.0 - 0.315;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * paso + rot;

                pent[i] = new PointF(
                    c.X + Rpent * (float)Math.Cos(ang),
                    c.Y - Rpent * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pent);
        }

        // PASO 11: Estrella de 10 puntas exterior
        void Paso11_Estrella10_Exterior()
        {
            var c0 = Centro();                   
            var c = new PointF(c0.X, c0.Y + 1);    

            int n = 10;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R * escala;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float RdecRojo = Rext3 * 1.76f;
            float factorVerde = 1.56f;
            float RdecVerde = RdecRojo * factorVerde;

            float RintStar = RdecVerde;
            float RextStar = RintStar * 1.33f;

            PointF[] pts = new PointF[n * 2];

            double pasoDec = 2 * Math.PI / n;
            double pasoStar = pasoDec / 2.0;
            double ang0Dec = Math.PI / 2.0;

            for (int i = 0; i < pts.Length; i++)
            {
                double ang = ang0Dec + i * pasoStar + rot;
                float r = (i % 2 == 0) ? RintStar : RextStar;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // ===== RENDER GENERAL =====
        void RenderPaso()
        {
            if (R0 <= 0) return;
            R = R0;

            InitCanvas();

            if (pasoActual >= 1) Paso1_Estrella5();
            if (pasoActual >= 2) Paso2_Estrella5();
            if (pasoActual >= 3) Paso3_Estrella5();
            if (pasoActual >= 4) Paso4_Estrella5();
            if (pasoActual >= 5) Paso5_Estrella5_Negra();
            if (pasoActual >= 6) Paso6_Decagono();
            if (pasoActual >= 7) Paso7_Pentagono_Exterior();
            if (pasoActual >= 8) Paso8_Decagono_Verde();
            if (pasoActual >= 9) Paso9_Pentagono_Exterior_Inclinado();
            if (pasoActual >= 10) Paso10_Pentagono_Exterior_Derecha();
            if (pasoActual >= 11) Paso11_Estrella10_Exterior();

            pictureBox2.Image = bitmapFig2;
        }

        // ================= EVENTOS =================

        private void btnGraficar2_Click(object sender, EventArgs e)
        {
            try
            {
                R0 = float.Parse(txtRadio2.Text);
                if (R0 <= 0)
                {
                    MessageBox.Show("El radio debe ser un número positivo mayor que cero.");
                    return;
                }
                escala = 1f;
                rot = 0;
                offsetX = 0;
                offsetY = 0;
                if (hScrollBar_Tamano2.Maximum > hScrollBar_Tamano2.Minimum)
                {
                    int mid = (hScrollBar_Tamano2.Maximum + hScrollBar_Tamano2.Minimum) / 2;
                    hScrollBar_Tamano2.Value = mid;
                }

                pasoActual = PASO_MAX;
                RenderPaso();
            }
            catch
            {
                MessageBox.Show("Ingrese un valor válido para el radio.");
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            txtRadio2.Text = "";
            if (graphicsFig2 != null) graphicsFig2.Dispose();
            if (bitmapFig2 != null) bitmapFig2.Dispose();
            pictureBox2.Image = null;
            pictureBox2.Refresh();

            R = 0f;
            R0 = 0f;
            pasoActual = 0;
            escala = 1f;
            rot = 0;
            offsetX = offsetY = 0;

            txtRadio2.Focus();
        }

        private void btn2Anterior_Click(object sender, EventArgs e)
        {
            if (R0 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar.");
                return;
            }

            pasoActual = Math.Max(0, pasoActual - 1);
            RenderPaso();
        }

        private void btn2Siguiente_Click(object sender, EventArgs e)
        {
            if (R0 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar.");
                return;
            }

            pasoActual = Math.Min(PASO_MAX, pasoActual + 1);
            RenderPaso();
        }
        
        private void hScrollBar_Tamano2_Scroll(object sender, ScrollEventArgs e)
        {
            if (R0 <= 0) return;

            int mid = (hScrollBar_Tamano2.Maximum + hScrollBar_Tamano2.Minimum) / 2;
            if (mid == 0) mid = 1;

            escala = hScrollBar_Tamano2.Value / (float)mid;
            RenderPaso();
        }
        
        private void btnAntiHorario2_Click(object sender, EventArgs e)
        {
            if (R0 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar.");
                return;
            }

            rot += 5 * DEG;
            RenderPaso();
        }        
        private void btnHorario2_Click(object sender, EventArgs e)
        {
            if (R0 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar.");
                return;
            }

            rot -= 5 * DEG;
            RenderPaso();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (R0 <= 0)
                return base.ProcessCmdKey(ref msg, keyData);

            const float paso = 5f;

            switch (keyData)
            {
                case Keys.Up:
                    offsetY -= paso;
                    RenderPaso();
                    return true;
                case Keys.Down:
                    offsetY += paso;
                    RenderPaso();
                    return true;
                case Keys.Left:
                    offsetX -= paso;
                    RenderPaso();
                    return true;
                case Keys.Right:
                    offsetX += paso;
                    RenderPaso();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtRadio2_TextChanged(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void Figura2_Load(object sender, EventArgs e)
        {

        }
    }
}
