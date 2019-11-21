using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
   public class VerProveedor
    {
        public string razon_social { get; set; }
        public string email { get; set; }
        public decimal telefono { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string CUIT { get; set; }
        public string rubro { get; set; }
        public string contacto { get; set; }
        public string postal { get; set; }
        public int activo { get; set; }

        public VerProveedor(string a, string b, decimal c, string d, string e, string f, string g,
                                         string h, string i, string j, string k, string m)
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
