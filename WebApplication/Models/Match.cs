using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Match : EntityObject
    {
        [Required]
        public Pokemon PokemonVainqueur { get; set; }
        [Required]
        public string Tournoi { get; set; }
        [Required]
        public EPhaseTournoi PhaseTournoi { get; set; }
        [Required]
        public Pokemon Pokemon1 { get; set; }
        [Required]
        public Pokemon Pokemon2 { get; set; }
        [Required]
        public Stade Stade { get; set; }

        public Match()
        {

        }

        public Match(int id) : base(id)
        {

        }

        public Match(ServiceReference1.MatchComposite m)
        {
            ID = m.Id;
            Tournoi = m.Tournoi;
            PhaseTournoi = (EPhaseTournoi)m.PhaseTournoi;
            Pokemon1 = new Pokemon(m.Pokemon1);
            Pokemon2 = new Pokemon(m.Pokemon2);
            Stade = new Stade(m.Stade);
            if (m.IdPokemonVainqueur == m.Pokemon1.Id)
                PokemonVainqueur = Pokemon1;
            else
                PokemonVainqueur = Pokemon2;
        }
    }
}