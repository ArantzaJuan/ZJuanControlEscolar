using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    var query = contex.MateriaAdd(materia.nombre, materia.costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    var query = contex.MateriaUpDate(materia.nombre, materia.costo, materia.idMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    var query = contex.MateriaDElete(IdMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingreso el registro";
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
        public static ML.Result Getall()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    
                    var mateias = contex.MateriaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (mateias != null)
                    {
                        foreach (var obj in mateias)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.idMateria = obj.idMateria;
                            materia.nombre = obj.nombre;
                            materia.costo = byte.Parse(obj.costo.ToString());
                            result.Objects.Add(materia);
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
        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanControlEscolarEntities contex = new DL.ZJuanControlEscolarEntities())
                {
                    ML.Materia materia = new ML.Materia();
                    var mateias = contex.MateriaGetById(idMateria).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (mateias != null)
                    {

                            materia.idMateria = mateias.idMateria;
                            materia.nombre = mateias.nombre;
                            materia.costo = byte.Parse(mateias.costo.ToString());
                        result.Object = materia;
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
    }
}
