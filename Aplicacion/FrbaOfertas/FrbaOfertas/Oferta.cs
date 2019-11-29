using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Oferta
    {
        public String codigo,descripcion,cuit;
        public Decimal precio, precioFicticio,cant,disponible, cantxCli;
        public DateTime fechaPub, fechaVen;


        public Oferta(String cod_, Decimal precio_,Decimal precioFic_,DateTime fechaPub_, DateTime fechaVen_,Decimal cant_,String des_,Decimal disp_,String cuit_, Decimal cantixCli_)
        {
            codigo = cod_;
            precio = precio_;
            precioFicticio = precioFic_;
            fechaPub = fechaPub_;
            fechaVen = fechaVen_;
            cant = cant_;
            descripcion = des_;
            disponible = disp_;
            cuit = cuit_;
            cantxCli = cantixCli_;

        }
    }
}
