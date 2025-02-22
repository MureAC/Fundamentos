using System;

namespace GestionEntrenamientos
{
    public class InterfazUsuario
    {
        private GestorUsuario gestorUsuarios = new GestorUsuario();

        public void MenuPrincipal()
        {
            int opcion = 0;
            while (opcion != 3)
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Registrar usuario");
                Console.WriteLine("2. Iniciar sesión");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Error: Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarUsuario();
                        break;
                    case 2:
                        IniciarSesion();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }
        }

        private void RegistrarUsuario()
        {
            Console.Write("Ingrese su correo: ");
            string? correo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(correo))
            {
                Console.WriteLine("Error: No se ingresó un correo válido.");
                return;
            }

            Console.Write("Ingrese su contraseña: ");
            string? contraseña = ContraseñaOculta();

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("Error: No se ingresó una contraseña válida.");
                return;
            }

            bool registrado = gestorUsuarios.RegistrarUsuario(correo, contraseña);
            Console.WriteLine(registrado ? "\nUsuario registrado con éxito." : "\nError: Correo ya registrado.");
        }

        private void IniciarSesion()
        {
            Console.Write("Ingrese su correo: ");
            string? correo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(correo))
            {
                Console.WriteLine("Error: No se ingresó un correo válido.");
                return;
            }

            Console.Write("Ingrese su contraseña: ");
            string? contraseña = ContraseñaOculta();

            if (gestorUsuarios.IniciarSesion(correo, contraseña))
            {
                Console.WriteLine("\nInicio de sesión exitoso.");
                MenuUsuario();
            }
            else
            {
                Console.WriteLine("\nError: Correo o contraseña incorrectos.");
            }
        }

        private void MenuUsuario()
        {
            if (gestorUsuarios.UsuarioActual == null)
            {
                Console.WriteLine("No hay usuario en sesión.");
                return;
            }

            int opcion = 0;
            while (opcion != 4)
            {
                Console.WriteLine("\n--- Menú de Usuario ---");
                Console.WriteLine("1. Registrar entrenamiento");
                Console.WriteLine("2. Listar entrenamientos");
                Console.WriteLine("3. Vaciar entrenamientos");
                Console.WriteLine("4. Cerrar sesión");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Error: Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarEntrenamiento();
                        break;
                    case 2:
                        ListarEntrenamientos();
                        break;
                    case 3:
                        VaciarEntrenamientos();
                        break;
                    case 4:
                        gestorUsuarios.CerrarSesion();
                        Console.WriteLine("Sesión cerrada.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        private void RegistrarEntrenamiento()
        {
            Console.Write("Ingrese la distancia recorrida (km): ");
            if (!double.TryParse(Console.ReadLine(), out double distancia) || distancia <= 0)
            {
                Console.WriteLine("Error: Ingrese un valor válido para la distancia.");
                return;
            }

            Console.Write("Ingrese el tiempo empleado (minutos): ");
            if (!double.TryParse(Console.ReadLine(), out double tiempo) || tiempo <= 0)
            {
                Console.WriteLine("Error: Ingrese un valor válido para el tiempo.");
                return;
            }

            gestorUsuarios.UsuarioActual?.AgregarEntrenamiento(distancia, tiempo);
            Console.WriteLine("Entrenamiento registrado con éxito.");
        }

        private void ListarEntrenamientos()
        {
            if (gestorUsuarios.UsuarioActual == null)
            {
                Console.WriteLine("Error: No hay usuario en sesión.");
                return;
            }

            gestorUsuarios.UsuarioActual.MostrarEntrenamientos();
        }

        private void VaciarEntrenamientos()
        {
            if (gestorUsuarios.UsuarioActual == null)
            {
                Console.WriteLine("Error: No hay usuario en sesión.");
                return;
            }

            gestorUsuarios.UsuarioActual.VaciarEntrenamientos();
            Console.WriteLine("Todos los entrenamientos han sido eliminados.");
        }

        private string ContraseñaOculta()
        {
            string contraseña = "";
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Backspace && contraseña.Length > 0)
                {
                    contraseña = contraseña.Substring(0, contraseña.Length - 1);
                    Console.Write("\b \b");
                }
                else if (tecla.Key != ConsoleKey.Enter)
                {
                    contraseña += tecla.KeyChar;
                    Console.Write("*");
                }
            } while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return contraseña;
        }
    }
}