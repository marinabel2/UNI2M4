using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2EF2M4.Modelos
{
    public class Carrera
    {
        public int IdCarrera { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdArea { get; set; } //FK
        public AreaConocimiento Area { get; set; } = null;

        public ICollection<Estudiante> Estudiante { get; set; }
        = new List<Estudiante>();
    }
}
