using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoTravel.Models
{
    public class BilleteAvion
    {
        [Key]
        public int IdBilleteAvion { get; set; }
        public string CompaniaAerea { get; set; }
        public string AeropuertoOrigen { get; set; }
        public string AeropuertoDestino { get; set; }
        public bool LowCost { get; set; }
        public int NumeroPlazas { get; set; }
        public string Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}