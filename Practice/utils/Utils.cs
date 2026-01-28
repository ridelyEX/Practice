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

        /// <summary>
        /// Searches for a persona in the specified list whose name matches the given value, using a case-insensitive
        /// comparison.
        /// </summary>
        /// <param name="list">The list of personas to search. Cannot be null.</param>
        /// <param name="name">The name to search for. The comparison is case-insensitive.</param>
        /// <returns>A Persona object whose name matches the specified value, or null if no match is found.</returns>
        public static Persona? Search(List<Persona> list, string name)
        {
            return list.FirstOrDefault(p => string.Equals(p.Nombre, name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns a list of personas who are 18 years of age or older from the specified collection.
        /// </summary>
        /// <param name="list">The list of personas to filter. Cannot be null.</param>
        /// <returns>A list containing all personas from the input list whose age is 18 or greater. Returns an empty list if no
        /// personas meet the criteria.</returns>
        public static List<Persona> GetMayores(List<Persona> list)
        {
            return list
                .Where(p => p.Edad >= 18)
                .ToList();
        }

        /// <summary>
        /// Determines whether the specified list contains at least one person who is 18 years of age or older.
        /// </summary>
        /// <param name="list">The list of <see cref="Persona"/> objects to examine. Cannot be null.</param>
        /// <returns>true if the list contains at least one person whose age is 18 or older; otherwise, false.</returns>
        public static bool HayMayores(List<Persona> list)
        {
            return list.Any(p => p.Edad >= 18);
        }

        /// <summary>
        /// Determines whether the specified list contains any Persona objects.
        /// </summary>
        /// <param name="list">The list of Persona objects to check. Cannot be null.</param>
        /// <returns>true if the list contains at least one Persona object; otherwise, false.</returns>
        public static bool HayPersona(List<Persona> list)
        {
            return list.Any();
        }
         
        /// <summary>
        /// Retrieves a list of names from the specified collection of Persona objects.
        /// </summary>
        /// <param name="list">The list of Persona objects from which to extract names. Cannot be null.</param>
        /// <returns>A list of strings containing the names of each Persona in the input list. The list will be empty if the
        /// input list contains no elements.</returns>
        public static List<string> GetNombres(List<Persona> list)
        {
            return list.Select(p => p.Nombre).ToList();
        }

        /// <summary>
        /// Returns a list of tuples containing the name and age of each person in the input list who is 18 years of age
        /// or older.
        /// </summary>
        /// <remarks>This method does not modify the input list. The returned list contains only persons
        /// considered adults based on an age threshold of 18.</remarks>
        /// <param name="list">The list of <see cref="Persona"/> objects to filter. Cannot be null.</param>
        /// <returns>A list of tuples where each tuple contains the name and age of a person who is at least 18 years old.
        /// Returns an empty list if no such persons are found.</returns>
        public static List<(string Nombre, int Edad)> GetNombresMayores(List<Persona> list)
        {
            return list
                .Where(p => p.Edad >= 18)
                .Select(p => (p.Nombre, p.Edad))
                .ToList();
        }

        /// <summary>
        /// Calculates the average age of all personas in the specified list.
        /// </summary>
        /// <param name="list">The list of personas whose ages will be averaged. Cannot be null.</param>
        /// <returns>The average age of the personas in the list. Returns 0 if the list is null or contains no elements.</returns>
        public static double AverageAge(List<Persona> list)
        {
            if (list == null || !list.Any())
                return 0;

            return list.Any()
                ? list.Average(p => p.Edad) : 0;
        }

        /// <summary>
        /// Returns the number of elements in the specified list of Persona objects.
        /// </summary>
        /// <param name="list">The list of Persona objects to count. Cannot be null.</param>
        /// <returns>The number of Persona objects contained in the list.</returns>
        public static int CountPeople(List<Persona> list)
        {
            return list.Count();
        }

        /// <summary>
        /// Counts the number of people in the specified list who are considered adults (age 18 or older).
        /// </summary>
        /// <param name="list">The list of Persona objects to evaluate. Cannot be null.</param>
        /// <returns>The number of people in the list whose age is 18 or greater.</returns>
        public static int CountElderPeople(List<Persona> list)
        {
            return list.Count(p => p.Edad >= 18);
        }

        /// <summary>
        /// Returns the maximum age value from the specified list of Persona objects.
        /// </summary>
        /// <param name="list">The list of Persona objects from which to determine the maximum age. Cannot be null.</param>
        /// <returns>The highest value of the Edad property among the Persona objects in the list. Returns 0 if the list is
        /// empty.</returns>
        public static int MaxAge(List<Persona> list)
        {
            return list.Any()
                ? list.Max(p => p.Edad) : 0;
        }

        public static List<Persona> OrderByAge(List<Persona> list)
        {
            return list.OrderBy(p => p.Edad).ToList();
        }

        public static List<Persona> OrderByAgeReverse(List<Persona> list)
        {
            return list.OrderByDescending(p => p.Edad).ToList();
        }

        public static List<Persona> OrderByAgeAndName(List<Persona> list)
        {
            if (list.Count == 0 || !list.Any())
                return new List<Persona>();
            return list.OrderBy(p => p.Edad).ThenBy(p => p.Nombre).ToList();
        }

        public static List<string> GetNames(List<Persona> list)
        {
            if (list == null || !list.Any())
                return new List<string>();    
            return list.Select(p => p.Nombre).ToList();
        }

        public static List<string> GetElderNames(List<Persona> list)
        {
            if (list == null || !list.Any())
                return new List<string>();
            
            return list
                .Where(p => p.Edad >= 18)
                .Select(p => p.Nombre)
                .ToList();
        }

        public static int DoubleTotalAge(List<Persona> list)
        {
            if (list == null || !list.Any())
                return 0;
            return list.Sum(p => p.Edad) * 2;
        }
    }
}
