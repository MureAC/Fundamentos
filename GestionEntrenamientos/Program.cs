using System;

namespace GestionEntrenamientos
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfazUsuario interfaz = new InterfazUsuario();
            interfaz.MenuPrincipal();

            Console.WriteLine("\nPresiona Enter para salir...");
            Console.ReadLine();
        }
    }
}
