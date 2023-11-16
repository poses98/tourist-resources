using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoTravel.Models
{
    public class Hotel
    {
        [Key]
        public int HotelID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int NumeroEstrellas { get; set; }
        public bool Rural { get; set; }
        public bool Mascotas { get; set; }
        public bool SoloAdultos { get; set; }
        public bool Tematico { get; set; }
        public string Descripcion { get; set; }
        public bool Parking { get; set; }
        public int NumeroHabitaciones { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}