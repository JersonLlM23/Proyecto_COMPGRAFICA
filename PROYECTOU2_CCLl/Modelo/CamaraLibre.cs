using OpenTK;

namespace PROYECTO_U2_CCLl.Modelo
{
    public class CamaraLibre : ICamara
    {
        public TipoCamara Tipo => TipoCamara.Libre;

        public Vector3 Posicion = new Vector3(0, 0, 400);
        public float YawDeg = 0f;   // izquierda/derecha
        public float PitchDeg = 0f; // arriba/abajo

        public Matrix4 GetViewMatrix()
        {
            var forward = GetForward();
            var target = Posicion + forward;
            return Matrix4.LookAt(Posicion, target, Vector3.UnitY);
        }

        public Vector3 GetForward()
        {
            float yaw = MathHelper.DegreesToRadians(YawDeg);
            float pitch = MathHelper.DegreesToRadians(PitchDeg);
            float x = (float)(System.Math.Cos(pitch) * System.Math.Sin(yaw));
            float y = (float)(System.Math.Sin(pitch));
            float z = (float)(System.Math.Cos(pitch) * System.Math.Cos(yaw));
            return new Vector3(x, y, z).Normalized();
        }

        public Vector3 GetRight()
        {
            var forward = GetForward();
            return Vector3.Cross(forward, Vector3.UnitY).Normalized();
        }

        public void Reset()
        {
            Posicion = new Vector3(0, 0, 400);
            YawDeg = 0f;
            PitchDeg = 0f;
        }
    }
}
