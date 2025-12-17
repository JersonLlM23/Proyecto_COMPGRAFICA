using System.Collections.Generic;
using System.Linq;
using PROYECTO_U2_CCLl.Modelo;

namespace PROYECTO_U2_CCLl.Controlador
{
    // Por ahora actúa como gestor de escena; luego podemos usar OpenTK.
    public class RenderizadorOpenGL
    {
        private readonly List<Figura3D> _figuras = new List<Figura3D>();
        private Figura3D _seleccionada;

        public void AgregarFigura(Figura3D figura)
        {
            _figuras.Add(figura);
        }

        public List<Figura3D> ObtenerFiguras() => _figuras.ToList();

        public void SeleccionarFigura(Figura3D figura)
        {
            _seleccionada = figura;
        }

        public Figura3D FiguraSeleccionada() => _seleccionada;

        public bool EliminarFigura(Figura3D figura)
        {
            if (figura == null) return false;

            int removed = _figuras.RemoveAll(f => ReferenceEquals(f, figura));
            if (ReferenceEquals(_seleccionada, figura))
            {
                _seleccionada = null;
            }
            return removed > 0;
        }

        public void Limpiar()
        {
            _figuras.Clear();
            _seleccionada = null;
        }
    }
}

