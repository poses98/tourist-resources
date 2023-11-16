using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EcoTravel.Models
{


    public enum Ofrece_Sillas
    {
        Si,
        No,
        entre_0_18,
        entre_18_30,
    }

    public class AlquilerCoche
    {
        public string id { get; set; }
        public string compañia_Alquiler { get; set; }
        public string direccion_Recogida { get; set; }
        public string tipo_Coche { get; set; }
        public int num_Plazas { get; set; }
        public int num_Coches { get; set; }
        public bool ofrece_Seguro { get; set; }
        public Ofrece_Sillas ofrece_Sillas { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}