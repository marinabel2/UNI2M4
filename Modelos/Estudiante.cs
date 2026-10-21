using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2EF2M4.Modelos
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Carnet { get; set; } = string.Empty;
        public string Nombres {  get; set; } = string.Empty;
        public string Apellidos {  get; set; } = string.Empty;
        public int IdCarrera { get; set; }//fk
        public Carrera Carrera { get; set; } = null;
        public ICollection<EstudianteAsignatura> Inscripciones { get; set; }
        = new List<EstudianteAsignatura>();
    }
}
