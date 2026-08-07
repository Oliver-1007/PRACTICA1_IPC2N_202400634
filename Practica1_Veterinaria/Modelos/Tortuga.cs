


namespace Practica1_Veterinaria.Modelos
{
    public class Tortuga : Mascota
    {
        public string TipoCaparazon {get; set;}
        public bool EsAcuatica {get; set;}

        //constructor
        public Tortuga(string nombre, double peso, SexoMascota sexo, int edad, string propietario, string tipoCaparazon, bool esAcuatica)
        : base(nombre, peso, sexo, edad, propietario)
        {
            TipoCaparazon = tipoCaparazon;
            EsAcuatica = esAcuatica;
        }

        public override string Especie => "Ave";

        protected override double FactorAjusteDosis => 0.8;

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo de caparazon: {TipoCaparazon} | Es acuatica: {(EsAcuatica? "Si" : "NO")}");
        }
    }
}