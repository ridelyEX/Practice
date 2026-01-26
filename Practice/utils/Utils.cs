using Practice.persona;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

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

        /// <summary>
        /// Searches for a persona in the specified list by name and returns the zero-based index of the first match.
        /// </summary>
        /// <param name="list">The list of personas to search. Cannot be null.</param>
        /// <param name="name">The name of the persona to search for. The comparison is case-insensitive. Can be null.</param>
        /// <returns>The zero-based index of the first persona whose name matches the specified name; otherwise, -1 if no match
        /// is found.</returns>
        public static int SearchPersona(List<Persona> list, string? name) 
        {
            int index = list.FindIndex(p => string.Equals(p.Nombre, name, StringComparison.OrdinalIgnoreCase));

                return index;
        }

        /// <summary>
        /// Modifies the age of the persona at the specified index in the provided list.
        /// </summary>
        /// <param name="list">The list of Persona objects to update. Cannot be null.</param>
        /// <param name="index">The zero-based index of the persona whose age will be modified. Must be within the bounds of the list.</param>
        /// <param name="newAge">The new age value to assign to the persona at the specified index.</param>
        public static void ModifyAge(List<Persona> list, int index, int newAge)
        {
            if (index >= 0 && index < list.Count())
            {
                list[index].Edad = newAge;
            }
        }


        /// <summary>
        /// Searches for a person by name in the specified list and updates their age if found. Unused method
        /// </summary>
        /// <remarks>If a person with the specified name is not found in the list, no changes are made.
        /// The method prompts the user for input via the console.</remarks>
        /// <param name="list">The list of Persona objects to search and update. Cannot be null.</param>
        public static void ModifyAgeComplete(List<Persona> list)
        {
            int NewAge;

            Console.WriteLine("Ingrese el nombre a buscar");
            string? NewName = Read();

            bool found = false;
            foreach (Persona p in list)
            {
                if (string.Equals(p.Nombre, NewName, StringComparison.OrdinalIgnoreCase))
                {
                    NewAge = Age();
                    p.Edad = NewAge;
                    Console.WriteLine($"{p.Nombre} fue encontrado y asignado con la edad {p.Edad}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Nombre no encontrado");
            }
        }
            
    }
}
