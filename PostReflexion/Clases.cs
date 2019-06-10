using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
}
