using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            //Se hace el acceso al servidor ServiceProducto
            AlumnoReference.AlumnoClient context = new AlumnoReference.AlumnoClient();
            var result = context.GetAll();
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

        // GET: AlumnoMateria/Details/5
        public ActionResult GetAlumno(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
        
            
            ML.Result result = BL.AlumnoMateria.AlumnoMateriaGetById(IdAlumno);
            
            AlumnoReference.AlumnoClient context = new AlumnoReference.AlumnoClient();
            var resultalu = context.GetById(IdAlumno);
            if (result.Correct)
            {
                alumnoMateria.AlumnoMaterias = result.Objects.ToList();
                alumnoMateria.Alumno = new ML.Alumno();
                alumnoMateria.Alumno = (ML.Alumno)resultalu.Object;
                
                return View(alumnoMateria);

            }
            else
            {
                ViewBag.Mensaje = "No se pueden mostrar los alumnos";
                return View(alumnoMateria);
            }
            
        }

        public ActionResult AsignarMateria(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Result result = BL.AlumnoMateria.AlumnoMaterianoAsignadas(IdAlumno);
            AlumnoReference.AlumnoClient context = new AlumnoReference.AlumnoClient();
            var resultalu = context.GetById(IdAlumno);

            if (result.Correct)
            {
                alumnoMateria.Materia=new ML.Materia();
                alumnoMateria.AlumnoMaterias = result.Objects;
                alumnoMateria.Alumno = new ML.Alumno();
                alumnoMateria.Alumno = (ML.Alumno)resultalu.Object;

               
            }
            else
            {
                ViewBag.Mensaje = "No se pueden mostrar los alumnos";
               
            }
            return View(alumnoMateria);
        }
        // GET: AlumnoMateria/Create
        public ActionResult Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = BL.AlumnoMateria.AlumnoMateriaAdd(alumnoMateria);

            if (result.Correct)
            {
                alumnoMateria = (ML.AlumnoMateria)result.Object;
                ViewBag.Mensaje = "Materia guardado exitosamente";

            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al agregar al usuario";
            }
            return View();
        }

        // POST: AlumnoMateria/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoMateria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlumnoMateria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoMateria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlumnoMateria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
