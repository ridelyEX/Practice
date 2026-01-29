using Practice.persona;
using System;
using System.Linq;
//using System.Net.NetworkInformation;
//using System.Collections.Generic;
//sing System.Reflection.Metadata.Ecma335;
//using System.Text;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practice.utils
{
    internal class Utils
    {

        public static void Menu()
        {
            Console.WriteLine("1. Registrar persona");
            Console.WriteLine("2. Mostrar personas registradas");
            Console.WriteLine("3. Buscar y modificar persona");
            Console.WriteLine("4. Salir");
        }

        public static string Read()
        {
            string? read;

            do
            {
                read = Console.ReadLine();

                if (string.IsNullOrEmpty(read))
                    Console.WriteLine("Este campo no puede estar vacío");

            } while (string.IsNullOrEmpty(read));

            return read;
        }

        public static string Name()
        {
            string? name;

            do
            {
                Console.WriteLine("Registre nombre");
                name = Read()?.ToUpper().Trim();
            } while (string.IsNullOrEmpty(name));

            return name;
        }

        public static int Age()
        {
            int age;

            do
            {
                Console.WriteLine("Ingrese la edad");
                if (!int.TryParse(Read(), out age) || age < 1)
                {
                    Console.WriteLine("Ingrese un número mayor a 1");
                }

            } while (age < 1);

            return age;
        }

        /*
        public static string SearchName(List<Persona> list, string? name)
        {
            Console.WriteLine("Ingrese el nombre a buscar");

            bool found = false;

            foreach (var persona in list)
            {
                if (string.Equals(persona.Nombre, name, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    Console.WriteLine($"Persona encontrada: {persona.Nombre}, Edad: {persona.Edad}");
                    break;
                }
            }
            if (!found)
                Console.WriteLine("Persona no econtrada");

            return name!;
        }
        */
    }
}
