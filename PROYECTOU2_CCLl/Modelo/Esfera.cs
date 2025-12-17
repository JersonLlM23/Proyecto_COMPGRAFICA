namespace PROYECTO_U2_CCLl.Modelo
{
    public class Esfera : Figura3D
    {
        public float Radio { get; set; }
        public int Segmentos { get; set; }
        public int Anillos { get; set; }

        public Esfera(string nombre, float radio, int segmentos = 32, int anillos = 16) : base(nombre)
        {
            Radio = radio;
            Segmentos = segmentos;
            Anillos = anillos;
        }
    }
}
