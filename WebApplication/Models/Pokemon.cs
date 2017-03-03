using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.ServiceReference1;

namespace WebApplication.Models
{
    public enum ETypeElement
    {
        Eau, Feu, Sol, Insecte, Plante, Dragon
    }

    public class Pokemon : EntityObject
    {
        public string Nom { get; set; }
        public ETypeElement Type { get; set; }
        public Caracteristique Caracteristiques { get; set; }

        public Pokemon()
        {
            Caracteristiques = new Caracteristique();
        }

        public Pokemon(int id) : base(id)
        {
            Caracteristiques = new Caracteristique();
        }

        public Pokemon(PokemonComposite p)
        {
            ID = p.Id;
            Nom = p.Nom;
            Type = (ETypeElement)p.Type;
            Caracteristiques = new Caracteristique(p.Caracteristique);
        }
    }
}