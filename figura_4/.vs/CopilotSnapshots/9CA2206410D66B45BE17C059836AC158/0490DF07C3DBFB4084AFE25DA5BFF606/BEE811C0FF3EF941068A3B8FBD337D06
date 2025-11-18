using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace figura_4
{
    /// <summary>
    /// Formulario principal para dibujar pentágonos y polígonos estrellados
    /// </summary>
    public partial class Form1 : Form
    {
        #region Campos Privados
        
        private Bitmap canvas;
        private FiguraGeometrica figura;
        
        #endregion

        #region Constructor
        
        public Form1()
        {
            InitializeComponent();
            InicializarComponentes();
        }
        
        #endregion

        #region Inicialización
        
        /// <summary>
        /// Inicializa los componentes y configuraciones del formulario
        /// </summary>
        private void InicializarComponentes()
        {
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            figura = new FiguraGeometrica();
            picCanvas.Image = canvas;
            
            // Habilitar captura de teclas en el formulario
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        
        #endregion

        #region Eventos de Teclado
        
        /// <summary>
        /// Maneja el evento de presionar una tecla
        /// </summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaMovimiento = false;

            // Detectar si se presiona Shift para movimiento horizontal
            bool shiftPresionado = e.Shift;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!shiftPresionado)
                    {
                        figura.MoverArriba();
                        teclaMovimiento = true;
                    }
                    break;

                case Keys.Down:
                    if (!shiftPresionado)
                    {
                        figura.MoverAbajo();
                        teclaMovimiento = true;
                    }
                    break;

                case Keys.Left:
                    if (shiftPresionado)
                    {
                        figura.MoverIzquierda();
                        teclaMovimiento = true;
                    }
                    else
                    {
                        figura.Rotar(-5f);
                        teclaMovimiento = true;
                    }
                    break;

                case Keys.Right:
                    if (shiftPresionado)
                    {
                        figura.MoverDerecha();
                        teclaMovimiento = true;
                    }
                    else
                    {
                        figura.Rotar(5f);
                        teclaMovimiento = true;
                    }
                    break;
            }

            // Si se presionó una tecla de movimiento, actualizar el dibujo
            if (teclaMovimiento)
            {
                ActualizarDibujo();
                e.Handled = true;
            }
        }
        
        #endregion

        #region Eventos de Botones - Entradas
        
        /// <summary>
        /// Maneja el evento click del botón Graficar
        /// </summary>
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (ValidarEntradaRadio(out float radioInput))
            {
                ConfigurarParametrosFigura(radioInput);
                ActualizarDibujo();
            }
            else
            {
                MostrarMensajeError("Por favor ingresa un valor numérico válido.");
            }
        }

        /// <summary>
        /// Maneja el evento click del botón Resetear
        /// </summary>
        private void btnResetear_Click(object sender, EventArgs e)
        {
            ReiniciarFigura();
            LimpiarCanvas();
        }
        
        #endregion

        #region Eventos de Botones - Rotación
        
        /// <summary>
        /// Maneja el evento click del botón rotar antihorario (-5°)
        /// </summary>
        private void btnRotarAntihorario_Click(object sender, EventArgs e)
        {
            figura.Rotar(-5f);
            ActualizarDibujo();
        }

        /// <summary>
        /// Maneja el evento click del botón rotar horario (+5°)
        /// </summary>
        private void btnRotarHorario_Click(object sender, EventArgs e)
        {
            figura.Rotar(5f);
            ActualizarDibujo();
        }
        
        #endregion

        #region Eventos de Control - TrackBar
        
        /// <summary>
        /// Maneja el evento scroll del TrackBar de tamaño
        /// </summary>
        private void trackBarTamano_Scroll(object sender, EventArgs e)
        {
            figura.Escala = trackBarTamano.Value / 100f;
            ActualizarDibujo();
        }
        
        #endregion

        #region Eventos de Botones - Paso a Paso
        
        /// <summary>
        /// Maneja el evento click del botón Anterior
        /// </summary>
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (figura.NivelDibujo > 0)
            {
                figura.NivelDibujo--;
                ActualizarDibujo();
            }
        }

        /// <summary>
        /// Maneja el evento click del botón Siguiente
        /// </summary>
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (figura.NivelDibujo < 5)
            {
                figura.NivelDibujo++;
                ActualizarDibujo();
            }
        }
        
        #endregion

        #region Métodos de Dibujo
        
        /// <summary>
        /// Actualiza el dibujo de la figura en el canvas
        /// </summary>
        private void ActualizarDibujo()
        {
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            
            using (Graphics g = Graphics.FromImage(canvas))
            {
                figura.Dibujar(g, picCanvas.Size);
            }
            
            picCanvas.Image = canvas;
            picCanvas.Refresh();
        }

        /// <summary>
        /// Limpia el canvas y lo actualiza
        /// </summary>
        private void LimpiarCanvas()
        {
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image = canvas;
            picCanvas.Refresh();
        }
        
        #endregion

        #region Métodos de Configuración
        
        /// <summary>
        /// Configura los parámetros de la figura para dibujar
        /// </summary>
        private void ConfigurarParametrosFigura(float radio)
        {
            figura.Radio = radio;
            figura.Escala = trackBarTamano.Value / 100f;
            figura.NivelDibujo = 5; // Mostrar todo
        }

        /// <summary>
        /// Reinicia la figura y los controles a sus valores por defecto
        /// </summary>
        private void ReiniciarFigura()
        {
            figura.Reiniciar();
            trackBarTamano.Value = 100;
            txtTamano.Text = "100";
        }
        
        #endregion

        #region Métodos de Validación
        
        /// <summary>
        /// Valida la entrada del radio desde el TextBox
        /// </summary>
        private bool ValidarEntradaRadio(out float radio)
        {
            return float.TryParse(txtTamano.Text, out radio) && radio > 0;
        }
        
        #endregion

        #region Métodos de UI
        
        /// <summary>
        /// Muestra un mensaje de error al usuario
        /// </summary>
        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        #endregion

        #region Eventos de Formulario (Generados por Designer)
        
        private void grpBox_Enter(object sender, EventArgs e)
        {
            // Evento generado por el diseñador
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Evento generado por el diseñador
        }

        private void txtTamano_TextChanged(object sender, EventArgs e)
        {
            // Evento generado por el diseñador
        }
        
        #endregion
    }
}
