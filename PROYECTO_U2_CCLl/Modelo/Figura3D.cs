using System.Drawing;

namespace PROYECTO_U2_CCLl.Modelo
{
    public abstract class Figura3D
    {
        public string Nombre { get; set; }

        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }

        public float RotX { get; set; }
        public float RotY { get; set; }
        public float RotZ { get; set; }

        public float EscalaX { get; set; } = 1f;
        public float EscalaY { get; set; } = 1f;
        public float EscalaZ { get; set; } = 1f;

        public Color ColorFigura { get; set; } = Color.DodgerBlue;
        public TipoMaterial Material { get; set; } = TipoMaterial.Solido;

        protected Figura3D(string nombre)
        {
            Nombre = nombre;
        }
    }
}
