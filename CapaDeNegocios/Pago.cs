using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
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


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaPaga
        {
            get { return fechaPaga; }
            set { fechaPaga = value; }
        }


        public Socio Socio
        {
            get { return socio; }
            set { socio = value; }
        }

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }



        public override string ToString()
        {
            return id + "-" + montoTotal + "-" + fechaPaga + "-" + socio.Nombre;
        }
    }
}
