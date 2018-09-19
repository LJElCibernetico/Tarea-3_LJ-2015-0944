using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticulosId { get; set; }

        public String Descripcion { get; set; }
        public int Existencia { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public Double Costo { get; set; }
        public Double Precio { get; set; }
        public int UnidadCotizada { get; set; }

        public Articulos(int articulosId, string descripcion, int existencia, DateTime fechaDeVencimiento, double costo, double precio, int unidadCotizada)
        {
            this.ArticulosId = articulosId;
            this.Descripcion = descripcion;
            this.Existencia = existencia;
            this.FechaDeVencimiento = fechaDeVencimiento;
            this.Costo = costo;
            this.Precio = precio;
            this.UnidadCotizada = unidadCotizada;
        }

        public Articulos()
        {
            ArticulosId = 0;
            Descripcion = String.Empty;
            Precio = 0;
            Existencia = 0;
            FechaDeVencimiento = DateTime.Now;
            Costo = 0;
            UnidadCotizada = 0;
        }
    }
}
