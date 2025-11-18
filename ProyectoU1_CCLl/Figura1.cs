using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoU1_CCLl
{
    public partial class Figura1 : Form
    {

        private static Figura1 instancia = null;


        public static Figura1 Instancia
        {
            get
            {
                if (instancia == null || instancia.IsDisposed)
                {
                    instancia = new Figura1();
                }
                return instancia;
            }
        }
        private Bitmap bitmapMandala;
        private Graphics graphicsMandala;

        float R = 0f;                
        int pasoActual = 0;
        const int PASO_MAX = 7;

        // --- Transformaciones ---
        float cx, cy;                // centro actual
        float escala = 1f;           // factor de escala
        float rot = 0f;              // rotación en radianes
        const float DEG = (float)(Math.PI / 180f); // radianes

        public Figura1()
        {
            InitializeComponent();
            hScrollBar_Tamano.Minimum = 50;    
            hScrollBar_Tamano.Maximum = 150;  
            hScrollBar_Tamano.SmallChange = 5;
            hScrollBar_Tamano.LargeChange = 10;

            int centro = (hScrollBar_Tamano.Minimum + hScrollBar_Tamano.Maximum) / 2;
            hScrollBar_Tamano.Value = centro;
        }
        void InitCanvas()
        {
            if (graphicsMandala != null) graphicsMandala.Dispose();
            if (bitmapMandala != null) bitmapMandala.Dispose();

            bitmapMandala = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphicsMandala = Graphics.FromImage(bitmapMandala);
            graphicsMandala.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphicsMandala.Clear(Color.White);
        }

        PointF Centro() => new PointF(cx, cy);


        // =============== PASOS ===================


        // Paso 0: 16 líneas radiales desde el centro
        void Paso0_Radiales16()
        {
            var c = Centro();
            int n = 16;
            float L = R * 2.05f * escala;
            double ang0 = -Math.PI / 2;
            double step = Math.PI / 8.0;

            using (var p = new Pen(Color.Black, 1))
            {
                for (int i = 0; i < n; i++)
                {
                    double ang = ang0 + i * step + rot;
                    var q = new PointF(
                        c.X + L * (float)Math.Cos(ang),
                        c.Y - L * (float)Math.Sin(ang));
                    graphicsMandala.DrawLine(p, c, q);
                }
            }
            
            using (var b = new SolidBrush(Color.Black))
                graphicsMandala.FillEllipse(b, c.X - 2, c.Y - 2, 4, 4);
        }

        // Paso 1: estrella de 8 puntas
        void Paso1_Estrella8()
        {
            var c = Centro();
            int n = 8;
            float k = 0.48f;
            float R1 = R * escala;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot;
                float r = (i % 2 == 0) ? R1 : R1 * k;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 2: estrella de 8 puntas 
        void Paso2_Estrella8_Abierta()
        {
            var c = Centro();
            int n = 8;
            float k2 = 0.75f;
            float R2 = R * escala;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot;
                float r = (i % 2 == 0) ? R2 : R2 * k2;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 3: estrella de 8 puntas 
        void Paso3_Estrella8()
        {
            var c = Centro();
            int n = 8;
            float R3 = R * 1.36f * escala;
            float k3 = 0.72f;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2;

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot;
                float r = (i % 2 == 0) ? R3 : R3 * k3;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.4f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 4: estrella de 8 puntas 
        void Paso4_Estrella8()
        {
            var c = Centro();
            int n = 8;

            float R3 = R * 1.36f * escala;
            float k3 = 0.72f;
            float R4 = R * 1.54f * escala;
            float k4 = k3 * (R3 / R4);  

            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2;

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot;
                float r = (i % 2 == 0) ? R4 : R4 * k4;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.2f))
                graphicsMandala.DrawPolygon(p, star);
        }

        // Paso 5: estrella de 8 puntas
        void Paso5_Estrella8()
        {
            var c = Centro();
            int n = 8;
            float k5 = 0.75f;
            float R5 = R * 2.05f * escala;
            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n);

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot;
                float r = (i % 2 == 0) ? R5 : R5 * k5;
                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 1.0f))
                graphicsMandala.DrawPolygon(p, star);
        }

        void Paso6_Estrella8()
        {
            var c = Centro();
            int n = 8;

            float k6 = 0.88f;                 
            float R6 = R * 2.06f * escala;    

            PointF[] star = new PointF[n * 2];
            double ang0 = -Math.PI / 2 + (Math.PI / n); 

            for (int i = 0; i < star.Length; i++)
            {
                double ang = ang0 + i * (Math.PI / n) + rot;  
                float r = (i % 2 == 0) ? R6 : R6 * k6;

                star[i] = new PointF(
                    c.X + r * (float)Math.Cos(ang),
                    c.Y - r * (float)Math.Sin(ang));
            }
            using (var p = new Pen(Color.Black, 0.9f))
                graphicsMandala.DrawPolygon(p, star);
        }


        // Paso 7: contorno exterior como polígono regular de 16 lados
        void Paso7_Estrella8()
        {
            var c = Centro();
            int n = 16;
            float R7 = R * 2.06f * escala;
            PointF[] poly = new PointF[n];
            double ang0 = -Math.PI / 2.0;
            double step = 2 * Math.PI / n;
            for (int i = 0; i < n; i++)
            {
                double ang = ang0 + i * step + rot;    
                poly[i] = new PointF(
                    c.X + R7 * (float)Math.Cos(ang),
                    c.Y - R7 * (float)Math.Sin(ang));
            }

            using (var p = new Pen(Color.Black, 0.9f))
                graphicsMandala.DrawPolygon(p, poly);
        }

        void RenderPaso()
        {
            if (R <= 0) return;

            InitCanvas();
            Paso0_Radiales16();
            if (pasoActual >= 1) Paso1_Estrella8();
            if (pasoActual >= 2) Paso2_Estrella8_Abierta();
            if (pasoActual >= 3) Paso3_Estrella8();
            if (pasoActual >= 4) Paso4_Estrella8();
            if (pasoActual >= 5) Paso5_Estrella8();
            if (pasoActual >= 6) Paso6_Estrella8();
            if (pasoActual >= 7) Paso7_Estrella8();

            pictureBox1.Image = bitmapMandala;
        }
        private void btnGraficar1_Click(object sender, EventArgs e)
        {
            try
            {
                R = float.Parse(txtRadio1.Text);
                if (R <= 0)
                {
                    MessageBox.Show("El radio debe ser un número positivo mayor que cero.");
                    return;
                }                
                escala = 1f;
                rot = 0f;
                cx = pictureBox1.Width / 2f;
                cy = pictureBox1.Height / 2f;                
                int centro = (hScrollBar_Tamano.Minimum + hScrollBar_Tamano.Maximum) / 2;
                hScrollBar_Tamano.Value = centro;
                pasoActual = PASO_MAX;
                RenderPaso();
            }
            catch
            {
                MessageBox.Show("Ingrese un valor válido para el radio.");
            }
        }


        private void btnReset1_Click(object sender, EventArgs e)
        {
            txtRadio1.Text = "";
            if (graphicsMandala != null) graphicsMandala.Dispose();
            if (bitmapMandala != null) bitmapMandala.Dispose();
            pictureBox1.Image = null;
            pictureBox1.Refresh();

            R = 0f;
            pasoActual = 0;
            escala = 1f;
            rot = 0f;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (R <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar.");
                return;
            }
            pasoActual = Math.Max(0, pasoActual - 1);
            RenderPaso();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (R <= 0)
            {
                MessageBox.Show("Primero ingresa el radio y presiona Graficar.");
                return;
            }
            pasoActual = Math.Min(PASO_MAX, pasoActual + 1);
            RenderPaso();
        }

        // -------- ROTACIÓN  ----------

        private void btnHorario_Click(object sender, EventArgs e)
        {
            rot -= 5 * DEG;
            RenderPaso();
        }

        private void btnAntiHorario_Click(object sender, EventArgs e)
        {
            rot += 5 * DEG;
            RenderPaso();
        }


        private void hScrollBar_Tamano_Scroll(object sender, ScrollEventArgs e)
        {
            int centro = (hScrollBar_Tamano.Minimum + hScrollBar_Tamano.Maximum) / 2;
            escala = hScrollBar_Tamano.Value / (float)centro;
            RenderPaso();
        }


        // -------- TRASLACIÓN ----------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const float paso = 5f;

            if (R <= 0)
                return base.ProcessCmdKey(ref msg, keyData);

            switch (keyData)
            {
                case Keys.Up: cy -= paso; break;
                case Keys.Down: cy += paso; break;
                case Keys.Left: cx -= paso; break;
                case Keys.Right: cx += paso; break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            RenderPaso();
            return true;
        }

        
        private void txtRadio1_TextChanged(object sender, EventArgs e) { }

        private void Figura1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
