using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            //Se hace el acceso al servidor ServiceProducto
            AlumnoReference1.AlumnoClient context = new AlumnoReference1.AlumnoClient();
            
            var result = context.GetAll();
            
            //ML.Result result = new ML.Result();
            //result = BL.Alumno.AlumnoGetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Mensaje = "No se pueden mostrar los alumnos";
            }
            return View(alumno);
        }

        public ActionResult Form (int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            
            if(alumno == null)
            {
                return View(alumno);
            }
            else
            {

                
                //Se hace el acceso al servidor ServiceProducto
                AlumnoReference1.AlumnoClient context = new AlumnoReference1.AlumnoClient();

                var  result = context.GetById(IdAlumno.Value);
                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                }
                else
                {
                    ViewBag.Mensaje = "No se pueden mostrar los alumnos";
                }
                return View(alumno);

            }
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            

            if (alumno.IdAlumno == 0)
            {
                AlumnoReference1.AlumnoClient context = new AlumnoReference1.AlumnoClient();

                var result = context.Add(alumno);
                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    ViewBag.Mensaje = "Usuario guardado exitosamente";

                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al agregar al usuario";
                }
            }
            else
            {
                //update

                AlumnoReference1.AlumnoClient context = new AlumnoReference1.AlumnoClient();
               var result = context.UpDate(alumno);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    ViewBag.Mensaje = "Usuario Actualizado Correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error El usuario no se pudo actualizar";
                }

            }

            return PartialView("Modal");

        }
        [HttpGet]
        public ActionResult Delete(int IdAlumno)
        {
            AlumnoReference1.AlumnoClient context = new AlumnoReference1.AlumnoClient();
            var result = context.Delete(IdAlumno);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino el registro";
            }
            return PartialView("Modal");
        }

    }
}