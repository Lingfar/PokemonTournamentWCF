using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.ServiceReference1;

namespace WebApplication.Models
{
    public class Stade : EntityObject
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public ETypeElement Type { get; set; }

        private int nbPlaces;
        [Required]
        public int NbPlaces
        {
            get { return nbPlaces; }
            set
            {
                if (value < 0)
                    nbPlaces = 0;
                else
                    nbPlaces = value;
            }
        }

        private int attaque;
        [Required]
        public int Attaque
        {
            get { return attaque; }
            set
            {
                if (value > 5)
                    attaque = 5;
                else if (value <= 0)
                    attaque = 1;
                else
                    attaque = value;
            }
        }

        private int defense;
        [Required]
        public int Defense
        {
            get { return defense; }
            set
            {
                if (value > 5)
                    defense = 5;
                else if (value <= 0)
                    defense = 1;
                else
                    defense = value;
            }
        }

        public Stade()
        {

        }

        public Stade(int id) : base(id)
        {

        }

        public Stade(StadeComposite s)
        {
            ID = s.Id;
            Nom = s.Nom;
            Type = (ETypeElement)s.Type;
            NbPlaces = s.NbPlaces;
            Attaque = s.Attaque;
            Defense = s.Defense;
        }
    }
}