using OpenTK;

namespace PROYECTO_U2_CCLl.Modelo
{
    public class CamaraOrbital : ICamara
    {
        public TipoCamara Tipo => TipoCamara.Orbital;

        public Vector3 Target = Vector3.Zero;
        public float Distancia = 400f;
        public float YawDeg = 20f;   // rotación alrededor de Y
        public float PitchDeg = 20f; // rotación alrededor de X

        public Matrix4 GetViewMatrix()
        {
            float yaw = MathHelper.DegreesToRadians(YawDeg);
            float pitch = MathHelper.DegreesToRadians(PitchDeg);

            // Spherical to Cartesian
            float x = Distancia * (float)(System.Math.Cos(pitch) * System.Math.Sin(yaw));
            float y = Distancia * (float)(System.Math.Sin(pitch));
            float z = Distancia * (float)(System.Math.Cos(pitch) * System.Math.Cos(yaw));

            var posicion = new Vector3(Target.X + x, Target.Y + y, Target.Z + z);
            return Matrix4.LookAt(posicion, Target, Vector3.UnitY);
        }

        public void Reset()
        {
            Target = Vector3.Zero;
            Distancia = 400f;
            YawDeg = 20f;
            PitchDeg = 20f;
        }
    }
}
