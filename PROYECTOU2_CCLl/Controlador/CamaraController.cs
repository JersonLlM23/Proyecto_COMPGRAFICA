using System.Windows.Forms;
using OpenTK;
using PROYECTO_U2_CCLl.Modelo;

namespace PROYECTO_U2_CCLl.Controlador
{
    public class CamaraController
    {
        private ICamara _camara;
        private bool _arrastrandoIzq;
        private bool _arrastrandoDer;
        private System.Drawing.Point _ultimoMouse;
        private float _velocidadMovimiento = 120f; // unidades por segundo

        // Estados de movimiento para cámara libre
        private bool _moveForward, _moveBack, _moveLeft, _moveRight, _moveUp, _moveDown;

        public CamaraController()
        {
            SetTipoCamara(TipoCamara.Orbital);
        }

        public TipoCamara TipoActual => _camara?.Tipo ?? TipoCamara.Orbital;

        public void SetTipoCamara(TipoCamara tipo)
        {
            switch (tipo)
            {
                case TipoCamara.Libre:
                    _camara = new CamaraLibre();
                    break;
                case TipoCamara.Fija:
                    _camara = new CamaraFija();
                    break;
                case TipoCamara.Orbital:
                default:
                    _camara = new CamaraOrbital();
                    break;
            }
            _camara.Reset();
        }

        public Matrix4 GetViewMatrix()
        {
            return _camara?.GetViewMatrix() ?? Matrix4.Identity;
        }

        public void Reset()
        {
            _camara?.Reset();
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _arrastrandoIzq = true;
                _ultimoMouse = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                _arrastrandoDer = true;
                _ultimoMouse = e.Location;
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) _arrastrandoIzq = false;
            if (e.Button == MouseButtons.Right) _arrastrandoDer = false;
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            int dx = e.X - _ultimoMouse.X;
            int dy = e.Y - _ultimoMouse.Y;
            _ultimoMouse = e.Location;

            if (_arrastrandoIzq)
            {
                if (_camara is CamaraOrbital co)
                {
                    co.YawDeg += dx * 0.5f;
                    co.PitchDeg += dy * 0.5f;
                    if (co.PitchDeg > 89f) co.PitchDeg = 89f;
                    if (co.PitchDeg < -89f) co.PitchDeg = -89f;
                }
                else if (_camara is CamaraLibre cl)
                {
                    cl.YawDeg += dx * 0.3f;
                    cl.PitchDeg += dy * 0.3f;
                    if (cl.PitchDeg > 89f) cl.PitchDeg = 89f;
                    if (cl.PitchDeg < -89f) cl.PitchDeg = -89f;
                }
            }
            if (_arrastrandoDer)
            {
                if (_camara is CamaraLibre cl)
                {
                    cl.YawDeg += dx * 0.3f;
                    cl.PitchDeg += dy * 0.3f;
                    if (cl.PitchDeg > 89f) cl.PitchDeg = 89f;
                    if (cl.PitchDeg < -89f) cl.PitchDeg = -89f;
                }
            }
        }

        public void HandleMouseWheel(MouseEventArgs e)
        {
            float factor = (e.Delta > 0) ? 1.1f : 0.9f;
            if (_camara is CamaraOrbital co)
            {
                co.Distancia *= factor;
                if (co.Distancia < 50f) co.Distancia = 50f;
                if (co.Distancia > 2000f) co.Distancia = 2000f;
            }
            else if (_camara is CamaraLibre cl)
            {
                // acercar/alejar moviendo hacia delante/atrás
                var forward = cl.GetForward();
                cl.Posicion += forward * (_velocidadMovimiento * (e.Delta > 0 ? 1f : -1f));
            }
        }

        public void HandleKeyDown(Keys key)
        {
            // Cámara libre: registrar estado de teclas
            if (_camara is CamaraLibre)
            {
                switch (key)
                {
                    case Keys.W: _moveForward = true; break;
                    case Keys.S: _moveBack = true; break;
                    case Keys.A: _moveLeft = true; break;
                    case Keys.D: _moveRight = true; break;
                    case Keys.Space: _moveUp = true; break;
                    case Keys.ControlKey: _moveDown = true; break;
                }
                return;
            }

            // Cámara fija: flechas para cambiar eje
            if (_camara is CamaraFija cf)
            {
                switch (key)
                {
                    case Keys.Left:
                        cf.Preset = PresetCamaraFija.Lateral; // Eje X
                        break;
                    case Keys.Up:
                        cf.Preset = PresetCamaraFija.Superior; // Eje Y
                        break;
                    case Keys.Right:
                        cf.Preset = PresetCamaraFija.Frontal; // Eje Z
                        break;
                }
            }
        }

        public void HandleKeyUp(Keys key)
        {
            if (_camara is CamaraLibre)
            {
                switch (key)
                {
                    case Keys.W: _moveForward = false; break;
                    case Keys.S: _moveBack = false; break;
                    case Keys.A: _moveLeft = false; break;
                    case Keys.D: _moveRight = false; break;
                    case Keys.Space: _moveUp = false; break;
                    case Keys.ControlKey: _moveDown = false; break;
                }
            }
        }

        public void Update(float dt)
        {
            if (!(_camara is CamaraLibre cl)) return;

            var forward = cl.GetForward();
            var right = cl.GetRight();
            var up = Vector3.UnitY;

            Vector3 delta = Vector3.Zero;
            if (_moveForward) delta += forward;
            if (_moveBack) delta -= forward;
            if (_moveRight) delta += right;
            if (_moveLeft) delta -= right;
            if (_moveUp) delta += up;
            if (_moveDown) delta -= up;

            if (delta.Length > 0)
            {
                delta.Normalize();
                cl.Posicion += delta * _velocidadMovimiento * dt;
            }
        }
    }
}
