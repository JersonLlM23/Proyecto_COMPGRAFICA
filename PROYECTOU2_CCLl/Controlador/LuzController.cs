using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PROYECTO_U2_CCLl.Modelo;

namespace PROYECTO_U2_CCLl.Controlador
{
    public class LuzController
    {
        public LuzEscena Luz { get; private set; } = new LuzEscena();

        public void ConfigureInitialGL()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.ColorMaterial);
            GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.AmbientAndDiffuse);

            ApplyToGL();
        }

        public void SetTipoLuz(TipoLuz tipo)
        {
            switch (tipo)
            {
                case TipoLuz.Apagada:
                    Luz.Apagar();
                    break;
                case TipoLuz.Direccional:
                    Luz.SetDireccional(new Vector3(1f, 1f, 1f));
                    break;
                case TipoLuz.Puntual:
                    Luz.SetPuntual(new Vector3(5f, 5f, 5f));
                    break;
            }
            ApplyToGL();
        }

        public void ApplyToGL()
        {
            if (!Luz.Habilitada)
            {
                GL.Disable(EnableCap.Lighting);
                GL.Disable(EnableCap.Light0);
                return;
            }

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            float[] pos = { Luz.Posicion.X, Luz.Posicion.Y, Luz.Posicion.Z, Luz.Posicion.W };
            float[] ambient = { Luz.Ambiente.R / 255f, Luz.Ambiente.G / 255f, Luz.Ambiente.B / 255f, 1f };
            float[] diffuse = { Luz.Difusa.R / 255f, Luz.Difusa.G / 255f, Luz.Difusa.B / 255f, 1f };
            float[] specular = { Luz.Especular.R / 255f, Luz.Especular.G / 255f, Luz.Especular.B / 255f, 1f };

            GL.Light(LightName.Light0, LightParameter.Position, pos);
            GL.Light(LightName.Light0, LightParameter.Ambient, ambient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, diffuse);
            GL.Light(LightName.Light0, LightParameter.Specular, specular);

            // Parámetros básicos para puntual (atenuación)
            if (Luz.Tipo == TipoLuz.Puntual)
            {
                GL.Light(LightName.Light0, LightParameter.ConstantAttenuation, 1.0f);
                GL.Light(LightName.Light0, LightParameter.LinearAttenuation, 0.02f);
                GL.Light(LightName.Light0, LightParameter.QuadraticAttenuation, 0.0005f);
            }
            else
            {
                GL.Light(LightName.Light0, LightParameter.ConstantAttenuation, 1.0f);
                GL.Light(LightName.Light0, LightParameter.LinearAttenuation, 0.0f);
                GL.Light(LightName.Light0, LightParameter.QuadraticAttenuation, 0.0f);
            }
        }
    }
}
