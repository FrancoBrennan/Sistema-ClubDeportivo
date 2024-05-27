using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public class SocioClub : Socio
    {
        private float cuotaSocial;
        private static int ActMax;
        private static int PorcDesc;
        private SocioClubDatos clubDatos;

        public SocioClub(int dni, string nombre, DateTime fechaNac, string email, string direccion, float cuotaSocial) : base(dni,nombre,fechaNac,email,direccion)
        {
            this.cuotaSocial = cuotaSocial;
            clubDatos = new SocioClubDatos();
        }

        public override bool usaCuota()
        {
            return true;
        }

        public float CuotaSocial
        {
            get { return cuotaSocial; }
            set { cuotaSocial = value; }
        }

        public static void SetPorcDescuento(int p)
        {
            PorcDesc = p;
        }

        public static void SetActividadesMax(int a)
        {
            ActMax = a;
        }

        public static int GetPorcDescuento()
        {
            return PorcDesc;
        }

        public static int GetActividadesMax()
        {
            return ActMax;
        }

        public override float calcularMontoTotal()
        {
            float total = cuotaSocial;

            if (clases.Count > GetActividadesMax() ){

                for (int i = GetActividadesMax(); i < this.clases.Count; i++)
                { 
                    total += this.clases[i].Act.Precio*((float)GetPorcDescuento()/100);
                }

            }

            return total;

        }

        public override void removerDeTodaLaBD()
        {
            //Elimino todas las relaciones en la Tabla SocioClase

            this.ClaseDatos.removerRelacionPorDni(this.Dni);

            //Elimino al Socio de la BD

            this.clubDatos.eliminar(this.Dni);
            
            this.borrarPagosDB();

            foreach (Clase c in this.Clases)
            {
                c.quitarSocio(this);
            }


        }
    }
}
