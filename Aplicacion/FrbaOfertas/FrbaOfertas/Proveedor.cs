using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
   public class Proveedor
    {
        public String razon_social { get; set; }
        public String email { get; set; }
        public Decimal telefono { get; set; }
        public String direccion { get; set; }
        public String ciudad { get; set; }
        public String CUIT { get; set; }
        public int idRubro { get; set; }
        public String rubro { get; set; }
        public String contacto { get; set; }
        public String postal { get; set; }
        public int activo { get; set; }

        public Proveedor(String razon_social_, String email_, Decimal telefono_, String direccion_,
                         String ciudad_, String CUIT_, String rubro_, int idRubro_, String contacto_, String postal_)
        {
           razon_social = razon_social_;
           email = email_;
           telefono = telefono_;
           direccion = direccion_;
           ciudad = ciudad_;
           CUIT = CUIT_;
           rubro = rubro_;
           idRubro = idRubro_;
           contacto = contacto_;
           postal = postal_;
           activo = 1;
        }
    }
}
