using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public class Cliente
    {
        public Decimal dni{get;set;}
        public Decimal activo{get;set;}
        public Decimal telefono{get;set;}
        public String nombre {get;set;}
        public String apellido{get;set;}
        public String mail{get;set;}
        public String direccion{get;set;}
        public String localidad { get; set; }
        public String ciudad{get;set;}
        public String codPostal{ get; set; }
        public DateTime fechaNac { get; set; }

        public Cliente(Decimal dni_, String nombre_, String apellido_, String mail_, String direccion_, String ciudad_, DateTime fechaNac_, Decimal telefono_,String codPostal_,String localidad_)
        {
            dni = dni_;
            nombre = nombre_;
            apellido = apellido_;
            mail = mail_;
            direccion = direccion_;
            ciudad = ciudad_;
            fechaNac = fechaNac_;
            telefono = telefono_;
            codPostal = codPostal_;
            localidad = localidad_;
        }
    }
}
