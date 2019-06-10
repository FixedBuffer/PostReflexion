using System;

namespace PostReflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            var claseBase = new BaseClass() ;
            Console.WriteLine(claseBase.EsVehiculoLargo());
            //.....
            Console.Read();
        }
    }
}
