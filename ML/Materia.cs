using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int idMateria { get; set; }
        //[Required]
        //[DisplayName("Nombre:")]
        public string nombre { get; set; }
        //[Required]
        //[DisplayName("Costo:")]
        public byte costo { get; set; }
        public List <object> Materias { get; set; }

    }
}
