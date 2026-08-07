
using Practica1_Veterinaria.Servicios;

namespace Practica1_Veterinaria
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("============================================");
            Console.WriteLine("    BIENVENIDO AL SISTEMA DE VETERIANRIA    ");
            Console.WriteLine("    Práctica 1 -IPC2 - FIUSAC               ");
            Console.WriteLine("============================================");

            var veterinaria = new Veterianria();
            var menu = new MenuConsola(veterinaria);

            menu.Iniciar();
        }
    }
}
