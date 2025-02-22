using System;
using System.Collections.Generic;

namespace GestionEntrenamientos
{
    public class Usuario
    {
        public string Correo { get; private set; }
        private string Contraseña;
        public List<Entrenamiento> Entrenamientos { get; private set; }

        public Usuario(string correo, string contraseña)
        {
            Correo = correo;
            Contraseña = contraseña;
            Entrenamientos = new List<Entrenamiento>();
        }

        public bool ValidarContraseña(string contraseña)
        {
            return this.Contraseña == contraseña;
        }

        public void AgregarEntrenamiento(double distancia, double tiempo)
        {
            Entrenamientos.Add(new Entrenamiento(distancia, tiempo));
        }

        public void MostrarEntrenamientos()
        {
            if (Entrenamientos.Count == 0)
            {
                Console.WriteLine("No hay entrenamientos registrados.");
                return;
            }

            Console.WriteLine("\n--- Lista de entrenamientos ---");
            foreach (var entrenamiento in Entrenamientos)
            {
                entrenamiento.MostrarInfo();
            }
        }
        
        public void VaciarEntrenamientos()
        {
            Entrenamientos.Clear();
            Console.WriteLine("Todos los entrenamientos han sido eliminados.");
        }
    }
}
