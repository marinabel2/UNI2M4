using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2EF2M4.Modelos
{
    public class EstudianteAsignatura
    {
        public int IdEstudiante { get; set; }//FK Y PARTE PK
        public Estudiante Estudiante { get; set; } = null;
         
        public int IdAsignatura { get; set; }//FK Y PARTE PK
        public Asignatura Asignatura { get; set; } = null;

        public decimal Nota { get; set; }
        public bool Aprobada { get; set; }
        public DateTime FechaInscripcion {  get; set; } = DateTime.Today;
    }
}
