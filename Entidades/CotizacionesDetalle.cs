using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CotizacionesDetalle
    {
        [Key]
        public int CotizacionesDetalleId { get; set; }
        public int CotizacionesId { get; set; }
        public int ArticulosId { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("ArticulosId")]
        public virtual Articulos Articulo { get; set; }

        public decimal Monto { get; set; }

        public CotizacionesDetalle()
        {
            this.CotizacionesDetalleId = 0;
            this.CotizacionesId = 0;
            this.Monto = 0;
            this.Cantidad = 0;
        }

        public CotizacionesDetalle(int id, int cotizacionesId, int articulosId, decimal monto, int cantidad)
        {
            this.CotizacionesDetalleId = id;
            this.CotizacionesId = cotizacionesId;
            this.ArticulosId = articulosId;
            this.Monto = monto;
            this.Cantidad = cantidad;
        }
    }
}
