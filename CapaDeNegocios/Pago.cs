using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public class Pago
    {
        private int id;
        private DateTime fechaPaga;
        private Socio socio;
        private float montoTotal;

        public Pago(int id, DateTime fechaPaga, Socio socio, float montoTotal)
        {
            this.id = id;
            this.fechaPaga = fechaPaga;
            this.socio = socio;
            this.montoTotal = montoTotal;
        }


    }
}
