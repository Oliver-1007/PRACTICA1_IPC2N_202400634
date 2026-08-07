


namespace Practica1_Veterinaria.Modelos
{
    public class Ave : Mascota
    {
        public double EnvergaduraAlas {get; set; }
        public bool PuedeVolar {get; set;}

        //constructor
        public Ave(string nombre, double peso, SexoMascota sexo, int edad, string propietario, double envergaduraAlas, bool puedeVolar)
        : base(nombre, peso, sexo, edad, propietario)
        {
            EnvergaduraAlas = envergaduraAlas;
            PuedeVolar = puedeVolar;
        }

        public override string Especie => "Ave";

        protected override double FactorAjusteDosis => 0.5;

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Envergadura de las alas: {EnvergaduraAlas} cm | Puede volar: {(PuedeVolar? "Si" : "No")}");
        }
    }
}