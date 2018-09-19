using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace Entidades.Tests
{
    [TestClass()]
    public class CotizacionesTests
    {
        [TestMethod]
        public void Guardar()
        {
            CotizacionesRepositorio cotizacionesRepositorio = new CotizacionesRepositorio();
            Assert.IsTrue(cotizacionesRepositorio.Guardar(Cotizacion()));
        }

        [TestMethod]
        public void Modificar()
        {
            CotizacionesRepositorio cotizacionesRepositorio = new CotizacionesRepositorio();
            Assert.IsTrue(cotizacionesRepositorio.Modificar(Cotizacion()));
        }

        [TestMethod]
        public void Eliminar()
        {
            CotizacionesRepositorio cotizacionesRepositorio = new CotizacionesRepositorio();
            Assert.IsTrue(cotizacionesRepositorio.Eliminar(1));
        }

        private Cotizaciones Cotizacion()
        {
            Cotizaciones c = new Cotizaciones
            {
                Descripcion = "Cotizacion",
                CotizacionesId = 0,
                Fecha = DateTime.Now,
                Monto = 9999
            };

            AgregarDetalle(1,1,9999,4);

            return c;
        }

        private void AgregarDetalle(int cotizacionesId, int articulosId, decimal monto, int cantidad)
        {
            Cotizaciones c = new Cotizaciones();
            c.Detalle.Add(new CotizacionesDetalle(
                0,
                cotizacionesId,
                articulosId,
                monto,
                cantidad
                ));
        }

        private void AgregarDetalle(int id, int cotizacionesId, int articulosId, decimal monto, int cantidad)
        {
            Cotizaciones c = new Cotizaciones();
            c.Detalle.Add(new CotizacionesDetalle(
                id,
                cotizacionesId,
                articulosId,
                monto,
                cantidad
                ));
        }
    }
}