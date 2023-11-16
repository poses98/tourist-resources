using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EcoTravel.Models
{ 

    public enum TipoRecurso
{
    Avion,
    Tren,
    Alquiler_Coche,
    Hotel,
    Camping,
    Casa_Rural
    

}

    public class Incidencia
    {
        [Key]
        public string id { get; set; }
        public TipoRecurso tipo_Recurso { get; set; }
        public string nombre_Compania { get; set; }
        public string descripcion { get; set; }
        public int grevedad { get; set; }
        public string opinion { get; set; }
        
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}