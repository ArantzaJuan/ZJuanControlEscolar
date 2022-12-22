using System.Linq;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = new ML.Result();
            try
            {


                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                    var responseTask = client.GetAsync("api/Materia/Get");
                    //result = bl.Usuario.GetAll();

                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        result.Objects = new List<object>();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            if (result.Correct)
            {

                materia.Materias = result.Objects;
                return View(materia);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error, no se pueden mostar los registro ";
                return View();
            }

        }


        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (idMateria == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                try
                {

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                        var responseTask = client.GetAsync("api/Materia/GetById/" + idMateria);

                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Materia resultItemList = new ML.Materia();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;
                            result.Correct = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                }
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;


                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar al usuario seleccionado";
                }
                return View(materia);
            }
        }



        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            if (materia.idMateria == 0)
            {
               
                // result = BL.Materia.Add(materia);
                    try
                    {

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                            //HTTP POST
                            var postTask = client.PostAsJsonAsync<ML.Materia>("api/Materia/Post", materia);
                            postTask.Wait();

                            var resultSer = postTask.Result;
                            if (resultSer.IsSuccessStatusCode)
                            {
                                return RedirectToAction("GetAll");
                            }
                        }

                        return View("GetAll");
                    }

                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }
            }
            else
            {
                 //update
                try
                {

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIUrl"]);

                            //HTTP POST
                            var postTask = client.PutAsJsonAsync<ML.Materia>("api/Materia/Put/" + materia.idMateria, materia);
                            postTask.Wait();

                            var resultSer = postTask.Result;
                            if (resultSer.IsSuccessStatusCode)
                            {
                                return RedirectToAction("GetAll");
                            }
                        }

                        return View("GetAll");
                }
                catch (Exception ex)
                 {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                }

            }

            
            return PartialView("Modal");
        }

            [HttpGet]
        public ActionResult Delete(int idMatreria)
        {
            ML.Result result = new ML.Result();
            result = BL.Materia.Delete(idMatreria);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino el registro";
            }
            return PartialView("Modal");
        }
    }
}