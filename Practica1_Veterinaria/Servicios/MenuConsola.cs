
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
            Console.WriteLine("\n=========================================");
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
            Console.WriteLine("\n=============================");
            Console.WriteLine("     REGISTRAR MASCOTA       ");
            Console.WriteLine("=============================");
            Console.WriteLine("1. Perro");
            Console.WriteLine("2. Gato");
            Console.WriteLine("3. Ave");
            Console.WriteLine("4. Tortuga");
            int tipo = LeerEntero("Opcion: ", 1, 4);

            Console.WriteLine();
            string nombre = LeerTexto("Nombre de la mascota: ");
            double peso = LeerDecimal("Peso (kg): ");
            SexoMascota sexo = LeerSexo();
            int edad = LeerEntero("Edad (años): ", 0, 100);
            string propietario = LeerTexto("Nombre del propietario: ");

            Mascota nuevaMascota = null!;

            switch (tipo)
            {
                case 1:
                    string raza = LeerTexto("Raza: ");
                    string tamaño = LeerTexto("Tamaño (Pequeño/Mediano/Grande): ");
                    nuevaMascota = new Perro(nombre, peso, sexo, edad, propietario, raza, tamaño);
                    break;
                case 2:
                    string razaGato = LeerTexto("Raza: ");
                    bool esterilizado = LeerSiNo("¿Está esterilizado? (S/N): ");
                    nuevaMascota = new Gato(nombre, peso, sexo, edad, propietario, razaGato, esterilizado);
                    break;
                case 3:
                    double envergadura = LeerDecimal("Envergadura de las alas (cm): ");
                    bool puedeVolar = LeerSiNo("¿Puede volar? (S/N): ");
                    nuevaMascota = new Ave(nombre, peso, sexo, edad, propietario, envergadura, puedeVolar);
                    break;
                case 4:
                    string tipoCaparazon = LeerTexto("Tipo de caparazón: ");
                    bool esAcuatica = LeerSiNo("¿Puede nadar? (S/N): ");
                    nuevaMascota = new Tortuga(nombre, peso, sexo, edad, propietario, tipoCaparazon, esAcuatica);
                    break;
            }

            _veterinaria.RegistrarMascota(nuevaMascota!);

            Console.WriteLine("\n Mascota registrada exitosamente. ");
            Console.WriteLine($"  Codigo asignado: {nuevaMascota!.Codigo}");
        }

        // REGISTRO DE PACIENTES ---------------------------------------------------------------
        private void GestionarPacientes()
        {
            if(!_veterinaria.HayPacientes())
            {
                Console.WriteLine("\nNo hay pacientes registrados todavia");
                return;
            }

            Console.WriteLine();
            string codigo = LeerTexto("Ingrese el codigo del paciente (8 caracteres):");
            Mascota mascota = _veterinaria.BuscarPorCodigo(codigo)!;

            if(mascota == null)
            {
                Console.WriteLine("Nooo se encontro ningun paciente con ese codigo.");
                return;
            }

            bool volver = false;
            while(!volver)
            {
                Console.WriteLine("\n===========================================");
                Console.WriteLine($"--   Gestionando a {mascota.Nombre} ({mascota.Codigo})   --");
                Console.WriteLine($"1. Consultar informacion. ");
                Console.WriteLine($"2. Cambiar estado del paciente. ");
                Console.WriteLine($"3. Calcular dosis del medicamenteo. ");
                Console.WriteLine($"4. Devolver mascota (eliminar del sistmea) ");
                Console.WriteLine($"5. Volver al menu principal ");
                
                int opcion = LeerEntero("Seleccion una opcion : ", 1, 5);
                switch(opcion)
                {
                    case 1:
                        Console.WriteLine();
                        mascota.MostrarInformacion();
                        break;
                    case 2:
                        CambiarEstadoPaciente(mascota);
                        break;
                    case 3:
                        CalcularDosisPaciente(mascota);
                        break;
                    case 4:
                        _veterinaria.EliminarMascota(mascota.Codigo);
                        Console.WriteLine("\n La mascota fue devuelta y eliminada del sistema exitosamente!");
                        volver = true;
                        break;
                    case 5:
                        volver = true;
                        break;

                }
            }
        }

        // FUNCION CMBIAR ESTADO DEL PACIENTE -------------------------------------------------
        public void CambiarEstadoPaciente(Mascota mascota)
        {
            Console.WriteLine("\nEstado actual: " + mascota.Estado);
            Console.WriteLine("1. Sano. ");
            Console.WriteLine("2. Enfermo. ");
            int opcion = LeerEntero("Nuevo estado: ", 1,2);

            EstadoPaciente nuevoEstado = opcion == 1 ? EstadoPaciente.Sano : EstadoPaciente.Enfermo;
            mascota.CambiarEstado(nuevoEstado);

            Console.WriteLine($" Estado actualizado a: {mascota.Estado}");
        }

        // FUNCION PARA CALCULAR DOSIS ---------------------------------------------------------
        public void CalcularDosisPaciente(Mascota mascota)
        {
            double dosisPorKg = LeerDecimal("Dosis estándar del medicamento (mg/kg): ");
            double dosisTotal = mascota.CalcularDosis(dosisPorKg);

            Console.WriteLine($"\nDosis calculada para {mascota.Nombre} ({mascota.Especie}): ");
            Console.WriteLine($"  {dosisTotal:F2} mg");
        }

        // FUNCION DE LISTAR PACIENTES ---------------------------------------------------------
        public void ListarPacientes()
        {
            if(!_veterinaria.HayPacientes())
            {
                Console.WriteLine("\nNo hay pacientes registrados todavia.");
                return;
            }

            Console.WriteLine($"\n        --- Pacientes registrados ({_veterinaria.TotalPacientes()}) --- ");
            foreach(var mascota in _veterinaria.ObtenerTodos())
            {
                mascota.MostrarInformacion();
            }
        }

        // FUNCION LEER ENTERO -----------------------------------------------------------------
        public int LeerEntero(string mensaje, int min, int max)
        {
            int valor;
            while(true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()!;

                if(int.TryParse(entrada, out valor) && valor >= min && valor <= max)
                {
                    return valor;
                }

                Console.WriteLine($"Entrada inválida. Ingrese un numero entre {min} y {max}");
            }
        }

        // FUNCION LEER TEXTO ------------------------------------------------------------------
        public string LeerTexto(string mensaje)
        {
            string valor;
            while(true)
            {
                Console.Write(mensaje);
                valor = Console.ReadLine()!;

                if(!string.IsNullOrWhiteSpace(valor))
                {
                    return valor.Trim();
                }

                Console.WriteLine("Este campo no puede estar vacío.");
            }
        }

        // FUNCION LEER DECIMALES ----------------------------------------------------------------
        public double LeerDecimal(string mensaje)
        {
            double valor;
            while(true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()!;

                if(double.TryParse(entrada, out valor) && valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine("Entrada inválida. Ingrese un numero mayor o igual a 0.");
            }
        }

        // FUNCION DEFINIR SEXO
        public SexoMascota LeerSexo()
        {
            while(true)
            {
                Console.Write("Sexo (M = Macho / H = Hembra): ");
                string entrada = Console.ReadLine()?.Trim().ToUpper()!;

                if (entrada == "M") return SexoMascota.Macho;
                if (entrada == "H") return SexoMascota.Hembra;

                Console.WriteLine("Entrada inválida. Escribe 'M' o 'H'");
            }
        }

        // FUNCION BOLEANA LEER SINO
        private bool LeerSiNo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine()?.Trim().ToUpper()!;

                if (entrada == "S") return true;
                if (entrada == "N") return false;

                Console.WriteLine("Entrada inválida. Escriba 'S' o 'N'.");
            }
        }
    }
}