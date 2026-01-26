using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.persona
{
    internal class Persona
    {

        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Persona()
        {
        }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
    }
}
