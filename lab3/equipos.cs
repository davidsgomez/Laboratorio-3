using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class equipos
    {
        public int? id { get; set; }
        public string equipo { get; set; }
        public int puntos { get; set; }
        public int? jugadores { get; set; }
        public string? representante { get; set; }
    }

}
