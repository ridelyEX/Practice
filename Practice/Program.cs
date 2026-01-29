using Practice.persona;
using Practice.services;
using Practice.utils;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Persona> _persona = new List<Persona>();
        int opc = 0;
        bool _continue = true;

        //Persona p = new Persona("julian", 0);

        do
        {
            Utils.Menu();
            if (!int.TryParse(Utils.Read(), out opc) || opc < 1 || opc > 3)
            {
                Console.WriteLine("Seleccione una de las opciones");
            }
            switch (opc)
            {
                case 1:
                    Persona? p1 = new Persona(Utils.Name(), Utils.Age());

                    //p.ModifyAge(15);
                    Console.WriteLine($"Grupo {p1.GetGrupoEdad}");
                    break;
                case 10:
                    _continue = false;
                    break;
                default:
                    break;
            }
        } while (_continue == true);
    }
}