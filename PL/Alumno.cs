using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void GetAll()
        {
            ML.Result result = BL.Alumno.AlumnoGetAll();

            if (result.Correct == true)
            {
                foreach (ML.Alumno alumno in result.Objects)
                {

                    Console.WriteLine("**********************");
                    Console.WriteLine("Id de alumno:" + alumno.IdAlumno);
                    Console.WriteLine("nombre de alumno:" + alumno.Nombre);
                    Console.WriteLine("Apellido paterno de alumno:" + alumno.ApellidoPaterno);
                    Console.WriteLine("Apellido materno de alumno:" + alumno.ApellidoMaterno);
                    Console.WriteLine("**********************");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Los usuarios no se pudieron mostrar" + result.ErrorMessage);
                Console.ReadKey();
            }
        }
        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id del alumno que desea consultar:");
            int IdAlumno = int.Parse(Console.ReadLine());
            ML.Result result = BL.Alumno.AlumnoGetAll();

            if (result.Correct == true)
            {
                ML.Alumno alumno = new ML.Alumno();
                    Console.WriteLine("**********************");
                    Console.WriteLine("Id de alumno:" + alumno.IdAlumno);
                    Console.WriteLine("nombre de alumno:" + alumno.Nombre);
                    Console.WriteLine("Apellido paterno de alumno:" + alumno.ApellidoPaterno);
                    Console.WriteLine("Apellido materno de alumno:" + alumno.ApellidoMaterno);
                    Console.WriteLine("**********************");
                    Console.ReadKey();
                
            }
            else
            {
                Console.WriteLine("Los usuarios no se pudieron mostrar" + result.ErrorMessage);
                Console.ReadKey();
            }
        }
        public static void Add()
        {
                ML.Alumno alumno = new ML.Alumno();
                Console.WriteLine("Inserte el nombre del Alumno");
                alumno.Nombre = Console.ReadLine();
                Console.WriteLine("Inserte el apellido paterno del alumno");
                alumno.ApellidoPaterno = Console.ReadLine();
                Console.WriteLine("Inserte el apellido materno del alumno");
                alumno.ApellidoMaterno = Console.ReadLine();
                Console.ReadKey();
            ML.Result result = BL.Alumno.AlumnoAdd(alumno);
            if (result.Correct == true)
            {
                Console.WriteLine("El alumno se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El alumno no se registro" + result.ErrorMessage);
                Console.ReadKey();
            }
        }
        public static void UpDate()
        {
            ML.Alumno alumno = new ML.Alumno();
            int deleteid;

            Console.WriteLine("Inserte el Id del alumno que desea Actualizar");
            deleteid = int.Parse(Console.ReadLine());
            alumno.IdAlumno = deleteid;

            Console.WriteLine("Inserte el nombre del Alumno");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Inserte el apellido paterno del alumno");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Inserte el apellido materno del alumno");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.ReadKey();
            ML.Result result = BL.Alumno.AlumnoUpDate(alumno);
            if (result.Correct == true)
            {
                Console.WriteLine("El alumno se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El alumno no se registro" + result.ErrorMessage);
                Console.ReadKey();
            }
        }
        public static void Delete()
        {
            ML.Alumno alumno = new ML.Alumno();
            int deleteid;

            Console.WriteLine("Inserte el Id del alumno que desea Eliminar");
            deleteid = int.Parse(Console.ReadLine());
            alumno.IdAlumno = deleteid;

            
            ML.Result result = new ML.Result();
                //result = BL.Alumno.AlumnoDelete(int IdAlumno);
            if (result.Correct == true)
            {
                Console.WriteLine("El alumno se registro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El alumno no se registro" + result.ErrorMessage);
                Console.ReadKey();
            }
        }
    }
}
