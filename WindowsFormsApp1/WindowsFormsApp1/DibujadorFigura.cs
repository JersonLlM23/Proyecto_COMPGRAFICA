using System.Drawing;
using System.Drawing.Drawing2D;

namespace figura_5
{
    /// <summary>
    /// Clase responsable de dibujar los componentes de la figura
    /// </summary>
    public class DibujadorFigura
    {
        private Pen lapizSolido;
        private Pen lapizEntrecortado;

        public DibujadorFigura()
        {
            lapizSolido = new Pen(Color.Black, 2);
            lapizEntrecortado = new Pen(Color.Black, 1)
            {
                DashStyle = DashStyle.Dash
            };
        }

        /// <summary>
        /// Dibuja un círculo
        /// </summary>
        public void DibujarCirculo(Graphics canvas, float centroX, float centroY, float radio)
        {
            canvas.DrawEllipse(lapizEntrecortado, 
                centroX - radio, centroY - radio, radio * 2, radio * 2);
        }

        /// <summary>
        /// Dibuja un polígono conectando sus vértices
        /// </summary>
        public void DibujarPoligono(Graphics canvas, PointF[] vertices)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                canvas.DrawLine(lapizSolido, vertices[i], vertices[(i + 1) % vertices.Length]);
            }
        }

        /// <summary>
        /// Dibuja una línea desde el centro a un punto
        /// </summary>
        public void DibujarLineaRadial(Graphics canvas, PointF centro, PointF destino)
        {
            canvas.DrawLine(lapizEntrecortado, centro, destino);
        }

        /// <summary>
        /// Dibuja una línea sólida entre dos puntos
        /// </summary>
        public void DibujarLineaSolida(Graphics canvas, PointF punto1, PointF punto2)
        {
            canvas.DrawLine(lapizSolido, punto1, punto2);
        }

        /// <summary>
        /// Libera recursos
        /// </summary>
        public void Dispose()
        {
            lapizSolido?.Dispose();
            lapizEntrecortado?.Dispose();
        }
    }
}
