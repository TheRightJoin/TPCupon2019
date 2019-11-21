using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    class Usuario
    {
        public String User { get; set; }
        public String Password { get; set; }
        public Decimal DNI { get; set; }
        public String CUIT { get; set; }

        public Usuario(String User_, String Password_, Decimal DNI_, String CUIT_)
        {
            User = User_;
            Password = Password_;
            DNI = DNI_;
            CUIT = CUIT_;
        }
    }
}
