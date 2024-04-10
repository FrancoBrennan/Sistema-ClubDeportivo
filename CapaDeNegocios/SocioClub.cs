using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    public class SocioClub : Socio
    {
        private float cuotaSocial;
        private static int ActMax;
        private static int PorcDesc;

        public SocioClub(int dni, string nombre, DateTime fechaNac, DateTime fechaIng, int id, string email, string direccion, float cuotaSocial) : base(dni,nombre,fechaNac,fechaIng,id,email,direccion)
        {
            this.cuotaSocial = cuotaSocial;
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
    }
}
