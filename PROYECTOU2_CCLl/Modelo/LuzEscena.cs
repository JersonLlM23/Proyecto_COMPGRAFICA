using System.Drawing;
using OpenTK;

namespace PROYECTO_U2_CCLl.Modelo
{
    public class LuzEscena
    {
        public TipoLuz Tipo { get; set; } = TipoLuz.Direccional;
        public bool Habilitada { get; set; } = true;

        public Color Ambiente { get; set; } = Color.FromArgb(77, 77, 77);     // ~0.3
        public Color Difusa { get; set; } = Color.FromArgb(204, 204, 204);     // ~0.8
        public Color Especular { get; set; } = Color.FromArgb(255, 255, 255);  // 1.0

        // Posición/dir de la luz (w=0 direccional, w=1 puntual)
        public Vector4 Posicion { get; set; } = new Vector4(5f, 5f, 5f, 0f);

        public void SetDireccional(Vector3 direccionNorm)
        {
            // Direccional usa w=0 y vector dirección inverso en OpenGL fijo
            direccionNorm.Normalize();
            Posicion = new Vector4(-direccionNorm.X, -direccionNorm.Y, -direccionNorm.Z, 0f);
            Tipo = TipoLuz.Direccional;
            Habilitada = true;
        }

        public void SetPuntual(Vector3 posicion)
        {
            Posicion = new Vector4(posicion.X, posicion.Y, posicion.Z, 1f);
            Tipo = TipoLuz.Puntual;
            Habilitada = true;
        }

        public void Apagar()
        {
            Habilitada = false;
            Tipo = TipoLuz.Apagada;
        }
    }
}
