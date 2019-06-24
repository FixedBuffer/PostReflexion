using System;

namespace PostReflexion
{
    public class BaseClass
    {
        public string ModeloMotor { get; set; }
    }

    public class Coche : BaseClass
    {
        public bool Descapotable { get; set; }
    }

    public class Moto : BaseClass
    {
        public bool Motor2Tiempos { get; set; }
    }

    public class Camion : BaseClass
    {
        public bool EsVehiculoLargo { get; set; }
    }

    public class ClaseEjemplo
    {
        private int _valor;
        public ClaseEjemplo(int valor)
        {
            _valor = valor;
        }
        public int Multiplicar(int por)
        {
            Console.WriteLine($"Llamada a {nameof(Multiplicar)} con parámetro {por}");
            return _valor * por;
        }
    }
}
