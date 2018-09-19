using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Cotizaciones
    {
        [Key]
        public int CotizacionesId { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public virtual List<CotizacionesDetalle> Detalle { get; set; }

        public Cotizaciones(int cotizacionesId, string descripcion, DateTime fecha, double monto, List<CotizacionesDetalle> detalle)
        {
            this.CotizacionesId = cotizacionesId;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.Monto = monto;
            this.Detalle = detalle;
        }

        public Cotizaciones()
        {
            CotizacionesId = 0;
            Descripcion = "";
            Fecha = DateTime.Now;
            Monto = 0;
            Detalle = new List<CotizacionesDetalle>();
        }
    }
}
