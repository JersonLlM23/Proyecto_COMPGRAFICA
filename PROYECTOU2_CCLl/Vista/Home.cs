using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PROYECTO_U2_CCLl.Controlador;
using PROYECTO_U2_CCLl.Modelo;

namespace PROYECTO_U2_CCLl
{
    public partial class Home : Form
    {
        private RenderizadorOpenGL renderizador;
        private Timer timerRender;
        private CamaraController camaraController;
        private LuzController luzController;
        private bool arrastrando = false; // Conservado para compatibilidad con otros controles
        private Point ultimoMouse;        // Conservado para compatibilidad con otros controles
        private bool glCargado = false;
        private DateTime _ultimoTick;
        private bool _actualizandoUI = false;

        public Home()
        {
            InitializeComponent();
            InicializarRenderizador();
        }

        private void InicializarRenderizador()
        {
            // Crear el renderizador
            renderizador = new RenderizadorOpenGL();
            camaraController = new CamaraController();
            luzController = new LuzController();

            // Configurar el GLControl
            if (glControlWindow != null)
            {
                glControlWindow.Load += GlControlWindow_Load;
                glControlWindow.Paint += GlControlWindow_Paint;
                glControlWindow.Resize += GlControlWindow_Resize;
                glControlWindow.MouseDown += GlControl_MouseDown;
                glControlWindow.MouseUp += GlControl_MouseUp;
                glControlWindow.MouseMove += GlControl_MouseMove;
                glControlWindow.MouseWheel += GlControl_MouseWheel;
                glControlWindow.KeyDown += GlControlWindow_KeyDown;
                glControlWindow.KeyUp += GlControlWindow_KeyUp;
                glControlWindow.PreviewKeyDown += (s, e) =>
                {
                    // Asegurar que las flechas sean tratadas como teclas de entrada
                    if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                        e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    {
                        e.IsInputKey = true;
                    }
                };
                glControlWindow.MouseEnter += (s, e) => glControlWindow.Focus();
            }

            // Timer para refrescar el render
            timerRender = new Timer();
            timerRender.Interval = 33; // ~30 FPS
            _ultimoTick = DateTime.Now;
            timerRender.Tick += (s, e) =>
            {
                var ahora = DateTime.Now;
                float dt = (float)(ahora - _ultimoTick).TotalSeconds;
                _ultimoTick = ahora;
                camaraController.Update(dt);
                glControlWindow?.Invalidate();
            };
            timerRender.Start();

            // Configurar combo de materiales
            if (comboMaterial != null)
            {
                comboMaterial.Items.Add("Wireframe");
                comboMaterial.Items.Add("Sólido");
                comboMaterial.Items.Add("Translúcido");
                comboMaterial.Items.Add("Phong");
                comboMaterial.SelectedIndex = 1; // Por defecto Sólido
                comboMaterial.SelectedIndexChanged += ComboMaterial_SelectedIndexChanged;
            }

            // Configurar combo de colores
            if (comboColor != null)
            {
                var colores = new Dictionary<string, Color>
                {
                    { "Rosa", Color.HotPink },
                    { "Rojo", Color.Red },
                    { "Naranja", Color.Orange },
                    { "Amarillo", Color.Yellow },
                    { "Verde", Color.Lime },
                    { "Azul", Color.DodgerBlue },
                    { "Celeste", Color.Cyan },
                    { "Morado", Color.BlueViolet },
                    { "Negro", Color.Black },
                    { "Gris", Color.Gray },
                    { "Blanco", Color.White }
                };
                foreach (var color in colores.Keys)
                {
                    comboColor.Items.Add(color);
                }
                comboColor.SelectedIndex = 5; // Por defecto Azul
                comboColor.SelectedIndexChanged += ComboColor_SelectedIndexChanged;
            }

            // Configurar combo de cámara
            if (comboCamara != null)
            {
                comboCamara.Items.Clear();
                comboCamara.Items.Add("Orbital");
                comboCamara.Items.Add("Libre");
                comboCamara.Items.Add("Fija");
                comboCamara.SelectedIndex = 0;
                comboCamara.SelectedIndexChanged += (s, e) =>
                {
                    var idx = comboCamara.SelectedIndex;
                    camaraController.SetTipoCamara((TipoCamara)idx);
                    glControlWindow?.Invalidate();
                };
            }

            // Configurar combo de luz
            if (comboLuz != null)
            {
                comboLuz.Items.Clear();
                comboLuz.Items.Add("Apagada");
                comboLuz.Items.Add("Direccional");
                comboLuz.Items.Add("Puntual");
                comboLuz.SelectedIndex = 1; // Direccional por defecto
                comboLuz.SelectedIndexChanged += (s, e) =>
                {
                    var idx = comboLuz.SelectedIndex;
                    luzController.SetTipoLuz((TipoLuz)idx);
                    glControlWindow?.Invalidate();
                };
            }

            // Configurar lista de figuras
            if (boxFiguras != null)
            {
                boxFiguras.SelectedIndexChanged += BoxFiguras_SelectedIndexChanged;
                boxFiguras.KeyDown += BoxFiguras_KeyDown;
            }

            // Configurar controles de posición
            if (numXPosicion != null)
            {
                numXPosicion.Minimum = -500;
                numXPosicion.Maximum = 500;
                numXPosicion.ValueChanged += NumPosicion_ValueChanged;
            }
            if (numYPosicion != null)
            {
                numYPosicion.Minimum = -500;
                numYPosicion.Maximum = 500;
                numYPosicion.ValueChanged += NumPosicion_ValueChanged;
            }
            if (numZPosicion != null)
            {
                numZPosicion.Minimum = -500;
                numZPosicion.Maximum = 500;
                numZPosicion.ValueChanged += NumPosicion_ValueChanged;
            }

            // Configurar trackbars de rotación
            if (trackXROT != null)
            {
                trackXROT.Minimum = -180;
                trackXROT.Maximum = 180;
                trackXROT.Value = 0;
                trackXROT.TickFrequency = 30;
                trackXROT.ValueChanged += TrackRotacion_ValueChanged;
                trackXROT.MouseDown += TrackRotacion_MouseDown;
            }
            if (trackYROT != null)
            {
                trackYROT.Minimum = -180;
                trackYROT.Maximum = 180;
                trackYROT.Value = 0;
                trackYROT.TickFrequency = 30;
                trackYROT.ValueChanged += TrackRotacion_ValueChanged;
                trackYROT.MouseDown += TrackRotacion_MouseDown;
            }
            if (trackZROT != null)
            {
                trackZROT.Minimum = -180;
                trackZROT.Maximum = 180;
                trackZROT.Value = 0;
                trackZROT.TickFrequency = 30;
                trackZROT.ValueChanged += TrackRotacion_ValueChanged;
                trackZROT.MouseDown += TrackRotacion_MouseDown;
            }

            // Configurar trackbars de escala (mapeados 0.1x - 3.0x)
            if (trackXESCAL != null)
            {
                trackXESCAL.Minimum = 10;   // 0.1x
                trackXESCAL.Maximum = 300;  // 3.0x
                trackXESCAL.Value = 100;    // 1.0x
                trackXESCAL.TickFrequency = 10;
                trackXESCAL.ValueChanged += TrackEscala_ValueChanged;
                trackXESCAL.MouseDown += TrackEscala_MouseDown;
            }
            if (trackYESCAL != null)
            {
                trackYESCAL.Minimum = 10;
                trackYESCAL.Maximum = 300;
                trackYESCAL.Value = 100;
                trackYESCAL.TickFrequency = 10;
                trackYESCAL.ValueChanged += TrackEscala_ValueChanged;
                trackYESCAL.MouseDown += TrackEscala_MouseDown;
            }
            if (trackZESCAL != null)
            {
                trackZESCAL.Minimum = 10;
                trackZESCAL.Maximum = 300;
                trackZESCAL.Value = 100;
                trackZESCAL.TickFrequency = 10;
                trackZESCAL.ValueChanged += TrackEscala_ValueChanged;
                trackZESCAL.MouseDown += TrackEscala_MouseDown;
            }

        }

