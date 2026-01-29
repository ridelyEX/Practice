using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.persona
{
    internal class Persona
    {
        public string Nombre { get; private set; }
        public int Edad { get; private set; }

        public enum GrupoEdad
        {
            Menor,
            Adulto,
            Mayor
        }

        public Persona()
        {
        }

        public Persona(string nombre, int edad)
        {
            SetName(nombre);
            ModifyAge(edad);
        }

        public void ModifyAge(int newAge)
        {
            if (newAge < 0)
                throw new ArgumentException("Edad inválida");

            Edad = newAge;
        }

        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no debe estar vacío");

            Nombre = name;
        }

        public GrupoEdad GetGrupoEdad
        {
            get 
            {
                if (Edad < 18 && Edad > 0) return GrupoEdad.Menor;
                if (Edad >= 18 && Edad < 60) return GrupoEdad.Adulto;
                return GrupoEdad.Mayor;
            }
        }
    }
}
