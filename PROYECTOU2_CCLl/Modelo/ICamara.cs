using OpenTK;

namespace PROYECTO_U2_CCLl.Modelo
{
    public interface ICamara
    {
        TipoCamara Tipo { get; }
        Matrix4 GetViewMatrix();
        void Reset();
    }
}
