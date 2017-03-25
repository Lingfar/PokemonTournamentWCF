using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Nom { get; set; }
        [Required]
        public ETypeElement Type { get; set; }
        [Required]
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