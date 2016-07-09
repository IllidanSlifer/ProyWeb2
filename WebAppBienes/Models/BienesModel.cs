using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppBienes.Models
{
    public class BienesModel
    {
        public int ID { get; set; }
        public string FolioReal { get; set; }
        public double AreaTerreno { get; set; }
        public string Ubicacion { get; set; }
        public double Precio { get; set; }
        public string Financiamiento { get; set; }
        public string FrenteTerreno { get; set; }
        public string FondoTerreno { get; set; }
        public string TopografiaTerreno { get; set; }
        public string UsoSuelo { get; set; }
        public string Descripcion { get; set; }
        public double AreaConstrucción { get; set; }
        public string Image { get; set; }

    }
}