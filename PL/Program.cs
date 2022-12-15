using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc;
            Console.WriteLine("********************************");
            Console.WriteLine("**  1)   Ver alumnos          **");
            Console.WriteLine("**  2)   ver un alumno        **");
            Console.WriteLine("**  3)   agregar un alumno    **");
            Console.WriteLine("**  4)   actualizar un alumno **");
            Console.WriteLine("**  5)   borrar un alumno     **");
            Console.WriteLine("********************************");
            Console.WriteLine("\n Ingrese el numero de la tabla que desea consultar ");

            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Alumno.GetAll();
                    break;
                case 2:
                    Alumno.GetById();
                    break;
                case 3:
                    Alumno.Add();
                    break;
                case 4:
                    Alumno.UpDate();
                    break;
                case 5:
                    Alumno.Delete();
                    break;
            }
        }
    }
}
