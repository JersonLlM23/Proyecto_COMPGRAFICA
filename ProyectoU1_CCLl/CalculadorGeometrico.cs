using System.Drawing;

namespace ProyectoU1_CCLl
{
    /// <summary>
    /// Clase que encapsula los cálculos geométricos para la figura
    /// </summary>
    public class CalculadorGeometrico
    {
        private readonly float radio;
        private readonly float escala;
        private readonly float anguloRotacion;
        private readonly PointF centro;

        public CalculadorGeometrico(float radio, float escala, float anguloRotacion, PointF centro)
        {
            this.radio = radio;
            this.escala = escala;
            this.anguloRotacion = anguloRotacion;
            this.centro = centro;
        }

        public float RadioEscalado => radio * escala;
        public float Radio2 => RadioEscalado * 5 / 6;
        public float Radio3 => RadioEscalado * 3 / 6;
        public float Radio4 => RadioEscalado * 1 / 6;
        public PointF Centro => centro;

        /// <summary>
        /// Calcula los vértices del primer cuadrado
        /// </summary>
        public PointF[] CalcularVerticesCuadrado1()
        {
            return CalcularVertices((float)System.Math.PI);
        }

        /// <summary>
        /// Calcula los vértices del segundo cuadrado (rotado 45 grados)
        /// </summary>
        public PointF[] CalcularVerticesCuadrado2()
        {
            return CalcularVertices((float)System.Math.PI + (float)System.Math.PI / 4);
        }

        private PointF[] CalcularVertices(float anguloInicial)
        {
            PointF[] vertices = new PointF[4];
            float angulo = anguloInicial + anguloRotacion;

            for (int i = 0; i < 4; i++)
            {
                vertices[i] = new PointF(
                    centro.X + (float)(RadioEscalado * System.Math.Sin(angulo)),
                    centro.Y + (float)(RadioEscalado * System.Math.Cos(angulo))
                );
                angulo += (float)System.Math.PI / 2;
            }

            return vertices;
        }
    }
}
