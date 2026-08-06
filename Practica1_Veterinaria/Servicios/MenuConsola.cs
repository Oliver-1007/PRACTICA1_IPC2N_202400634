
using Practica1_Veterinaria.Modelos;

namespace Practica1_Veterinaria.Servicios
{
    public class MenuConsola
    {
         private readonly Veterianria _veterinaria;

         public MenuConsola(Veterianria veterianria)
        {
            _veterinaria = veterianria;
        }

        public void Iniciar()
        {
            bool salir = false;

            while(!salir)
            {
                MostrarMenuPrincipal();
                int opcion = LeerEntero("Seleccione una opcion: ", 1, 4);

                switch (opcion)
                {
                    case 1:
                        RegistrarMascota();
                        break;
                    case 2:
                        GestionarPacientes();
                        break;
                    case 3:
                        ListarPacientes();
                        break;
                    case 4:
                        salir = true;
                        Console.WriteLine("\nGracias por usar el sistema de la veterinaria!");
                        break;
                }
            }
        }

        // MENU PRINCIPAL ------------------------------------------------------------------------
        public void MostrarMenuPrincipal()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("     SISTEMA DE VETERINARIA - MENÚ       ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Registrar nueva mascota.");
            Console.WriteLine("2. Gestionar pacientes registrados");
            Console.WriteLine("3. Listar todos los pacientes");
            Console.WriteLine("4. Salir");
        }

        // REGISTRO DE MASCOTAS ------------------------------------------------------------------
        public void RegistrarMascota()
        {
            Console.WriteLine("\n=========================== ");
            Console.WriteLine("     REGISTRAR MASCOTA       ");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Perro");
            Console.WriteLine("2. Gato");
            Console.WriteLine("3 Ave");
            Console.WriteLine("4. Tortuga");
            int tipo = LeerEntero("Opcion: ", 1, 4);
        }

        // FUNCION LEER ENTERO -----------------------------------------------------------------
        public int LeerEntero(string mensaje, int min, int max)
        {
            int valor;
            while(true)
            {
                Console.WriteLine(mensaje);
                string entrada = Console.ReadLine();

                if(int.TryParse(entrada, out valor) && valor >= min && valor <= max)
                {
                    return valor;
                }

                Console.WriteLine($"Entrada inválida. Ingrese un numero entre {min} y {max}");
            }
        }
    }
}