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
    public PokemonComposite GetPokemonById(int id)
    {
        return new PokemonComposite(BusinessManager.Instance.GetPokemonById(id));
    }
    public bool AddNewPokemon(PokemonComposite pokemon)
    {
        if (pokemon.Nom != null && pokemon.Caracteristique != null)
        {
            return BusinessManager.Instance.AddPokemon(PokemonCompositeToPokemon(pokemon));
        }
        return false;
    }
    public bool UpdatePokemon(PokemonComposite pokemon)
    {
        return BusinessManager.Instance.UpdatePokemon(PokemonCompositeToPokemon(pokemon));
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
    public StadeComposite GetStadeById(int id)
    {
        return new StadeComposite(BusinessManager.Instance.GetStadeById(id));
    }
    public bool AddNewStade(StadeComposite stade)
    {
        return BusinessManager.Instance.AddStade(StadeCompositeToStade(stade));
    }
    public bool UpdateStade(StadeComposite stade)
    {
        return BusinessManager.Instance.UpdateStade(StadeCompositeToStade(stade));
    }
    public bool DeleteStadeById(int id)
    {
        return BusinessManager.Instance.DeleteStade(StadeCompositeToStade(GetStadeById(id)));
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
    public MatchComposite GetMatchById(int id)
    {
        return new MatchComposite(BusinessManager.Instance.GetMatchById(id));
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
    public TournoiComposite GetTournoiById(int id)
    {
        return new TournoiComposite(BusinessManager.Instance.GetTournoiById(id));
    }
    public bool NewTournoi(string name)
    {
        return BusinessManager.Instance.NewTournoi(name);
    }
    public bool DeleteTournoiById(int id)
    {
        return BusinessManager.Instance.DeleteTournoi(TournoiCompositeToTournoi(GetTournoiById(id)));
    }

    private Pokemon PokemonCompositeToPokemon(PokemonComposite pokemon)
    {
        Pokemon p = new Pokemon(pokemon.Id);
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
    private Stade StadeCompositeToStade(StadeComposite s)
    {
        Stade stade = new Stade(s.Id);
        stade.Nom = s.Nom;
        stade.Type = s.Type;
        stade.NbPlaces = s.NbPlaces;
        stade.Attaque = s.Attaque;
        stade.Defense = s.Defense;
        return stade;
    }
    private Match MatchCompositeToMatch(MatchComposite m)
    {
        Match match = new Match();
        match.ID = m.Id;
        match.IdPokemonVainqueur = m.IdPokemonVainqueur;
        match.PhaseTournoi = m.PhaseTournoi;
        match.Pokemon1 = PokemonCompositeToPokemon(m.Pokemon1);
        match.Pokemon2 = PokemonCompositeToPokemon(m.Pokemon2);
        match.Stade = StadeCompositeToStade(m.Stade);
        return match;
    }
    private Tournoi TournoiCompositeToTournoi(TournoiComposite t)
    {
        Tournoi tournoi = new Tournoi();
        tournoi.ID = t.Id;
        tournoi.Nom = t.Nom;
        tournoi.Pokemons = t.Pokemons.Select(p => PokemonCompositeToPokemon(p)).ToList();
        tournoi.Stades = t.Stades.Select(s => StadeCompositeToStade(s)).ToList();
        tournoi.Matches = t.Matches.Select(m => MatchCompositeToMatch(m)).ToList();
        return tournoi;
    }
}