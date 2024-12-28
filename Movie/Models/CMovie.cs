using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class CMovie
    {
        public int Id { get; set; }
        public string Titulo { get; set; }=string.Empty;
        public string Director { get; set; }=string.Empty;
        public string Genero { get; set; }=string.Empty;
        public DateTime FechaEstreno { get; set; }
    }
}