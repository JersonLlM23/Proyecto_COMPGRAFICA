using System;
using System.Drawing;
using System.Windows.Forms;

namespace figura_5
{
    /// <summary>
    /// Formulario principal para dibujar y manipular polígonos estrellados
    /// Organizado con estructura clara por responsabilidades
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constantes
        
        private const float RadioPorDefecto = 100f;
        private const float EscalaPorDefecto = 1.0f;
        private const int DesplazamientoMovimiento = 5;
        private const int GradosRotacion = 5;
        private const int PasoMaximo = 7;
        
        #endregion

        #region Variables de Estado
        
        private float radio;
        private float escala;
        private float anguloRotacion;
        private float offsetX;
        private float offsetY;
        private int pasoActual;
        private Bitmap bufferImagen;
        private DibujadorFigura dibujador;
        
        #endregion

        #region Constructor e Inicialización
        
        public Form1()
        {
            InitializeComponent();
            InicializarVariables();
            InicializarBuffer();
        }

        private void InicializarVariables()
        {
            radio = RadioPorDefecto;
            escala = EscalaPorDefecto;
            anguloRotacion = 0;
            offsetX = 0;
            offsetY = 0;
            pasoActual = 0;
            dibujador = new DibujadorFigura();
        }

        private void InicializarBuffer()
        {
            bufferImagen = new Bitmap(picCanvas.Width, picCanvas.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtRadio.Text = RadioPorDefecto.ToString();
        }
        
        #endregion

        #region Eventos de Botones - Entrada de Datos
        
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (ValidarYObtenerRadio(out float nuevoRadio))
            {
                radio = nuevoRadio;
                pasoActual = PasoMaximo; // Mostrar figura completa
                DibujarFigura();
            }
            else
            {
                MostrarError("Por favor ingresa un valor numérico válido.");
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            ResetearTodo();
        }
        
        #endregion

        #region Eventos de Botones - Rotación
        
        private void btnGiroAntihorario_Click(object sender, EventArgs e)
        {
            RotarAntihorario();
        }

        private void btnGiroHorario_Click(object sender, EventArgs e)
        {
            RotarHorario();
        }
        
        #endregion

        #region Eventos de Botones - Navegación por Pasos
        
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (pasoActual > 0)
            {
                pasoActual--;
                DibujarFigura();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (pasoActual < PasoMaximo)
            {
                pasoActual++;
                DibujarFigura();
            }
        }
        
        #endregion

        #region Eventos de Controles - TrackBar y Teclado
        
        private void trackBarEscala_Scroll(object sender, EventArgs e)
        {
            escala = trackBarEscala.Value / 100.0f;
            DibujarFigura();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool procesado = ProcesarTecla(e.KeyCode, e.Shift);
            if (procesado)
            {
                e.Handled = true;
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (bufferImagen != null)
            {
                e.Graphics.DrawImage(bufferImagen, 0, 0);
            }
        }
        
        #endregion

        #region Métodos de Validación
        
        private bool ValidarYObtenerRadio(out float radioValidado)
        {
            return float.TryParse(txtRadio.Text, out radioValidado) && radioValidado > 0;
        }
        
        #endregion

        #region Métodos de Transformación
        
        private void RotarHorario()
        {
            anguloRotacion += GradosARadianes(GradosRotacion);
            DibujarFigura();
        }

        private void RotarAntihorario()
        {
            anguloRotacion -= GradosARadianes(GradosRotacion);
            DibujarFigura();
        }

        private void MoverFigura(float deltaX, float deltaY)
        {
            offsetX += deltaX;
            offsetY += deltaY;
            DibujarFigura();
        }
        
        #endregion

        #region Métodos de Reseteo
        
        private void ResetearTodo()
        {
            InicializarVariables();
            trackBarEscala.Value = 100;
            txtRadio.Text = RadioPorDefecto.ToString();
            LimpiarCanvas();
        }
        
        #endregion

        #region Procesamiento de Teclado
        
        private bool ProcesarTecla(Keys tecla, bool shiftPresionado)
        {
            switch (tecla)
            {
                case Keys.Left:
                    if (shiftPresionado)
                        MoverFigura(-DesplazamientoMovimiento, 0);
                    else
                        RotarAntihorario();
                    return true;

                case Keys.Right:
                    if (shiftPresionado)
                        MoverFigura(DesplazamientoMovimiento, 0);
                    else
                        RotarHorario();
                    return true;

                case Keys.Up:
                    MoverFigura(0, -DesplazamientoMovimiento);
                    return true;

                case Keys.Down:
                    MoverFigura(0, DesplazamientoMovimiento);
                    return true;

                default:
                    return false;
            }
        }
        
        #endregion

        #region Métodos de Dibujo Principal
        
        private void DibujarFigura()
        {
            using (Graphics canvas = Graphics.FromImage(bufferImagen))
            {
                canvas.Clear(Color.White);
                canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                CalculadorGeometrico calc = ObtenerCalculador();

                DibujarCirculos(canvas, calc);
                DibujarCuadrados(canvas, calc);
                DibujarLineasYConexiones(canvas, calc);
            }

            picCanvas.Invalidate();
        }
        
        #endregion

        #region Métodos de Cálculo
        
        private CalculadorGeometrico ObtenerCalculador()
        {
            PointF centro = new PointF(
                picCanvas.Width / 2f + offsetX,
                picCanvas.Height / 2f + offsetY
            );

            return new CalculadorGeometrico(radio, escala, anguloRotacion, centro);
        }
        
        #endregion

        #region Métodos de Dibujo de Componentes
        
        private void DibujarCirculos(Graphics canvas, CalculadorGeometrico calc)
        {
            if (pasoActual >= 1)
                dibujador.DibujarCirculo(canvas, calc.Centro.X, calc.Centro.Y, calc.RadioEscalado);

            if (pasoActual >= 2)
                dibujador.DibujarCirculo(canvas, calc.Centro.X, calc.Centro.Y, calc.Radio2);

            if (pasoActual >= 3)
                dibujador.DibujarCirculo(canvas, calc.Centro.X, calc.Centro.Y, calc.Radio3);

            if (pasoActual >= 4)
                dibujador.DibujarCirculo(canvas, calc.Centro.X, calc.Centro.Y, calc.Radio4);
        }

        private void DibujarCuadrados(Graphics canvas, CalculadorGeometrico calc)
        {
            if (pasoActual >= 5)
            {
                PointF[] vertices1 = calc.CalcularVerticesCuadrado1();
                dibujador.DibujarPoligono(canvas, vertices1);
            }

            if (pasoActual >= 6)
            {
                PointF[] vertices2 = calc.CalcularVerticesCuadrado2();
                dibujador.DibujarPoligono(canvas, vertices2);
            }
        }

        private void DibujarLineasYConexiones(Graphics canvas, CalculadorGeometrico calc)
        {
            if (pasoActual < 7) return;

            PointF[] vertices1 = calc.CalcularVerticesCuadrado1();
            PointF[] vertices2 = calc.CalcularVerticesCuadrado2();

            // Líneas radiales desde el centro
            foreach (PointF vertice in vertices1)
                dibujador.DibujarLineaRadial(canvas, calc.Centro, vertice);

            foreach (PointF vertice in vertices2)
                dibujador.DibujarLineaRadial(canvas, calc.Centro, vertice);

            // Conexiones entre cuadrados
            for (int i = 0; i < 4; i++)
            {
                dibujador.DibujarLineaSolida(canvas, vertices1[i], vertices2[(i + 1) % 4]);
                dibujador.DibujarLineaSolida(canvas, vertices1[i], vertices2[(i + 2) % 4]);
            }
        }
        
        #endregion

        #region Métodos Auxiliares de Canvas
        
        private void LimpiarCanvas()
        {
            using (Graphics g = Graphics.FromImage(bufferImagen))
            {
                g.Clear(Color.White);
            }
            picCanvas.Invalidate();
        }
        
        #endregion

        #region Métodos de Utilidad
        
        private float GradosARadianes(float grados)
        {
            return grados * (float)Math.PI / 180f;
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        #endregion

        #region Limpieza de Recursos
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                bufferImagen?.Dispose();
                dibujador?.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #endregion
    }
}
