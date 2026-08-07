


namespace Practica1_Veterinaria.Modelos
{
    public class Perro : Mascota
    {
        public string Raza {get; set;}
        public string Tamaño {get; set;}

        public Perro(string nombre, double peso, SexoMascota sexo, int edad, string propietario, string raza, string tamaño) 
                        : base(nombre, peso, sexo, edad, propietario)
        {
            Raza = raza;
            Tamaño = tamaño;
        }

        public override string Especie => "Perro";
        protected override double FactorAjusteDosis => 1.0;

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Raza: {Raza} | Tamaño: {Tamaño}");
        }
    }
}