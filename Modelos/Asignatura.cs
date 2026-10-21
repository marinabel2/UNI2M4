using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2EF2M4.Modelos
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty ;
        public int Creditos { get; set; }
        public ICollection<EstudianteAsignatura> Inscripciones { get; set; }
       = new List<EstudianteAsignatura>();
    }
}
