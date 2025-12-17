namespace PROYECTO_U2_CCLl.Modelo
{
    public class Piramide : Figura3D
    {
        public float Base { get; set; }
        public float Altura { get; set; }

        public Piramide(string nombre, float baseSize, float altura) : base(nombre)
        {
            Base = baseSize;
            Altura = altura;
        }
    }
}
