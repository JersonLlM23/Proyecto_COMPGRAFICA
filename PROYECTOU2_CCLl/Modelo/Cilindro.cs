namespace PROYECTO_U2_CCLl.Modelo
{
    public class Cilindro : Figura3D
    {
        public float Radio { get; set; }
        public float Altura { get; set; }
        public int Segmentos { get; set; }

        public Cilindro(string nombre, float radio, float altura, int segmentos = 32) : base(nombre)
        {
            Radio = radio;
            Altura = altura;
            Segmentos = segmentos;
        }
    }
}
