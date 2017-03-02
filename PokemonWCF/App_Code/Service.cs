using PokemonBusinessLayer;
using PokemonTournamentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public List<PokemonComposite> GetAllPokemons()
    {
        List<PokemonComposite> allPokemons = new List<PokemonComposite>();
        foreach (Pokemon p in BusinessManager.Instance.GetAllPokemons())
        {
            allPokemons.Add(new PokemonComposite(p));
        }
        return allPokemons;
    }

    public List<StadeComposite> GetAllStades()
    {
        List<StadeComposite> allStades = new List<StadeComposite>();
        foreach (Stade s in BusinessManager.Instance.GetAllStades())
        {
            allStades.Add(new StadeComposite(s));
        }
        return allStades;
    }

    public List<MatchComposite> GetAllMatches()
    {
        List<MatchComposite> allMatches = new List<MatchComposite>();
        foreach (Match m in BusinessManager.Instance.GetAllMatchs())
        {
            allMatches.Add(new MatchComposite(m));
        }
        return allMatches;
    }

    public List<TournoiComposite> GetAllTournois()
    {
        List<TournoiComposite> allTournois = new List<TournoiComposite>();
        foreach (Tournoi t in BusinessManager.Instance.GetAllTournois())
        {
            allTournois.Add(new TournoiComposite(t));
        }
        return allTournois;
    }

    public bool AddNewPokemon(PokemonComposite pokemon)
    {
        if (pokemon.Nom != null && pokemon.Caracteristique != null)
        {
            Pokemon p = new Pokemon();
            p.Nom = pokemon.Nom;
            p.Type = pokemon.Type;

            Caracteristique c = new Caracteristique();
            c.PV = pokemon.Caracteristique.PV;
            c.Attaque = pokemon.Caracteristique.Attaque;
            c.Defense = pokemon.Caracteristique.Defense;
            c.Vitesse = pokemon.Caracteristique.Vitesse;
            c.Esquive = pokemon.Caracteristique.Esquive;

            p.Caracteristiques = c;
            return BusinessManager.Instance.AddPokemon(p);
        }
        return false;
    }
}