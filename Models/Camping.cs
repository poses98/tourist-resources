using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoTravel.Models
{
    public class Camping
    {
        [Key]
        public int CampingId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public int NumeroPlazas { get; set; }
        public int NumeroBungalows { get; set; }
        public bool HayPiscina { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}