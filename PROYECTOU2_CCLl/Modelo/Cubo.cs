namespace PROYECTO_U2_CCLl.Modelo
{
    public class Cubo : Figura3D
    {
        public float Lado { get; set; }

        public Cubo(string nombre, float lado) : base(nombre)
        {
            Lado = lado;
        }
    }
}
