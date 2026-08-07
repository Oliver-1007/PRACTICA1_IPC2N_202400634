
using Practica1_Veterinaria.Modelos;

namespace Practica1_Veterinaria.Servicios
{
    public class Veterianria
    {
        private readonly List<Mascota> _pacientes = new List<Mascota>();

        // FUNCION DE REGISTRAR MASCOTA --------------------------------------------------
        public void RegistrarMascota(Mascota mascota)
        {
            _pacientes.Add(mascota);   
        }

        // FUNCION PARA MOSTRAR TODOS LOS DATOS  --------------------------------------
        public List<Mascota> ObtenerTodos()
        {
            return _pacientes;
        }
        
        public Mascota? BuscarPorCodigo(string codigo)
        {
            foreach(var lol in _pacientes)
            {
                if( codigo == lol.Codigo)
                {
                    return lol;
                }
            }
            return null;
        }

        // FUNCION PARA ELIMINAR MASCOTA -------------------------------------------------
        public bool EliminarMascota(string codigo)
        {
            var mascota = BuscarPorCodigo(codigo);
            if (mascota == null) return false;
            return _pacientes.Remove(mascota);
        }

        // FUNCION BOLEANA PARA VERIFICAR SI HAY PACIENTES -------------------------------
        public bool HayPacientes()
        {
            return _pacientes.Count > 0;
        }

        // FUNCION PARA LA CANTIDAD DE PACIENTES ------------------------------------------
        public int TotalPacientes()
        {
            return _pacientes.Count;
        }
    }
}