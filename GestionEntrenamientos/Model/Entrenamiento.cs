using System;

namespace GestionEntrenamientos
{
    public class Entrenamiento
    {
        public double Distancia { get; private set; }
        public double Tiempo { get; private set; }

        public Entrenamiento(double distancia, double tiempo)
        {
            Distancia = distancia;
            Tiempo = tiempo;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Distancia: {Distancia} km, Tiempo: {Tiempo} min");
        }
    }
}
