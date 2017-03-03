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
    public bool AddNewPokemon(PokemonComposite pokemon)
    {
        if (pokemon.Nom != null && pokemon.Caracteristique != null)
        {
            return BusinessManager.Instance.AddPokemon(PokemonCompositeToPokemon(pokemon));
        }
        return false;
    }
    public bool DeletePokemonById(int id)
    {
        return BusinessManager.Instance.DeletePokemon(PokemonCompositeToPokemon(GetPokemonById(id)));
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

    public PokemonComposite GetPokemonById(int id)
    {
        return new PokemonComposite(BusinessManager.Instance.GetAllPokemons().Find(p => p.ID == id));
    }



    private Pokemon PokemonCompositeToPokemon(PokemonComposite pokemon)
    {
        Pokemon p = new Pokemon();
        p.ID = pokemon.Id;
        p.Nom = pokemon.Nom;
        p.Type = pokemon.Type;

        Caracteristique c = new Caracteristique();
        c.ID = pokemon.Caracteristique.Id;
        c.PV = pokemon.Caracteristique.PV;
        c.Attaque = pokemon.Caracteristique.Attaque;
        c.Defense = pokemon.Caracteristique.Defense;
        c.Vitesse = pokemon.Caracteristique.Vitesse;
        c.Esquive = pokemon.Caracteristique.Esquive;

        p.Caracteristiques = c;
        return p;
    }
}