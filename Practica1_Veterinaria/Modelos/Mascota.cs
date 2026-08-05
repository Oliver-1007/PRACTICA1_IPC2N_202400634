

namespace Practica1_Veterinaria.Modelos
{
    public enum EstadoPaciente
    {
        Sano,
        Enfermo
    }

    public enum SexoMascota
    {
        Macho,
        Hembra
    }

    public abstract class Mascota
    {
        public string Nombre {get; set;}
        public double Peso {get; set;}
        public SexoMascota Sexo {get; set;}
        public int Edad {get; set;}
        public string Propietario {get; set;}
        public string Codigo {get; private set;}
        public EstadoPaciente Estado {get; private set;}

        // constructor
        public Mascota(string nombre, double peso, SexoMascota sexo, int edad, string propietario)
        {
            Nombre = nombre;
            Peso = peso;
            Sexo = sexo;
            Edad = edad;
            Propietario = propietario;
            Codigo = GenerarCodigo();
            Estado = EstadoPaciente.Sano;
        }

        protected abstract double FactorAjusteDosis {get;}

        public abstract string Especie {get; }

        private string GenerarCodigo()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();
            char[] c = new char[8];
            for(int i = 0; i < 8;i++)
            {
                c[i] = chars[r.Next(chars.Length)];
            }
            return new string(c);
        }

        public virtual double CalcularDosis(double dosis_por_kg)
        {
            double dosisBase = Peso * dosis_por_kg;
            return dosisBase * FactorAjusteDosis;
        }


        public void CambiarEstado(EstadoPaciente nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("============================================");
            Console.WriteLine($"[{Codigo}] {Nombre} | {Sexo} | {Edad} años");
            Console.WriteLine($"Peso: {Peso} kg | Propietario: {Propietario}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}