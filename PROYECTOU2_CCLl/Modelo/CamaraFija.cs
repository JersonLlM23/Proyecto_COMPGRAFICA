using OpenTK;

namespace PROYECTO_U2_CCLl.Modelo
{
    public enum PresetCamaraFija
    {
        Frontal,
        Superior,
        Lateral
    }

    public class CamaraFija : ICamara
    {
        public TipoCamara Tipo => TipoCamara.Fija;

        public PresetCamaraFija Preset = PresetCamaraFija.Frontal;
        public Vector3 Target = Vector3.Zero;
        public float Distancia = 400f;

        public Matrix4 GetViewMatrix()
        {
            Vector3 posicion;
            switch (Preset)
            {
                case PresetCamaraFija.Superior:
                    posicion = new Vector3(Target.X, Target.Y + Distancia, Target.Z);
                    return Matrix4.LookAt(posicion, Target, Vector3.UnitZ);
                case PresetCamaraFija.Lateral:
                    posicion = new Vector3(Target.X + Distancia, Target.Y, Target.Z);
                    return Matrix4.LookAt(posicion, Target, Vector3.UnitY);
                case PresetCamaraFija.Frontal:
                default:
                    posicion = new Vector3(Target.X, Target.Y, Target.Z + Distancia);
                    return Matrix4.LookAt(posicion, Target, Vector3.UnitY);
            }
        }

        public void Reset()
        {
            Preset = PresetCamaraFija.Frontal;
            Target = Vector3.Zero;
            Distancia = 400f;
        }
    }
}
