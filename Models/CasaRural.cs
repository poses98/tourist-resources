using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoTravel.Models
{
    public class CasaRural
    {
        [Key]
        public int CasaRuralID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int NumeroPersonas { get; set; }
        public int NumeroHabitaciones { get; set; }
        public string ActividadesRuralesCerca { get; set; }
        public bool HayPiscina { get; set; }
        public string Descripcion { get; set; }
        public bool HayParking { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}