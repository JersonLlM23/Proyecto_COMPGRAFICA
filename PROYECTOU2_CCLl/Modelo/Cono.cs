namespace PROYECTO_U2_CCLl.Modelo
{
    public class Cono : Figura3D
    {
        public float Radio { get; set; }
        public float Altura { get; set; }
        public int Segmentos { get; set; }

        public Cono(string nombre, float radio, float altura, int segmentos = 32) : base(nombre)
        {
            Radio = radio;
            Altura = altura;
            Segmentos = segmentos;
        }
    }
}
