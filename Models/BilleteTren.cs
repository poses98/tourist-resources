using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoTravel.Models
{
    public enum CompaniaTransporte
    {
        Renfe,
        Ouigo,
        Iryo
    }
    public enum TipoTren
    {
        AVE,
        Avant,
        Alvia
    }
    public class BilleteTren
    {
        [Key]
        public int IdBilleteTren { get; set; }
        public CompaniaTransporte Compania { get; set; }
        public TipoTren TipoTren { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public bool HayCafeteria { get; set; }
        public int NumeroPlazas { get; set; }
        public string Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}