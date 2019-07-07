using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace PostReflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            //===============Ejemplos sobre Assembly=================
            //=======================================================
            EjemploInformacionEnsamblado();
            EjemploClaseDinamica();

            //===============Ejemplos sobre Constructores============
            //=======================================================
            EjemploConstructores();

            //===============Ejemplos con extensiones================
            //=======================================================
            EjemploExtensionesClasesHijas();

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
                                                , false
                                                , BindingFlags.ExactBinding
                                                , null
                                                , new object[] { 2 } /*Argumentos del constructor*/
                                                , null
                                                , null);

            // Creamos una referencia al método   
            var m = objetoDinamico.GetType().GetMethod("Multiplicar");

            //Llamamos al método pasandole el objeto creado dinámicamente y los argumentos dentro de un object[]
            var ret = m.Invoke(objetoDinamico, new object[] { 3 });
            Console.WriteLine($"El retorno de la función es: {ret}");
            Console.WriteLine();
        }

        //===============Ejemplos sobre Module=================
        //=======================================================
        static void EjemploConstructores()
        {
            Console.WriteLine($"Constuctores");
            var className = "PostReflexion.ClaseEjemplo";
            var assembly = Assembly.GetAssembly(typeof(Program));
            var constructors = assembly.GetType(className).GetConstructors();

            //Obtenemos los constructores
            var constructorConParametros = assembly.GetType(className).GetConstructor(new[] { typeof(int) }); //Contructor con parametro int
            var constructorSinParametros = assembly.GetType(className).GetConstructor(Type.EmptyTypes); //Constructor genérico

            //Creamos el objeto de manera dinámica
            var objetoDinamicoConParametros = constructorConParametros.Invoke(new object[] { 2 });
            var objetoDinamicoSinParametros = constructorSinParametros.Invoke(new object[] { });

            // Creamos una referencia al método   
            var m = assembly.GetType(className).GetMethod("Multiplicar");

            //Llamamos al método pasandole el objeto creado dinámicamente y los argumentos dentro de un object[]
            var retConstructorParamatrizado = m.Invoke(objetoDinamicoConParametros, new object[] { 3 });
            var retConstructorGenerico = m.Invoke(objetoDinamicoSinParametros, new object[] { 3 });
            Console.WriteLine($"El retorno de la función con constructor parametrizado es: {retConstructorParamatrizado}");
            Console.WriteLine($"El retorno de la función con constructor genérico es: {retConstructorGenerico}");
            Console.WriteLine();
        }


        //===============Ejemplos con extensiones================
        //=======================================================
        static void EjemploExtensionesClasesHijas()
        {
            Console.WriteLine($"Acceso a la propiedad mediante extensiones");
            var claseHija = new Camion();
            claseHija.EsVehiculoLargo = false;
            var claseBase = (BaseClass)claseHija;
            Console.WriteLine($"Comprobación de una clase que SI tiene la propiedad {claseBase.EsVehiculoLargo()}");
            Console.WriteLine($"Comprobación de una clase que NO tiene la propiedad {new BaseClass().EsVehiculoLargo()}");
            Console.WriteLine();
        }
    }
}
