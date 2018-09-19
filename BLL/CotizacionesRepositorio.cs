using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CotizacionesRepositorio: RepositorioBase<Cotizaciones>
    {
        public override Cotizaciones Buscar(int id)
        {
            Cotizaciones cotizacion = new Cotizaciones();
            try
            {
                cotizacion = _contexto.Cotizaciones.Find(id);

                cotizacion.Detalle.Count();

                foreach (var item in cotizacion.Detalle)            
                {
                    string s = item.Articulo.Descripcion;
                } 

            }
            catch (Exception)
            {

                throw;
            }
            return cotizacion;
        }

        public override bool Guardar(Cotizaciones cotizacion)
        {
            bool paso;
            foreach (var item in cotizacion.Detalle)
            {
                var articulo = _contexto.Articulos.Find(item.ArticulosId);
                item.Articulo.UnidadCotizada += item.Cantidad;
                _contexto.Entry(item.Articulo).State = EntityState.Modified;
            }
            paso = base.Guardar(cotizacion);

            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;

            var cotizacion = Buscar(id);

            foreach(var item in cotizacion.Detalle)
            {
                item.Articulo.UnidadCotizada -= item.Cantidad;
                _contexto.Entry(item.Articulo).State = EntityState.Modified;
            }

            paso = base.Eliminar(id);

            return paso;
        }

        public override bool Modificar(Cotizaciones cotizacion)
        {
            bool paso = false;
            try
            {
                var Anterior = _contexto.Cotizaciones.Find(cotizacion.CotizacionesId);
                foreach (var item in Anterior.Detalle)
                {
                    if (!cotizacion.Detalle.Exists(d => d.CotizacionesDetalleId == item.CotizacionesDetalleId))
                    {
                        item.Articulo = null;
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                
                foreach (var item in cotizacion.Detalle)
                {
                    var estado = item.CotizacionesDetalleId > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }
                
                _contexto.Entry(cotizacion).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        

    }
}
