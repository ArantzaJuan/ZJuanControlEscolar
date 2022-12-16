using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;


namespace SL_API.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: api/Materia
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/Get")]
        
        public IHttpActionResult Get()
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = BL.Materia.Getall();

            if (result.Correct)
            {

                materia.Materias = result.Objects;
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET: api/Materia/5
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetById/{idMateria}")]
       
        public IHttpActionResult GetById(int idMateria)
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = BL.Materia.GetById(idMateria);
            if (result.Correct)
            {


                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST: api/Materia
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Post")]
        
        public IHttpActionResult Post([FromBody] ML.Materia materia)
        {

            ML.Result result = BL.Materia.Add(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


        // PUT: api/Materia/5
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Materia/Put/{idMateria}")]
    
        public IHttpActionResult Put(int idMateria, [FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE: api/Materia/5
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Materia/Delete/{idMateria}")]
        
        public IHttpActionResult Delete(int idMateria)
        {
            ML.Result result = BL.Materia.Delete(idMateria);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}