namespace PROYECTO_U2_CCLl.Modelo
{
    public class PrismaPentagonal : Figura3D
    {
        public float Radio { get; set; }
        public float Altura { get; set; }

        public PrismaPentagonal(string nombre, float radio, float altura) : base(nombre)
        {
            Radio = radio;
            Altura = altura;
        }
    }
}