        private void GlControlWindow_Load(object sender, EventArgs e)
        {
            if (glCargado) return;
            glCargado = true;

            GL.ClearColor(0.12f, 0.12f, 0.12f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.LineSmooth);
            GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);

            // Configurar iluminación mediante controlador
            luzController.ConfigureInitialGL();
        }

        private void GlControlWindow_Resize(object sender, EventArgs e)
        {
            if (!glCargado || glControlWindow == null) return;

            GL.Viewport(0, 0, glControlWindow.Width, glControlWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            float aspect = (float)glControlWindow.Width / (float)glControlWindow.Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f), aspect, 0.1f, 1000f);
            GL.LoadMatrix(ref perspective);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void GlControlWindow_Paint(object sender, PaintEventArgs e)
        {
            if (!glCargado || glControlWindow == null) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            var view = camaraController.GetViewMatrix();
            GL.LoadMatrix(ref view);

            // Asegurar estado de luz acorde al modo seleccionado
            luzController.ApplyToGL();

            // Dibujar ejes
            DibujarEjesGL();

            // Dibujar figuras
            foreach (var figura in renderizador.ObtenerFiguras())
            {
                if (figura is Piramide piramide)
                {
                    DibujarPiramideGL(figura, piramide);
                }
                else if (figura is Cubo cubo)
                {
                    DibujarCuboGL(figura, cubo);
                }
                else if (figura is Cono cono)
                {
                    DibujarConoGL(figura, cono);
                }
                else if (figura is Cilindro cilindro)
                {
                    DibujarCilindroGL(figura, cilindro);
                }
                else if (figura is Esfera esfera)
                {
                    DibujarEsferaGL(figura, esfera);
                }
                else if (figura is PrismaPentagonal prismaPentagonal)
                {
                    DibujarPrismaPentagonalGL(figura, prismaPentagonal);
                }
            }

            glControlWindow.SwapBuffers();
        }

