using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public partial class AltaProveedor
    {
        public String razon_social { get; set; }
        public String email { get; set; }
        public Decimal telefono { get; set; }
        public String direccion { get; set; }
        public String ciudad { get; set; }
        public String CUIT { get; set; }
        public int rubro { get; set; }
        public String contacto { get; set; }
        public String postal { get; set; }
        public int activo { get; set; }

        public AltaProveedor(String a, String b, Decimal c, String d, String e, String f, String g,
                                         String h, String i, int j, String k, String m)
        {
           razon_social = a;
           email = b;
           telefono = c;
           direccion = d + " " + e + " " + f + " " + g;
           ciudad = h;
           CUIT = i;
           rubro = j;
           contacto = k;
           postal = m;
           activo = 1;
        }
    }
}
