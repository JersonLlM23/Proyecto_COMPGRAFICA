using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fig1_2_proyecto_Parcial1
{
    public partial class Figuras1_2 : Form
    {
        // ==========================
        // ====== FIGURA 1 ==========
        // ==========================

        private Bitmap bitmapMandala;
        private Graphics graphicsMandala;

        float R1 = 0f;           // radio figura 1
        int pasoActual1 = 0;
        const int PASO_MAX1 = 7;

        // Transformaciones fig1
        float cx1, cy1;          // centro actual en fig1
        float escala1 = 1f;      // escala fig1
        float rot1 = 0f;         // rotación fig1 en radianes

        // ==========================
        // ====== FIGURA 2 ==========
        // ==========================

        private Bitmap bitmapFig2;
        private Graphics graphicsFig2;

        float R2 = 0f;           // radio actual (ya escalado) fig2
        float R20 = 0f;          // radio original fig2
        float escala2 = 1f;      // escala fig2
        double rot2 = 0;         // rotación fig2 en radianes
        float offsetX2 = 0f;     // traslación X fig2
        float offsetY2 = 0f;     // traslación Y fig2

        // Constante grados→radianes (común)
        const double DEG = Math.PI / 180.0;

        int pasoActual2 = 0;
        const int PASO_MAX2 = 11;

        public Figuras1_2()
        {
            InitializeComponent();

            // Config scroll fig1
            hScrollBar_Tamano.Minimum = 50;
            hScrollBar_Tamano.Maximum = 150;
            hScrollBar_Tamano.SmallChange = 5;
            hScrollBar_Tamano.LargeChange = 10;
            int centro1 = (hScrollBar_Tamano.Minimum + hScrollBar_Tamano.Maximum) / 2;
            hScrollBar_Tamano.Value = centro1;

            // Config scroll fig2 (ajusta si quieres otros rangos)
            hScrollBar_Tamano2.Minimum = 50;
            hScrollBar_Tamano2.Maximum = 150;
            hScrollBar_Tamano2.SmallChange = 5;
            hScrollBar_Tamano2.LargeChange = 10;
            int centro2 = (hScrollBar_Tamano2.Minimum + hScrollBar_Tamano2.Maximum) / 2;
            hScrollBar_Tamano2.Value = centro2;
        }

        // =========================================
        // =============== FIGURA 1 ================
        // =========================================

        void InitCanvas1()
        {
            if (graphicsMandala != null) graphicsMandala.Dispose();
            if (bitmapMandala != null) bitmapMandala.Dispose();

            bitmapMandala = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphicsMandala = Graphics.FromImage(bitmapMandala);
            graphicsMandala.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsMandala.Clear(Color.White);
        }

        PointF Centro1() => new PointF(cx1, cy1);

        // Paso 0 fig1: 16 radiales
        void Paso0_Radiales16_Fig1()
        {
            var c = Centro1();
            int n = 16;
            float L = R1 * 2.05f * escala1;
            double ang0 = -Math.PI / 2;
            double step = Math.PI / 8.0;

            using (var p = new Pen(Color.Black, 1))
            {
                for (int i = 0; i < n; i++)
                {
                    double ang = ang0 + i * step + rot1;
                    var q = new PointF(
                        c.X + L * (float)Math.Cos(ang),
                        c.Y - L * (float)Math.Sin(ang));
                    graphicsMandala.DrawLine(p, c, q);
                }
            }

            using (var b = new SolidBrush(Color.Black))
                graphicsMandala.FillEllipse(b, c.X - 2, c.Y - 2, 4, 4);
        }

        // Paso 1 fig1: estrella 8
        void Paso1_Fig1_Estrella8()
        {
            var c = Centro1();
            int n = 8;
            float k = 0.48f;
            float R = R1 * escala1;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot1;
                float r = (i % 2 == 0) ? R : R * k;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 2 fig1
        void Paso2_Fig1_Estrella8_Abierta()
        {
            var c = Centro1();
            int n = 8;
            float k2 = 0.75f;
            float R = R1 * escala1;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot1;
                float r = (i % 2 == 0) ? R : R * k2;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 3 fig1
        void Paso3_Fig1_Estrella8()
        {
            var c = Centro1();
            int n = 8;
            float R = R1 * 1.36f * escala1;
            float k3 = 0.72f;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2;

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot1;
                float r = (i % 2 == 0) ? R : R * k3;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.4f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 4 fig1
        void Paso4_Fig1_Estrella8()
        {
            var c = Centro1();
            int n = 8;

            float R3 = R1 * 1.36f * escala1;
            float k3 = 0.72f;
            float R4 = R1 * 1.54f * escala1;
            float k4 = k3 * (R3 / R4);

            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2;

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot1;
                float r = (i % 2 == 0) ? R4 : R4 * k4;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.2f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 5 fig1
        void Paso5_Fig1_Estrella8()
        {
            var c = Centro1();
            int n = 8;
            float k5 = 0.75f;
            float R = R1 * 2.05f * escala1;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot1;
                float r = (i % 2 == 0) ? R : R * k5;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.0f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 6 fig1
        void Paso6_Fig1_Estrella8()
        {
            var c = Centro1();
            int n = 8;

            float k6 = 0.88f;
            float R = R1 * 2.06f * escala1;

            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot1;
                float r = (i % 2 == 0) ? R : R * k6;

                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }
            using (var p = new Pen(Color.Black, 0.9f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 7 fig1: polígono 16 lados
        void Paso7_Fig1_Contorno()
        {
            var c = Centro1();
            int n = 16;
            float R = R1 * 2.06f * escala1;
            PointF[] poly = new PointF[n];
            double ang0 = -Math.PI / 2.0;
            double step = 2 * Math.PI / n;
            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * step + rot1;
                poly[i] = new PointF(
                    c.X + R * (float)Math.Cos(ang),
                    c.Y - R * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 0.9f))
                graphicsMandala.DrawPolygon(p, poly);
        }

        void RenderFig1()
        {
            if (R1 <= 0) return;

            InitCanvas1();
            Paso0_Radiales16_Fig1();
            if (pasoActual1 >= 1) Paso1_Fig1_Estrella8();
            if (pasoActual1 >= 2) Paso2_Fig1_Estrella8_Abierta();
            if (pasoActual1 >= 3) Paso3_Fig1_Estrella8();
            if (pasoActual1 >= 4) Paso4_Fig1_Estrella8();
            if (pasoActual1 >= 5) Paso5_Fig1_Estrella8();
            if (pasoActual1 >= 6) Paso6_Fig1_Estrella8();
            if (pasoActual1 >= 7) Paso7_Fig1_Contorno();

            pictureBox1.Image = bitmapMandala;
        }

        // ===== Eventos FIGURA 1 =====

        private void btnGraficar1_Click(object sender, EventArgs e)
        {
            try
            {
                R1 = float.Parse(txtRadio1.Text);
                if (R1 <= 0)
                {
                    MessageBox.Show("El radio debe ser un número positivo mayor que cero.");
                    return;
                }

                escala1 = 1f;
                rot1 = 0f;
                cx1 = pictureBox1.Width / 2f;
                cy1 = pictureBox1.Height / 2f;

                int centro = (hScrollBar_Tamano.Minimum + hScrollBar_Tamano.Maximum) / 2;
                hScrollBar_Tamano.Value = centro;

                pasoActual1 = PASO_MAX1;
                RenderFig1();
            }
            catch
            {
                MessageBox.Show("Ingrese un valor válido para el radio de la Figura 1.");
            }
        }

        private void btnReset1_Click(object sender, EventArgs e)
        {
            txtRadio1.Text = "";
            if (graphicsMandala != null) graphicsMandala.Dispose();
            if (bitmapMandala != null) bitmapMandala.Dispose();
            pictureBox1.Image = null;
            pictureBox1.Refresh();

            R1 = 0f;
            pasoActual1 = 0;
            escala1 = 1f;
            rot1 = 0f;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (R1 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 1).");
                return;
            }
            pasoActual1 = Math.Max(0, pasoActual1 - 1);
            RenderFig1();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (R1 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 1).");
                return;
            }
            pasoActual1 = Math.Min(PASO_MAX1, pasoActual1 + 1);
            RenderFig1();
        }

        private void btnAntiHorario_Click(object sender, EventArgs e)
        {
            if (R1 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 1).");
                return;
            }
            rot1 += (float)(5 * DEG);
            RenderFig1();
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            if (R1 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 1).");
                return;
            }
            rot1 -= (float)(5 * DEG);
            RenderFig1();
        }

        private void hScrollBar_Tamano_Scroll(object sender, ScrollEventArgs e)
        {
            if (R1 <= 0) return;
            int centro = (hScrollBar_Tamano.Minimum + hScrollBar_Tamano.Maximum) / 2;
            escala1 = hScrollBar_Tamano.Value / (float)centro;
            RenderFig1();
        }

        // =========================================
        // =============== FIGURA 2 ================
        // =========================================

        void InitCanvas2()
        {
            if (graphicsFig2 != null) graphicsFig2.Dispose();
            if (bitmapFig2 != null) bitmapFig2.Dispose();

            bitmapFig2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            graphicsFig2 = Graphics.FromImage(bitmapFig2);
            graphicsFig2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsFig2.Clear(Color.White);
        }

        PointF CentroBase2() => new PointF(pictureBox2.Width / 2f, pictureBox2.Height / 2f);

        PointF Centro2()
        {
            var c0 = CentroBase2();
            return new PointF(c0.X + offsetX2, c0.Y + offsetY2);
        }

        // --- Aquí pego TODA la lógica de pasos de la figura 2 igualito
        // (La misma que ya tenías, solo cambiando R por R2 y rot por rot2 y escala2)

        // PASO 1 fig2: Estrella 5
        void Paso1_Fig2_Estrella5()
        {
            var c = Centro2();
            int n = 5;
            PointF[] pent = new PointF[n];

            double ang0 = Math.PI / 2;
            double step = 2 * Math.PI / n;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * step + rot2;
                float r = R2;
                float rr = r * escala2;

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

        // PASO 2: Estrella 5 (verde)
        void Paso2_Fig2_Estrella5()
        {
            var c = Centro2();
            int n = 5;
            float k = 0.72f;

            float Rint2 = R2 * escala2;
            float Rext2 = Rint2 / k;

            PointF[] pts = new PointF[10];
            double ang0 = Math.PI / 2;
            double paso = Math.PI / 5.0;

            for (int i = 0; i < 10; i++)
            {
                double ang = ang0 + paso * i + rot2;
                float r = (i % 2 == 0) ? Rint2 : Rext2;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 3: Estrella 5 (amarilla)
        void Paso3_Fig2_Estrella5()
        {
            var c = Centro2();
            int n = 5;

            float k2 = 1.0f;
            float Rint2 = R2 * escala2;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float k3 = 0.53f;
            float Rext3 = Rint3 / k3;

            PointF[] pts = new PointF[10];

            double ang0 = Math.PI / 2;
            double paso = Math.PI / 5.0;

            for (int i = 0; i < 10; i++)
            {
                double ang = ang0 + paso * i + rot2;
                float r = (i % 2 == 0) ? Rint3 : Rext3;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 4: Estrella 5
        void Paso4_Fig2_Estrella5()
        {
            var c = Centro2();
            int n = 5;

            float k3 = 0.82f;
            float k2 = 0.88f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0 + paso * i + rot2;
                float r = (i % 2 == 0) ? Rext4 : Rint4;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 5: Estrella 5 negra
        void Paso5_Fig2_Estrella5_Negra()
        {
            var c = Centro2();
            int n = 5;

            float k4 = 0.88f;
            float k3 = 0.9f;
            float k2 = 0.9f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0 + paso * i + rot2;
                float r = (i % 2 == 0) ? Rext5 : Rint5;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.0f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        // PASO 6: Decágono
        void Paso6_Fig2_Decagono()
        {
            var c = Centro2();
            int n = 10;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R2 * escala2;
            float Rext2 = Rint2 / k2;

            float Rint3 = Rext2;
            float Rext3 = Rint3 / k3;

            float Rdec = Rext3 * 1.64f;

            PointF[] poly = new PointF[n];

            double ang0 = Math.PI / 2.0;
            double paso = 2 * Math.PI / n;

            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * paso + rot2;
                float rr = Rdec;

                poly[i] = new PointF(
                    c.X + rr * (float)Math.Cos(ang),
                    c.Y - rr * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.0f))
                graphicsFig2.DrawPolygon(p, poly);
        }

        // PASO 7: Pentágono exterior
        void Paso7_Fig2_Pentagono_Exterior()
        {
            var c = Centro2();
            int n = 5;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0 + i * paso + rot2;

                pent[i] = new PointF(
                    c.X + Rpent * (float)Math.Cos(ang),
                    c.Y - Rpent * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pent);
        }

        // PASO 8: Decágono exterior
        void Paso8_Fig2_Decagono_Verde()
        {
            var c = Centro2();
            int n = 10;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0 + i * paso + rot2;

                poly[i] = new PointF(
                    c.X + RdecVerde * (float)Math.Cos(ang),
                    c.Y - RdecVerde * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, poly);
        }

        // PASO 9: pentágono inclinado izq
        void Paso9_Fig2_Pentagono_Exterior_Inclinado()
        {
            var c = Centro2();
            int n = 5;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0 + i * paso + rot2;

                pent[i] = new PointF(
                    c.X + Rpent * (float)Math.Cos(ang),
                    c.Y - Rpent * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pent);
        }

        // PASO 10: pentágono inclinado der
        void Paso10_Fig2_Pentagono_Exterior_Derecha()
        {
            var c = Centro2();
            int n = 5;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0 + i * paso + rot2;

                pent[i] = new PointF(
                    c.X + Rpent * (float)Math.Cos(ang),
                    c.Y - Rpent * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pent);
        }

        // PASO 11: Estrella 10 exterior
        void Paso11_Fig2_Estrella10_Exterior()
        {
            var c0 = Centro2();
            var c = new PointF(c0.X, c0.Y + 1);

            int n = 10;

            float k2 = 1.08f;
            float k3 = 1.08f;

            float Rint2 = R2 * escala2;
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
                double ang = ang0Dec + i * pasoStar + rot2;
                float r = (i % 2 == 0) ? RintStar : RextStar;

                pts[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsFig2.DrawPolygon(p, pts);
        }

        void RenderFig2()
        {
            if (R20 <= 0) return;
            R2 = R20; // base

            InitCanvas2();

            if (pasoActual2 >= 1) Paso1_Fig2_Estrella5();
            if (pasoActual2 >= 2) Paso2_Fig2_Estrella5();
            if (pasoActual2 >= 3) Paso3_Fig2_Estrella5();
            if (pasoActual2 >= 4) Paso4_Fig2_Estrella5();
            if (pasoActual2 >= 5) Paso5_Fig2_Estrella5_Negra();
            if (pasoActual2 >= 6) Paso6_Fig2_Decagono();
            if (pasoActual2 >= 7) Paso7_Fig2_Pentagono_Exterior();
            if (pasoActual2 >= 8) Paso8_Fig2_Decagono_Verde();
            if (pasoActual2 >= 9) Paso9_Fig2_Pentagono_Exterior_Inclinado();
            if (pasoActual2 >= 10) Paso10_Fig2_Pentagono_Exterior_Derecha();
            if (pasoActual2 >= 11) Paso11_Fig2_Estrella10_Exterior();

            pictureBox2.Image = bitmapFig2;
        }

        // ===== Eventos FIGURA 2 =====

        private void btnGraficar2_Click(object sender, EventArgs e)
        {
            try
            {
                R20 = float.Parse(txtRadio2.Text);
                if (R20 <= 0)
                {
                    MessageBox.Show("El radio debe ser un número positivo mayor que cero.");
                    return;
                }

                escala2 = 1f;
                rot2 = 0;
                offsetX2 = 0;
                offsetY2 = 0;

                int mid = (hScrollBar_Tamano2.Maximum + hScrollBar_Tamano2.Minimum) / 2;
                hScrollBar_Tamano2.Value = mid;

                pasoActual2 = PASO_MAX2;
                RenderFig2();
            }
            catch
            {
                MessageBox.Show("Ingrese un valor válido para el radio de la Figura 2.");
            }
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            txtRadio2.Text = "";
            if (graphicsFig2 != null) graphicsFig2.Dispose();
            if (bitmapFig2 != null) bitmapFig2.Dispose();
            pictureBox2.Image = null;
            pictureBox2.Refresh();

            R2 = 0f;
            R20 = 0f;
            pasoActual2 = 0;
            escala2 = 1f;
            rot2 = 0;
            offsetX2 = offsetY2 = 0;

            txtRadio2.Focus();
        }

        private void btn2Anterior_Click(object sender, EventArgs e)
        {
            if (R20 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 2).");
                return;
            }

            pasoActual2 = Math.Max(0, pasoActual2 - 1);
            RenderFig2();
        }

        private void btn2Siguiente_Click(object sender, EventArgs e)
        {
            if (R20 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 2).");
                return;
            }

            pasoActual2 = Math.Min(PASO_MAX2, pasoActual2 + 1);
            RenderFig2();
        }

        private void hScrollBar_Tamano2_Scroll(object sender, ScrollEventArgs e)
        {
            if (R20 <= 0) return;

            int mid = (hScrollBar_Tamano2.Maximum + hScrollBar_Tamano2.Minimum) / 2;
            if (mid == 0) mid = 1;

            escala2 = hScrollBar_Tamano2.Value / (float)mid;
            RenderFig2();
        }

        private void btnAntiHorario2_Click(object sender, EventArgs e)
        {
            if (R20 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 2).");
                return;
            }

            rot2 += 5 * DEG;
            RenderFig2();
        }

        private void btnHorario2_Click(object sender, EventArgs e)
        {
            if (R20 <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar (Figura 2).");
                return;
            }

            rot2 -= 5 * DEG;
            RenderFig2();
        }

        // ===============================
        // TRASLACIÓN CON TECLADO (AMBAS)
        // ===============================
        // Flechas: mueven FIGURA 1 (cx1, cy1)
        // WASD:    mueven FIGURA 2 (offsetX2, offsetY2)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const float paso = 5f;
            bool handled = false;

            // FIGURA 1: flechas
            if (R1 > 0)
            {
                switch (keyData)
                {
                    case Keys.Up:
                        cy1 -= paso; handled = true; break;
                    case Keys.Down:
                        cy1 += paso; handled = true; break;
                    case Keys.Left:
                        cx1 -= paso; handled = true; break;
                    case Keys.Right:
                        cx1 += paso; handled = true; break;
                }
                if (handled)
                    RenderFig1();
            }

            // FIGURA 2: WASD
            if (!handled && R20 > 0)
            {
                switch (keyData)
                {
                    case Keys.W:
                        offsetY2 -= paso; handled = true; break;
                    case Keys.S:
                        offsetY2 += paso; handled = true; break;
                    case Keys.A:
                        offsetX2 -= paso; handled = true; break;
                    case Keys.D:
                        offsetX2 += paso; handled = true; break;
                }
                if (handled)
                    RenderFig2();
            }

            if (handled) return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Eventos vacíos de diseñador (por si acaso)
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void txtRadio1_TextChanged(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void txtRadio2_TextChanged(object sender, EventArgs e) { }
    }
}
