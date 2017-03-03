using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Caracteristique :EntityObject
    {
        public int PV { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }
        public int Esquive { get; set; }

        public Caracteristique()
        {

        }

        public Caracteristique(ServiceReference1.CaracterisiqueComposite c)
        {
            ID = c.Id;
            PV = c.PV;
            Attaque = c.Attaque;
            Defense = c.Defense;
            Vitesse = c.Vitesse;
            Esquive = c.Esquive;
        }
    }
}