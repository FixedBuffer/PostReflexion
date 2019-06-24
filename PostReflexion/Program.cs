using System;
using System.Reflection;

namespace PostReflexion
{
    public interface inter { }
    class Program
    {
        static void Main(string[] args)
        {
            //===============Ejemplos sobre Assembly=================
            //=======================================================
            EjemploInformacionEnsamblado();
            EjemploClaseDinamica();

            //===============Ejemplos con extensiones================
            //=======================================================
            EjemploClasesHijas();

            Console.Read();
        }

        //===============Ejemplos sobre Assembly=================
        //=======================================================
        static void EjemploInformacionEnsamblado()
        {
            Console.WriteLine($"Información del ensamblado");
            //var assembly = Assembly.LoadFile("ruta al fichero");
            var assembly = Assembly.GetAssembly(typeof(Program));

            Console.WriteLine("Nombre completo:");
            Console.WriteLine(assembly.FullName);

            // The AssemblyName type can be used to parse the full name.
            AssemblyName assemName = assembly.GetName();
            Console.WriteLine("\nNombre: {0}", assemName.Name);
            Console.WriteLine("Versión: {0}.{1}",
                assemName.Version.Major, assemName.Version.Minor);

            Console.WriteLine("\nOrigen del código:");
            Console.WriteLine(assembly.CodeBase);
            Console.WriteLine("\nPunto de entrada:");
            Console.WriteLine(assembly.EntryPoint);

            Console.WriteLine();
        }

        static void EjemploClaseDinamica()
        {
            Console.WriteLine($"Clase dinámica");
            //var assembly = Assembly.LoadFile("ruta al fichero");
            var assembly = Assembly.GetAssembly(typeof(Program));

            //Creamos el objeto de manera dinámica
            var objetoDinamico = assembly.CreateInstance("PostReflexion.ClaseEjemplo"
                                                ,false
                                                ,BindingFlags.ExactBinding
                                                ,null
                                                ,new object[] {2 } /*Argumentos del constructor*/
                                                ,null
                                                ,null);

            // Creamos una referencia al método   
            var m = objetoDinamico.GetType().GetMethod("Multiplicar");

            //Llamamos al método pasandole el objeto creado dinámicamente y los argumentos dentro de un object[]
            var ret = m.Invoke(objetoDinamico, new object[] { 3 });
            Console.WriteLine($"El retorno de la función es: {ret}");
            Console.WriteLine();
        }

        //===============Ejemplos con extensiones================
        //=======================================================
        static void EjemploClasesHijas()
        {
            Console.WriteLine($"Acceso a la propiedad mediante extensiones");
            var claseBase = new BaseClass();
            Console.WriteLine(claseBase.EsVehiculoLargo());
            Console.WriteLine();
        }
    }
}
