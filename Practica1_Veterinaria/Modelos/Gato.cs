


namespace Practica1_Veterinaria.Modelos
{
    public class Gato : Mascota
    {
        public string Raza {get; set;}
        public bool Esterilizado {get; set;}

        public Gato(string nombre, double peso, SexoMascota sexo, int edad, string propietario, string raza, bool esterilizado) 
        : base(nombre, peso, sexo, edad, propietario)
        {
            Raza = raza;
            Esterilizado = esterilizado;
        }

        public override string Especie => "Gato";

        protected override double FactorAjusteDosis => 0.9;

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Raza: {Raza} | Esterilizado: {(Esterilizado? "Si" : "No")}");
        }
    }
}