using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Caracteristique :EntityObject
    {
        [Required]
        public int PV { get; set; }
        [Required]
        public int Attaque { get; set; }
        [Required]
        public int Defense { get; set; }
        [Required]
        public int Vitesse { get; set; }
        [Required]
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