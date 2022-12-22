using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result AlumnoMateriaGetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    
                    var alumnoma = contex.AlumnoMateriaGetById(IdAlumno).ToList();
                    result.Objects = new List<object>();
                    if (alumnoma != null)
                    {
                        foreach (var obj in alumnoma)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnoMateria.Alumno  =new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno;
                            alumnoMateria.Alumno.Nombre = obj.NombreAlumno;
                            alumnoMateria.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumnoMateria.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.idMateria = obj.idMateria;
                            alumnoMateria.Materia.nombre = obj.NombreMateria;
                            result.Objects.Add(alumnoMateria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "los usuarios no se pudo mostar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result AlumnoMaterianoAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {

                    var alumnoma = contex.AlumnoMateriaNoAsignada(IdAlumno).ToList();
                    result.Objects = new List<object>();
                    if (alumnoma != null)
                    {
                        foreach (var obj in alumnoma)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();

                            alumnoMateria.Materia.idMateria = obj.idMateria;
                            alumnoMateria.Materia.nombre = obj.nombre;
                            alumnoMateria.Materia.costo =byte.Parse(obj.costo.ToString());

                            
                            result.Objects.Add(alumnoMateria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "los usuarios no se pudo mostar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result AlumnoMateriaAdd(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    DL.AlumnoMateria alumnodl = new DL.AlumnoMateria();

                    alumnodl.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnodl.idMateria = alumnoMateria.Materia.idMateria;
                    contex.AlumnoMaterias.Add(alumnodl);
                    result.Correct = true; 
                }
                   
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
