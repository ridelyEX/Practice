using Practice.persona;
using Practice.utils;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Persona> _persona = new List<Persona>();
        int opc = 0;
        bool _continue = true;

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
                    Console.Clear();
                    string _name = Utils.Name();
                    int _age = Utils.Age();
                    Persona? p1 = null;

                    if (_name != null && _age != 0)
                    {
                        p1 = new Persona(_name, _age); 
                        _persona.Add(p1);
                        Console.WriteLine("Persona registrada");
                    }
                    else
                    {
                        Console.Write("No se puede registrar a la persona, vuelva a intentarlo");
                    }

                        break;
                case 2:
                    Console.Clear();
                    foreach (Persona p in _persona)
                    {
                        Console.WriteLine($"Nombre {p.Nombre}, Edad: {p.Edad}");
                    }
                    break;
                case 3:
                    int index = Utils.SearchPersona(_persona, Utils.Name());

                    if (index != -1)
                    {
                        Console.WriteLine($"Persona encontrada: {_persona[index].Nombre}");
                        int newAge = Utils.Age();
                        Utils.ModifyAge(_persona, index, newAge);

                        Console.WriteLine($"Edad modificada: {_persona[index].Edad}");
                    }
                    else
                    {
                        Console.WriteLine("Persona no encontrada");
                    }

                    break;
                case 4:
                    _continue = false;
                    break;
                default:
                    break;
            }
        } while (_continue == true);
    }
}