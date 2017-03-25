using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public enum EPhaseTournoi
    {
        SeiziemeFinale, HuitimeFinale, QuartFinale, DemiFinale, Finale
    }

    public class Tournoi : EntityObject
    {
        [Required]
        public string Nom { get; set; }
        public Pokemon Vainqueur { get; set; }
        public List<Match> Matches { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public List<Stade> Stades { get; set; }

        public Tournoi()
        {
            Matches = new List<Match>();
            Pokemons = new List<Pokemon>();
            Stades = new List<Stade>();
        }

        public Tournoi(string nom)
        {
            Nom = nom;
            Matches = new List<Match>();
            Pokemons = new List<Pokemon>();
            Stades = new List<Stade>();
        }

        public Tournoi(ServiceReference1.TournoiComposite t)
        {
            Nom = t.Nom;
            Vainqueur = new Pokemon(t.Vainqueur);
            Matches = t.Matches.Select(m => new Match(m)).ToList();
            Pokemons = t.Pokemons.Select(p => new Pokemon(p)).ToList();
            Stades = t.Stades.Select(s => new Stade(s)).ToList();
        }
    }
}