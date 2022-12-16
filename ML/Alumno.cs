using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ML
{
    public  class Alumno
    {
        public int IdAlumno { get; set; }
        
        public string Nombre { get; set; }
       
        public string ApellidoPaterno { get; set; }
       
        public string ApellidoMaterno { get; set; }
        public List<object> Alumnos { get; set; }

    }

    internal class RequiredAttribute : Attribute
    {
    }
}