        private void DibujarEjesGL()
        {
            GL.LineWidth(2f);
            GL.Begin(PrimitiveType.Lines);
            // Eje X rojo
            GL.Color3(1f, 0f, 0f);
            GL.Vertex3(0, 0, 0); GL.Vertex3(80, 0, 0);
            // Eje Y verde
            GL.Color3(0f, 1f, 0f);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 80, 0);
            // Eje Z azul
            GL.Color3(0f, 0.5f, 1f);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 80);
            GL.End();
        }

        private void DibujarPiramideGL(Figura3D figura, Piramide piramide)
        {
            float baseX = piramide.Base * figura.EscalaX;
            float baseZ = piramide.Base * figura.EscalaZ;
            float altura = piramide.Altura * figura.EscalaY;
            float halfX = baseX / 2f;
            float halfZ = baseZ / 2f;

            // Vértices locales
            var v0 = new Vector3(-halfX, 0, -halfZ);
            var v1 = new Vector3(halfX, 0, -halfZ);
            var v2 = new Vector3(halfX, 0, halfZ);
            var v3 = new Vector3(-halfX, 0, halfZ);
            var v4 = new Vector3(0, altura, 0);

            // Aplicar rotaciones locales
            Matrix4 rot = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(figura.RotZ)) *
                          Matrix4.CreateRotationY(MathHelper.DegreesToRadians(figura.RotY)) *
                          Matrix4.CreateRotationX(MathHelper.DegreesToRadians(figura.RotX));
            v0 = TransformVec(v0, rot);
            v1 = TransformVec(v1, rot);
            v2 = TransformVec(v2, rot);
            v3 = TransformVec(v3, rot);
            v4 = TransformVec(v4, rot);

            // Traslación global
            var offset = new Vector3(figura.PosX, figura.PosY, figura.PosZ);
            v0 += offset; v1 += offset; v2 += offset; v3 += offset; v4 += offset;

            // Color base
            var c = figura.ColorFigura;
            GL.Color4(c); // Usa alpha para translucidez

            if (figura.Material == TipoMaterial.Wireframe)
            {
                GL.LineWidth(2f);
                GL.Begin(PrimitiveType.Lines);
                // base
                GL.Vertex3(v0); GL.Vertex3(v1);
                GL.Vertex3(v1); GL.Vertex3(v2);
                GL.Vertex3(v2); GL.Vertex3(v3);
                GL.Vertex3(v3); GL.Vertex3(v0);
                // lados
                GL.Vertex3(v0); GL.Vertex3(v4);
                GL.Vertex3(v1); GL.Vertex3(v4);
                GL.Vertex3(v2); GL.Vertex3(v4);
                GL.Vertex3(v3); GL.Vertex3(v4);
                GL.End();
            }
            else
            {
                if (figura.Material == TipoMaterial.Translucido)
                {
                    GL.Color4(c.R / 255f, c.G / 255f, c.B / 255f, 0.5f);
                }

                // Caras triangulares
                GL.Begin(PrimitiveType.Triangles);
                GL.Vertex3(v0); GL.Vertex3(v1); GL.Vertex3(v4);
                GL.Vertex3(v1); GL.Vertex3(v2); GL.Vertex3(v4);
                GL.Vertex3(v2); GL.Vertex3(v3); GL.Vertex3(v4);
                GL.Vertex3(v3); GL.Vertex3(v0); GL.Vertex3(v4);
                GL.End();

                // Base
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(v0); GL.Vertex3(v1); GL.Vertex3(v2); GL.Vertex3(v3);
                GL.End();

                // Dibujar aristas para referencia
                GL.LineWidth(1.5f);
                GL.Color4(0f, 0f, 0f, 0.6f);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(v0); GL.Vertex3(v1);
                GL.Vertex3(v1); GL.Vertex3(v2);
                GL.Vertex3(v2); GL.Vertex3(v3);
                GL.Vertex3(v3); GL.Vertex3(v0);
                GL.Vertex3(v0); GL.Vertex3(v4);
                GL.Vertex3(v1); GL.Vertex3(v4);
                GL.Vertex3(v2); GL.Vertex3(v4);
                GL.Vertex3(v3); GL.Vertex3(v4);
                GL.End();
            }
        }

        private Vector3 TransformVec(Vector3 v, Matrix4 m)
        {
            // Multiplicación de vector3 por la parte rotacional de Matrix4
            return new Vector3(
                v.X * m.M11 + v.Y * m.M21 + v.Z * m.M31,
                v.X * m.M12 + v.Y * m.M22 + v.Z * m.M32,
                v.X * m.M13 + v.Y * m.M23 + v.Z * m.M33
            );
        }

        private void DibujarCuboGL(Figura3D figura, Cubo cubo)
        {
            float halfX = (cubo.Lado * figura.EscalaX) / 2f;
            float halfY = (cubo.Lado * figura.EscalaY) / 2f;
            float halfZ = (cubo.Lado * figura.EscalaZ) / 2f;

            // 8 vértices del cubo centrado
            var vertices = new Vector3[8];
            vertices[0] = new Vector3(-halfX, -halfY, -halfZ); // FBL
            vertices[1] = new Vector3(halfX, -halfY, -halfZ); // FBR
            vertices[2] = new Vector3(halfX, halfY, -halfZ); // FTR
            vertices[3] = new Vector3(-halfX, halfY, -halfZ); // FTL
            vertices[4] = new Vector3(-halfX, -halfY, halfZ); // BBL
            vertices[5] = new Vector3(halfX, -halfY, halfZ); // BBR
            vertices[6] = new Vector3(halfX, halfY, halfZ); // BTR
            vertices[7] = new Vector3(-halfX, halfY, halfZ); // BTL

            // Aplicar rotaciones locales
            Matrix4 rot = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(figura.RotZ)) *
                          Matrix4.CreateRotationY(MathHelper.DegreesToRadians(figura.RotY)) *
                          Matrix4.CreateRotationX(MathHelper.DegreesToRadians(figura.RotX));
            for (int i = 0; i < 8; i++)
            {
                vertices[i] = TransformVec(vertices[i], rot);
            }

            // Traslación global
            var offset = new Vector3(figura.PosX, figura.PosY, figura.PosZ);
            for (int i = 0; i < 8; i++)
            {
                vertices[i] += offset;
            }

            var c = figura.ColorFigura;

            if (figura.Material == TipoMaterial.Wireframe)
            {
                GL.LineWidth(2f);
                GL.Color4(c);
                GL.Begin(PrimitiveType.Lines);
                // Cara frontal
                GL.Vertex3(vertices[0]); GL.Vertex3(vertices[1]);
                GL.Vertex3(vertices[1]); GL.Vertex3(vertices[2]);
                GL.Vertex3(vertices[2]); GL.Vertex3(vertices[3]);
                GL.Vertex3(vertices[3]); GL.Vertex3(vertices[0]);
                // Cara trasera
                GL.Vertex3(vertices[4]); GL.Vertex3(vertices[5]);
                GL.Vertex3(vertices[5]); GL.Vertex3(vertices[6]);
                GL.Vertex3(vertices[6]); GL.Vertex3(vertices[7]);
                GL.Vertex3(vertices[7]); GL.Vertex3(vertices[4]);
                // Conexiones
                GL.Vertex3(vertices[0]); GL.Vertex3(vertices[4]);
                GL.Vertex3(vertices[1]); GL.Vertex3(vertices[5]);
                GL.Vertex3(vertices[2]); GL.Vertex3(vertices[6]);
                GL.Vertex3(vertices[3]); GL.Vertex3(vertices[7]);
                GL.End();
            }
            else
            {
                if (figura.Material == TipoMaterial.Translucido)
                {
                    GL.Color4(c.R / 255f, c.G / 255f, c.B / 255f, 0.5f);
                }
                else
                {
                    GL.Color4(c);
                }

                // Dibujar 6 caras como quads
                GL.Begin(PrimitiveType.Quads);
                // Frontal (Z-)
                GL.Vertex3(vertices[0]); GL.Vertex3(vertices[1]); GL.Vertex3(vertices[2]); GL.Vertex3(vertices[3]);
                // Trasera (Z+)
                GL.Vertex3(vertices[5]); GL.Vertex3(vertices[4]); GL.Vertex3(vertices[7]); GL.Vertex3(vertices[6]);
                // Inferior (Y-)
                GL.Vertex3(vertices[4]); GL.Vertex3(vertices[5]); GL.Vertex3(vertices[1]); GL.Vertex3(vertices[0]);
                // Superior (Y+)
                GL.Vertex3(vertices[3]); GL.Vertex3(vertices[2]); GL.Vertex3(vertices[6]); GL.Vertex3(vertices[7]);
                // Izquierda (X-)
                GL.Vertex3(vertices[4]); GL.Vertex3(vertices[0]); GL.Vertex3(vertices[3]); GL.Vertex3(vertices[7]);
                // Derecha (X+)
                GL.Vertex3(vertices[1]); GL.Vertex3(vertices[5]); GL.Vertex3(vertices[6]); GL.Vertex3(vertices[2]);
                GL.End();


                GL.LineWidth(1.5f);
                GL.Color4(0f, 0f, 0f, 0.6f);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(vertices[0]); GL.Vertex3(vertices[1]);
                GL.Vertex3(vertices[1]); GL.Vertex3(vertices[2]);
                GL.Vertex3(vertices[2]); GL.Vertex3(vertices[3]);
                GL.Vertex3(vertices[3]); GL.Vertex3(vertices[0]);
                GL.Vertex3(vertices[4]); GL.Vertex3(vertices[5]);
                GL.Vertex3(vertices[5]); GL.Vertex3(vertices[6]);
                GL.Vertex3(vertices[6]); GL.Vertex3(vertices[7]);
                GL.Vertex3(vertices[7]); GL.Vertex3(vertices[4]);
                GL.Vertex3(vertices[0]); GL.Vertex3(vertices[4]);
                GL.Vertex3(vertices[1]); GL.Vertex3(vertices[5]);
                GL.Vertex3(vertices[2]); GL.Vertex3(vertices[6]);
                GL.Vertex3(vertices[3]); GL.Vertex3(vertices[7]);
                GL.End();
            }
        }

        private void DibujarConoGL(Figura3D figura, Cono cono)
        {
            float radio = cono.Radio * figura.EscalaX;
            float altura = cono.Altura * figura.EscalaY;
            int segmentos = cono.Segmentos;

            // Generar vértices del círculo base y el vértice superior
            var verticesBase = new Vector3[segmentos];
            float angleStep = 360f / segmentos;

            for (int i = 0; i < segmentos; i++)
            {
                float angle = MathHelper.DegreesToRadians(i * angleStep);
                float x = radio * (float)Math.Cos(angle);
                float z = radio * (float)Math.Sin(angle);
                verticesBase[i] = new Vector3(x, 0, z);
            }

            var verticeSuper = new Vector3(0, altura, 0);

            // Aplicar rotaciones locales
            Matrix4 rot = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(figura.RotZ)) *
          Matrix4.CreateRotationY(MathHelper.DegreesToRadians(figura.RotY)) *
                Matrix4.CreateRotationX(MathHelper.DegreesToRadians(figura.RotX));

            for (int i = 0; i < segmentos; i++)
            {
                verticesBase[i] = TransformVec(verticesBase[i], rot);
            }
            verticeSuper = TransformVec(verticeSuper, rot);

            // Traslación global
            var offset = new Vector3(figura.PosX, figura.PosY, figura.PosZ);
            for (int i = 0; i < segmentos; i++)
            {
                verticesBase[i] += offset;
            }
            verticeSuper += offset;

            var c = figura.ColorFigura;

            if (figura.Material == TipoMaterial.Wireframe)
            {
                GL.LineWidth(2f);
                GL.Color4(c);
                GL.Begin(PrimitiveType.Lines);

                // Base circular
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesBase[i]);
                    GL.Vertex3(verticesBase[next]);
                }

                // Líneas al vértice superior
                for (int i = 0; i < segmentos; i += 4) // Cada 4 segmentos para no saturar
                {
                    GL.Vertex3(verticesBase[i]);
                    GL.Vertex3(verticeSuper);
                }

                GL.End();
            }
            else
            {
                if (figura.Material == TipoMaterial.Translucido)
                {
                    GL.Color4(c.R / 255f, c.G / 255f, c.B / 255f, 0.5f);
                }
                else
                {
                    GL.Color4(c);
                }

                // Dibujar superficie lateral del cono
                GL.Begin(PrimitiveType.Triangles);
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesBase[i]);
                    GL.Vertex3(verticesBase[next]);
                    GL.Vertex3(verticeSuper);
                }
                GL.End();

                // Dibujar base
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Vertex3(offset); // Centro de la base
                for (int i = 0; i < segmentos; i++)
                {
                    GL.Vertex3(verticesBase[i]);
                }
                GL.Vertex3(verticesBase[0]); // Cerrar el círculo
                GL.End();

                // Dibujar aristas para referencia
                GL.LineWidth(1.5f);
                GL.Color4(0f, 0f, 0f, 0.6f);
                GL.Begin(PrimitiveType.Lines);

                // Base circular
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesBase[i]);
                    GL.Vertex3(verticesBase[next]);
                }

                // Algunas líneas al vértice
                for (int i = 0; i < segmentos; i += segmentos / 8)
                {
                    GL.Vertex3(verticesBase[i]);
                    GL.Vertex3(verticeSuper);
                }

                GL.End();
            }
        }

        private void DibujarCilindroGL(Figura3D figura, Cilindro cilindro)
        {
            float radio = cilindro.Radio * figura.EscalaX;
            float altura = cilindro.Altura * figura.EscalaY;
            int segmentos = cilindro.Segmentos;

            // Generar vértices de ambos círculos
            var verticesInferior = new Vector3[segmentos];
            var verticesSuperior = new Vector3[segmentos];
            float angleStep = 360f / segmentos;

            for (int i = 0; i < segmentos; i++)
            {
                float angle = MathHelper.DegreesToRadians(i * angleStep);
                float x = radio * (float)Math.Cos(angle);
                float z = radio * (float)Math.Sin(angle);
                verticesInferior[i] = new Vector3(x, 0, z);
                verticesSuperior[i] = new Vector3(x, altura, z);
            }

            // Aplicar rotaciones locales
            Matrix4 rot = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(figura.RotZ)) *
         Matrix4.CreateRotationY(MathHelper.DegreesToRadians(figura.RotY)) *
           Matrix4.CreateRotationX(MathHelper.DegreesToRadians(figura.RotX));

            for (int i = 0; i < segmentos; i++)
            {
                verticesInferior[i] = TransformVec(verticesInferior[i], rot);
                verticesSuperior[i] = TransformVec(verticesSuperior[i], rot);
            }

            // Traslación global
            var offset = new Vector3(figura.PosX, figura.PosY, figura.PosZ);
            for (int i = 0; i < segmentos; i++)
            {
                verticesInferior[i] += offset;
                verticesSuperior[i] += offset;
            }

            var c = figura.ColorFigura;

            if (figura.Material == TipoMaterial.Wireframe)
            {
                GL.LineWidth(2f);
                GL.Color4(c);
                GL.Begin(PrimitiveType.Lines);

                // Círculo inferior
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesInferior[next]);
                }

                // Círculo superior
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesSuperior[i]);
                    GL.Vertex3(verticesSuperior[next]);
                }

                // Líneas verticales
                for (int i = 0; i < segmentos; i += 4) // Cada 4 segmentos
                {
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesSuperior[i]);
                }

                GL.End();
            }
            else
            {
                if (figura.Material == TipoMaterial.Translucido)
                {
                    GL.Color4(c.R / 255f, c.G / 255f, c.B / 255f, 0.5f);
                }
                else
                {
                    GL.Color4(c);
                }

                // Dibujar superficie lateral
                GL.Begin(PrimitiveType.Quads);
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesInferior[next]);
                    GL.Vertex3(verticesSuperior[next]);
                    GL.Vertex3(verticesSuperior[i]);
                }
                GL.End();

                // Dibujar tapa inferior
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Vertex3(offset); // Centro inferior
                for (int i = 0; i < segmentos; i++)
                {
                    GL.Vertex3(verticesInferior[i]);
                }
                GL.Vertex3(verticesInferior[0]);
                GL.End();

                // Dibujar tapa superior
                var centroSuperior = new Vector3(0, altura, 0);
                centroSuperior = TransformVec(centroSuperior, rot) + offset;
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Vertex3(centroSuperior);
                for (int i = segmentos - 1; i >= 0; i--)
                {
                    GL.Vertex3(verticesSuperior[i]);
                }
                GL.Vertex3(verticesSuperior[segmentos - 1]);
                GL.End();

                // Dibujar aristas para referencia
                GL.LineWidth(1.5f);
                GL.Color4(0f, 0f, 0f, 0.6f);
                GL.Begin(PrimitiveType.Lines);

                // Círculos
                for (int i = 0; i < segmentos; i++)
                {
                    int next = (i + 1) % segmentos;
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesInferior[next]);
                    GL.Vertex3(verticesSuperior[i]);
                    GL.Vertex3(verticesSuperior[next]);
                }

                // Líneas verticales
                for (int i = 0; i < segmentos; i += segmentos / 8)
                {
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesSuperior[i]);
                }

                GL.End();
            }
        }

        private void DibujarEsferaGL(Figura3D figura, Esfera esfera)
        {
            float radioX = esfera.Radio * figura.EscalaX;
            float radioY = esfera.Radio * figura.EscalaY;
            float radioZ = esfera.Radio * figura.EscalaZ;
            int segmentos = esfera.Segmentos;
            int anillos = esfera.Anillos;

            // Generar vértices de la esfera usando coordenadas esféricas
            var vertices = new List<Vector3>();

            for (int lat = 0; lat <= anillos; lat++)
            {
                float theta = lat * (float)Math.PI / anillos;
                float sinTheta = (float)Math.Sin(theta);
                float cosTheta = (float)Math.Cos(theta);

                for (int lon = 0; lon <= segmentos; lon++)
                {
                    float phi = lon * 2 * (float)Math.PI / segmentos;
                    float sinPhi = (float)Math.Sin(phi);
                    float cosPhi = (float)Math.Cos(phi);

                    float x = cosPhi * sinTheta;
                    float y = cosTheta;
                    float z = sinPhi * sinTheta;

                    // Aplicar escala diferente en cada eje
                    vertices.Add(new Vector3(x * radioX, y * radioY, z * radioZ));
                }
            }

            // Aplicar rotaciones locales
            Matrix4 rot = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(figura.RotZ)) *
                          Matrix4.CreateRotationY(MathHelper.DegreesToRadians(figura.RotY)) *
                          Matrix4.CreateRotationX(MathHelper.DegreesToRadians(figura.RotX));

            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = TransformVec(vertices[i], rot);
            }

            // Traslación global
            var offset = new Vector3(figura.PosX, figura.PosY, figura.PosZ);
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] += offset;
            }

            var c = figura.ColorFigura;

            if (figura.Material == TipoMaterial.Wireframe)
            {
                GL.LineWidth(1.5f);
                GL.Color4(c);

                // Dibujar líneas de latitud
                for (int lat = 0; lat < anillos; lat++)
                {
                    GL.Begin(PrimitiveType.LineLoop);
                    for (int lon = 0; lon <= segmentos; lon++)
                    {
                        int idx = lat * (segmentos + 1) + lon;
                        GL.Vertex3(vertices[idx]);
                    }
                    GL.End();
                }

                // Dibujar líneas de longitud
                for (int lon = 0; lon <= segmentos; lon++)
                {
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int lat = 0; lat <= anillos; lat++)
                    {
                        int idx = lat * (segmentos + 1) + lon;
                        GL.Vertex3(vertices[idx]);
                    }
                    GL.End();
                }
            }
            else
            {
                if (figura.Material == TipoMaterial.Translucido)
                {
                    GL.Color4(c.R / 255f, c.G / 255f, c.B / 255f, 0.5f);
                }
                else
                {
                    GL.Color4(c);
                }

                // Dibujar triángulos de la esfera
                for (int lat = 0; lat < anillos; lat++)
                {
                    GL.Begin(PrimitiveType.QuadStrip);
                    for (int lon = 0; lon <= segmentos; lon++)
                    {
                        int idx1 = lat * (segmentos + 1) + lon;
                        int idx2 = (lat + 1) * (segmentos + 1) + lon;

                        GL.Vertex3(vertices[idx1]);
                        GL.Vertex3(vertices[idx2]);
                    }
                    GL.End();
                }

                // Dibujar algunas líneas para referencia
                GL.LineWidth(1.0f);
                GL.Color4(0f, 0f, 0f, 0.4f);

                // Líneas de latitud cada 4 anillos
                for (int lat = 0; lat < anillos; lat += 4)
                {
                    GL.Begin(PrimitiveType.LineLoop);
                    for (int lon = 0; lon <= segmentos; lon++)
                    {
                        int idx = lat * (segmentos + 1) + lon;
                        GL.Vertex3(vertices[idx]);
                    }
                    GL.End();
                }

                // Líneas de longitud cada 4 segmentos
                for (int lon = 0; lon <= segmentos; lon += 4)
                {
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int lat = 0; lat <= anillos; lat++)
                    {
                        int idx = lat * (segmentos + 1) + lon;
                        GL.Vertex3(vertices[idx]);
                    }
                    GL.End();
                }
            }
        }

        private void DibujarPrismaPentagonalGL(Figura3D figura, PrismaPentagonal prismaPentagonal)
        {
            float radioX = prismaPentagonal.Radio * figura.EscalaX;
            float radioZ = prismaPentagonal.Radio * figura.EscalaZ;
            float altura = prismaPentagonal.Altura * figura.EscalaY;
            int lados = 5; // Pentágono

            // Generar vértices de ambos pentágonos (inferior y superior)
            var verticesInferior = new Vector3[lados];
            var verticesSuperior = new Vector3[lados];
            float angleStep = 360f / lados;

            for (int i = 0; i < lados; i++)
            {
                float angle = MathHelper.DegreesToRadians(i * angleStep);
                float x = radioX * (float)Math.Cos(angle);
                float z = radioZ * (float)Math.Sin(angle);
                verticesInferior[i] = new Vector3(x, 0, z);
                verticesSuperior[i] = new Vector3(x, altura, z);
            }

            // Aplicar rotaciones locales
            Matrix4 rot = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(figura.RotZ)) *
                          Matrix4.CreateRotationY(MathHelper.DegreesToRadians(figura.RotY)) *
                          Matrix4.CreateRotationX(MathHelper.DegreesToRadians(figura.RotX));

            for (int i = 0; i < lados; i++)
            {
                verticesInferior[i] = TransformVec(verticesInferior[i], rot);
                verticesSuperior[i] = TransformVec(verticesSuperior[i], rot);
            }

            // Traslación global
            var offset = new Vector3(figura.PosX, figura.PosY, figura.PosZ);
            for (int i = 0; i < lados; i++)
            {
                verticesInferior[i] += offset;
                verticesSuperior[i] += offset;
            }

            var c = figura.ColorFigura;

            if (figura.Material == TipoMaterial.Wireframe)
            {
                GL.LineWidth(2f);
                GL.Color4(c);
                GL.Begin(PrimitiveType.Lines);

                // Pentágono inferior
                for (int i = 0; i < lados; i++)
                {
                    int next = (i + 1) % lados;
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesInferior[next]);
                }

                // Pentágono superior
                for (int i = 0; i < lados; i++)
                {
                    int next = (i + 1) % lados;
                    GL.Vertex3(verticesSuperior[i]);
                    GL.Vertex3(verticesSuperior[next]);
                }

                // Líneas verticales
                for (int i = 0; i < lados; i++)
                {
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesSuperior[i]);
                }

                GL.End();
            }
            else
            {
                if (figura.Material == TipoMaterial.Translucido)
                {
                    GL.Color4(c.R / 255f, c.G / 255f, c.B / 255f, 0.5f);
                }
                else
                {
                    GL.Color4(c);
                }

                // Dibujar superficie lateral (caras rectangulares)
                GL.Begin(PrimitiveType.Quads);
                for (int i = 0; i < lados; i++)
                {
                    int next = (i + 1) % lados;
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesInferior[next]);
                    GL.Vertex3(verticesSuperior[next]);
                    GL.Vertex3(verticesSuperior[i]);
                }
                GL.End();

                // Dibujar tapa inferior (pentágono)
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Vertex3(offset); // Centro inferior
                for (int i = 0; i < lados; i++)
                {
                    GL.Vertex3(verticesInferior[i]);
                }
                GL.Vertex3(verticesInferior[0]); // Cerrar
                GL.End();

                // Dibujar tapa superior (pentágono)
                var centroSuperior = new Vector3(0, altura, 0);
                centroSuperior = TransformVec(centroSuperior, rot) + offset;
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Vertex3(centroSuperior);
                for (int i = lados - 1; i >= 0; i--)
                {
                    GL.Vertex3(verticesSuperior[i]);
                }
                GL.Vertex3(verticesSuperior[lados - 1]); // Cerrar
                GL.End();

                // Dibujar aristas para referencia
                GL.LineWidth(1.5f);
                GL.Color4(0f, 0f, 0f, 0.6f);
                GL.Begin(PrimitiveType.Lines);

                // Pentágonos
                for (int i = 0; i < lados; i++)
                {
                    int next = (i + 1) % lados;
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesInferior[next]);
                    GL.Vertex3(verticesSuperior[i]);
                    GL.Vertex3(verticesSuperior[next]);
                }

                // Líneas verticales
                for (int i = 0; i < lados; i++)
                {
                    GL.Vertex3(verticesInferior[i]);
                    GL.Vertex3(verticesSuperior[i]);
                }

                GL.End();
            }
        }

        private void picturePiramide_Click(object sender, EventArgs e)
        {

            int numeroPiramides = renderizador.ObtenerFiguras()
                .Where(f => f is Piramide).Count();

            Piramide nuevaPiramide = new Piramide(
                $"Pirámide {numeroPiramides + 1}",
                baseSize: 50,
                altura: 75
            );


            nuevaPiramide.PosX = 0;
            nuevaPiramide.PosY = 0;
            nuevaPiramide.PosZ = 0;
            nuevaPiramide.ColorFigura = Color.DodgerBlue;


            renderizador.AgregarFigura(nuevaPiramide);
            renderizador.SeleccionarFigura(nuevaPiramide);


            ActualizarListaFiguras();
            ActualizarControlesSegunFigura(nuevaPiramide);


            MessageBox.Show($"Pirámide agregada!\n\nUsa los controles para rotarla y transformarla.",
                "Figura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureCubo_Click(object sender, EventArgs e)
        {

            int numeroCubos = renderizador.ObtenerFiguras()
                .Where(f => f is Cubo).Count();

            Cubo nuevoCubo = new Cubo(
                $"Cubo {numeroCubos + 1}",
                lado: 60
            );


            nuevoCubo.PosX = 0;
            nuevoCubo.PosY = 0;
            nuevoCubo.PosZ = 0;
            nuevoCubo.ColorFigura = Color.Orange;


            renderizador.AgregarFigura(nuevoCubo);
            renderizador.SeleccionarFigura(nuevoCubo);


            ActualizarListaFiguras();
            ActualizarControlesSegunFigura(nuevoCubo);


            MessageBox.Show($"Cubo agregado!\n\nUsa los controles para rotarlo y transformarlo.",
                "Figura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureCono_Click(object sender, EventArgs e)
        {
            // Contar conos existentes
            int numeroConos = renderizador.ObtenerFiguras()
               .Where(f => f is Cono).Count();

            Cono nuevoCono = new Cono(
       $"Cono {numeroConos + 1}",
                   radio: 40,
     altura: 80,
            segmentos: 32
        );

            // Configuración inicial
            nuevoCono.PosX = 0;
            nuevoCono.PosY = 0;
            nuevoCono.PosZ = 0;
            nuevoCono.ColorFigura = Color.Lime;

            // Agregar y seleccionar
            renderizador.AgregarFigura(nuevoCono);
            renderizador.SeleccionarFigura(nuevoCono);

            // Actualizar UI
            ActualizarListaFiguras();
            ActualizarControlesSegunFigura(nuevoCono);

            // Mensaje de confirmación
            MessageBox.Show($"Cono agregado!\n\nUsa los controles para rotarlo y transformarlo.",
        "Figura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureCilindro_Click(object sender, EventArgs e)
        {
            // Contar cilindros existentes
            int numeroCilindros = renderizador.ObtenerFiguras()
             .Where(f => f is Cilindro).Count();

            Cilindro nuevoCilindro = new Cilindro(
         $"Cilindro {numeroCilindros + 1}",
     radio: 35,
   altura: 70,
         segmentos: 32
        );

            // Configuración inicial
            nuevoCilindro.PosX = 0;
            nuevoCilindro.PosY = 0;
            nuevoCilindro.PosZ = 0;
            nuevoCilindro.ColorFigura = Color.BlueViolet;

            // Agregar y seleccionar
            renderizador.AgregarFigura(nuevoCilindro);
            renderizador.SeleccionarFigura(nuevoCilindro);

            // Actualizar UI
            ActualizarListaFiguras();
            ActualizarControlesSegunFigura(nuevoCilindro);

            // Mensaje de confirmación
            MessageBox.Show($"Cilindro agregado!\n\nUsa los controles para rotarlo y transformarlo.",
               "Figura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureEsfera_Click(object sender, EventArgs e)
        {
            // Contar esferas existentes
            int numeroEsferas = renderizador.ObtenerFiguras()
                .Where(f => f is Esfera).Count();

            Esfera nuevaEsfera = new Esfera(
                $"Esfera {numeroEsferas + 1}",
                radio: 40,
                segmentos: 32,
                anillos: 16
            );

            // Configuración inicial
            nuevaEsfera.PosX = 0;
            nuevaEsfera.PosY = 0;
            nuevaEsfera.PosZ = 0;
            nuevaEsfera.ColorFigura = Color.HotPink;

            // Agregar y seleccionar
            renderizador.AgregarFigura(nuevaEsfera);
            renderizador.SeleccionarFigura(nuevaEsfera);

            // Actualizar UI
            ActualizarListaFiguras();
            ActualizarControlesSegunFigura(nuevaEsfera);

            // Mensaje de confirmación
            MessageBox.Show($"Esfera agregada!\n\nUsa los controles para rotarla y transformarla.",
                "Figura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picturePrismaRectang_Click(object sender, EventArgs e)
        {
            // Contar prismas pentagonales existentes
            int numeroPrismas = renderizador.ObtenerFiguras()
                .Where(f => f is PrismaPentagonal).Count();

            PrismaPentagonal nuevoPrisma = new PrismaPentagonal(
                $"Prisma Pentagonal {numeroPrismas + 1}",
                radio: 35,
                altura: 70
            );

            // Configuración inicial
            nuevoPrisma.PosX = 0;
            nuevoPrisma.PosY = 0;
            nuevoPrisma.PosZ = 0;
            nuevoPrisma.ColorFigura = Color.Cyan;

            // Agregar y seleccionar
            renderizador.AgregarFigura(nuevoPrisma);
            renderizador.SeleccionarFigura(nuevoPrisma);

            // Actualizar UI
            ActualizarListaFiguras();
            ActualizarControlesSegunFigura(nuevoPrisma);

            // Mensaje de confirmación
            MessageBox.Show($"Prisma Pentagonal agregado!\n\nUsa los controles para rotarlo y transformarlo.",
                "Figura creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarListaFiguras()
        {
            if (boxFiguras != null)
            {
                boxFiguras.Items.Clear();
                foreach (var figura in renderizador.ObtenerFiguras())
                {
                    boxFiguras.Items.Add(figura.Nombre);
                }
            }
        }

        private void ActualizarControlesSegunFigura(Figura3D figura)
        {
            if (figura == null) return;

            _actualizandoUI = true;


            if (comboMaterial != null)
            {
                comboMaterial.SelectedIndex = (int)figura.Material;
            }


            if (comboColor != null)
            {
                var colores = new Color[]
                {
                    Color.HotPink,
                    Color.Red,
                    Color.Orange,
                    Color.Yellow,
                    Color.Lime,
                    Color.DodgerBlue,
                    Color.Cyan,
                    Color.BlueViolet,
                    Color.Black,
                    Color.Gray,
                    Color.White
                };

                for (int i = 0; i < colores.Length; i++)
                {
                    if (figura.ColorFigura.ToArgb() == colores[i].ToArgb())
                    {
                        comboColor.SelectedIndex = i;
                        break;
                    }
                }
            }


            if (numXPosicion != null)
            {
                decimal valX = (decimal)figura.PosX;
                valX = Math.Max(numXPosicion.Minimum, Math.Min(numXPosicion.Maximum, valX));
                numXPosicion.Value = valX;
            }
            if (numYPosicion != null)
            {
                decimal valY = (decimal)figura.PosY;
                valY = Math.Max(numYPosicion.Minimum, Math.Min(numYPosicion.Maximum, valY));
                numYPosicion.Value = valY;
            }
            if (numZPosicion != null)
            {
                decimal valZ = (decimal)figura.PosZ;
                valZ = Math.Max(numZPosicion.Minimum, Math.Min(numZPosicion.Maximum, valZ));
                numZPosicion.Value = valZ;
            }


            if (trackXROT != null)
            {
                trackXROT.Value = (int)figura.RotX;
            }
            if (trackYROT != null)
            {
                trackYROT.Value = (int)figura.RotY;
            }
            if (trackZROT != null)
            {
                trackZROT.Value = (int)figura.RotZ;
            }

            // Actualizar trackbars de escala (se guardan como factor * 100)
            if (trackXESCAL != null)
            {
                int valX = (int)(figura.EscalaX * 100f);
                valX = Math.Max(trackXESCAL.Minimum, Math.Min(trackXESCAL.Maximum, valX));
                trackXESCAL.Value = valX;
            }
            if (trackYESCAL != null)
            {
                int valY = (int)(figura.EscalaY * 100f);
                valY = Math.Max(trackYESCAL.Minimum, Math.Min(trackYESCAL.Maximum, valY));
                trackYESCAL.Value = valY;
            }
            if (trackZESCAL != null)
            {
                int valZ = (int)(figura.EscalaZ * 100f);
                valZ = Math.Max(trackZESCAL.Minimum, Math.Min(trackZESCAL.Maximum, valZ));
                trackZESCAL.Value = valZ;
            }

            _actualizandoUI = false;
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            renderizador.Limpiar();
            camaraController.Reset();
            ActualizarListaFiguras();
            glControlWindow?.Invalidate();
        }

        private void GlControl_MouseDown(object sender, MouseEventArgs e)
        {
            camaraController.HandleMouseDown(e);
        }

        private void GlControl_MouseUp(object sender, MouseEventArgs e)
        {
            camaraController.HandleMouseUp(e);
        }

        private void GlControl_MouseMove(object sender, MouseEventArgs e)
        {
            camaraController.HandleMouseMove(e);
            glControlWindow?.Invalidate();
        }

        private void GlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            camaraController.HandleMouseWheel(e);
            glControlWindow?.Invalidate();
        }

        private void GlControlWindow_KeyDown(object sender, KeyEventArgs e)
        {
            camaraController.HandleKeyDown(e.KeyCode);
            glControlWindow?.Invalidate();
        }

        private void GlControlWindow_KeyUp(object sender, KeyEventArgs e)
        {
            camaraController.HandleKeyUp(e.KeyCode);
        }

        private void ComboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_actualizandoUI) return;
            Figura3D figuraActual = renderizador.FiguraSeleccionada();
            if (figuraActual != null && comboMaterial.SelectedIndex >= 0)
            {
                figuraActual.Material = (TipoMaterial)comboMaterial.SelectedIndex;
                glControlWindow?.Invalidate();
            }
        }

        private void ComboColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_actualizandoUI) return;
            if (comboColor.SelectedIndex < 0) return;

            var colores = new Color[]
            {
                Color.HotPink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.DodgerBlue,
                Color.Cyan,
                Color.BlueViolet,
                Color.Black,
                Color.Gray,
                Color.White
            };

            Figura3D figuraActual = renderizador.FiguraSeleccionada();
            if (figuraActual != null && comboColor.SelectedIndex < colores.Length)
            {
                figuraActual.ColorFigura = colores[comboColor.SelectedIndex];
                glControlWindow?.Invalidate();
            }
        }

        private void NumPosicion_ValueChanged(object sender, EventArgs e)
        {
            if (_actualizandoUI) return;
            Figura3D figuraActual = renderizador.FiguraSeleccionada();
            if (figuraActual != null)
            {
                if (numXPosicion != null)
                    figuraActual.PosX = (float)numXPosicion.Value;
                if (numYPosicion != null)
                    figuraActual.PosY = (float)numYPosicion.Value;
                if (numZPosicion != null)
                    figuraActual.PosZ = (float)numZPosicion.Value;

                glControlWindow?.Invalidate();
            }
        }

        private void TrackRotacion_ValueChanged(object sender, EventArgs e)
        {
            if (_actualizandoUI) return;
            Figura3D figuraActual = renderizador.FiguraSeleccionada();
            if (figuraActual != null)
            {
                if (trackXROT != null)
                    figuraActual.RotX = trackXROT.Value;
                if (trackYROT != null)
                    figuraActual.RotY = trackYROT.Value;
                if (trackZROT != null)
                    figuraActual.RotZ = trackZROT.Value;

                glControlWindow?.Invalidate();
            }
        }

        private void TrackRotacion_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                TrackBar track = sender as TrackBar;
                if (track != null)
                {
                    track.Value = 0;
                }
            }
        }

        private void TrackEscala_ValueChanged(object sender, EventArgs e)
        {
            if (_actualizandoUI) return;
            Figura3D figuraActual = renderizador.FiguraSeleccionada();
            if (figuraActual != null)
            {
                if (trackXESCAL != null)
                    figuraActual.EscalaX = trackXESCAL.Value / 100f;
                if (trackYESCAL != null)
                    figuraActual.EscalaY = trackYESCAL.Value / 100f;
                if (trackZESCAL != null)
                    figuraActual.EscalaZ = trackZESCAL.Value / 100f;

                glControlWindow?.Invalidate();
            }
        }

        private void TrackEscala_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                TrackBar track = sender as TrackBar;
                if (track != null)
                {
                    track.Value = 100;
                }
            }
        }

        private void BoxFiguras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxFiguras == null) return;
            int idx = boxFiguras.SelectedIndex;
            var figuras = renderizador.ObtenerFiguras();
            if (idx >= 0 && idx < figuras.Count)
            {
                var figura = figuras[idx];
                renderizador.SeleccionarFigura(figura);
                ActualizarControlesSegunFigura(figura);
                glControlWindow?.Invalidate();
            }
        }

        private void BoxFiguras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                EliminarFiguraSeleccionada();
                e.Handled = true;
            }
        }

        private void EliminarFiguraSeleccionada()
        {
            if (boxFiguras == null) return;
            int idx = boxFiguras.SelectedIndex;
            var figuras = renderizador.ObtenerFiguras();
            if (idx < 0 || idx >= figuras.Count) return;

            var figura = figuras[idx];
            bool removed = renderizador.EliminarFigura(figura);
            if (!removed) return;


            var restantes = renderizador.ObtenerFiguras();
            ActualizarListaFiguras();

            if (restantes.Count > 0)
            {
                int nuevoIdx = Math.Min(idx, restantes.Count - 1);
                boxFiguras.SelectedIndex = nuevoIdx;
                var nuevaFigura = restantes[nuevoIdx];
                renderizador.SeleccionarFigura(nuevaFigura);
                ActualizarControlesSegunFigura(nuevaFigura);
            }
            else
            {
                renderizador.SeleccionarFigura(null);
            }

            glControlWindow?.Invalidate();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;
            this.KeyDown += (s, ev) => { camaraController.HandleKeyDown(ev.KeyCode); glControlWindow?.Invalidate(); };
            this.KeyUp += (s, ev) => { camaraController.HandleKeyUp(ev.KeyCode); };
            glControlWindow?.Focus();
        }
    }
}
