using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2EF2M4.Modelos
{
    public class AreaConocimiento
    {
        public int IdArea {  get; set; }
        public string Nombre { get; set; }

        // un area puede tener muhcas carreras
        public ICollection<Carrera> Carreras { get; set; }
        = new List<Carrera>();
    }
}
