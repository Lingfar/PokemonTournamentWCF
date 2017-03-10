using PokemonTournamentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    //[OperationContract]
    //string GetData(int value);

    //[OperationContract]
    //CompositeType GetDataUsingDataContract(CompositeType composite);

    // TODO: Add your service operations here
    [OperationContract]
    List<PokemonComposite> GetAllPokemons();
    [OperationContract]
    PokemonComposite GetPokemonById(int id);
    [OperationContract]
    bool AddNewPokemon(PokemonComposite pokemon);
    [OperationContract]
    bool DeletePokemonById(int id);
    [OperationContract]
    bool UpdatePokemon(PokemonComposite pokemon);

    [OperationContract]
    List<StadeComposite> GetAllStades();
    [OperationContract]
    StadeComposite GetStadeById(int id);
    [OperationContract]
    bool AddNewStade(StadeComposite stade);
    [OperationContract]
    bool UpdateStade(StadeComposite stade);
    [OperationContract]
    bool DeleteStadeById(int id);

    [OperationContract]
    List<MatchComposite> GetAllMatches();
    [OperationContract]
    MatchComposite GetMatchById(int id);

    [OperationContract]
    List<TournoiComposite> GetAllTournois();
    [OperationContract]
    TournoiComposite GetTournoiById(int id);

}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
//[DataContract]
//public class CompositeType
//{
//    bool boolValue = true;
//    string stringValue = "Hello ";

//    [DataMember]
//    public bool BoolValue
//    {
//        get { return boolValue; }
//        set { boolValue = value; }
//    }

//    [DataMember]
//    public string StringValue
//    {
//        get { return stringValue; }
//        set { stringValue = value; }
//    }
//}

[DataContract]
public class EntityObjectComposite
{
    int id;
    [DataMember]
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
}

[DataContract]
public class TournoiComposite : EntityObjectComposite
{
    string nom;
    PokemonComposite vainqueur;
    List<PokemonComposite> pokemons;
    List<MatchComposite> matches;
    List<StadeComposite> stades;

    public TournoiComposite(Tournoi tournoi)
    {
        Nom = tournoi.Nom;
        Vainqueur = new PokemonComposite(tournoi.Vainqueur);
        Pokemons = tournoi.Pokemons.Select(p => new PokemonComposite(p)).ToList();
        Matches = tournoi.Matches.Select(m => new MatchComposite(m)).ToList();
        Stades = tournoi.Stades.Select(s => new StadeComposite(s)).ToList();
    }

    [DataMember]
    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

    [DataMember]
    public PokemonComposite Vainqueur
    {
        get { return vainqueur; }
        set { vainqueur = value; }
    }

    [DataMember]
    public List<PokemonComposite> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    [DataMember]
    public List<MatchComposite> Matches
    {
        get { return matches; }
        set { matches = value; }
    }

    [DataMember]
    public List<StadeComposite> Stades
    {
        get { return stades; }
        set { stades = value; }
    }
}

[DataContract]
public class PokemonComposite : EntityObjectComposite
{
    string nom;
    ETypeElement type;
    CaracterisiqueComposite carac;

    public PokemonComposite(Pokemon pokemon)
    {
        Id = pokemon.ID;
        Nom = pokemon.Nom;
        Type = pokemon.Type;
        Caracteristique = new CaracterisiqueComposite(pokemon.Caracteristiques);
    }

    [DataMember]
    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

    [DataMember]
    public ETypeElement Type
    {
        get { return type; }
        set { type = value; }
    }

    [DataMember]
    public CaracterisiqueComposite Caracteristique
    {
        get { return carac; }
        set { carac = value; }
    }
}

[DataContract]
public class MatchComposite : EntityObjectComposite
{
    int idPokemonVainqueur;
    string tournoi;
    EPhaseTournoi phaseTournoi;
    PokemonComposite pokemon1;
    PokemonComposite pokemon2;
    StadeComposite stade;

    public MatchComposite(Match match)
    {
        Id = match.ID;
        IdPokemonVainqueur = match.IdPokemonVainqueur;
        PhaseTournoi = match.PhaseTournoi;
        Pokemon1 = new PokemonComposite(match.Pokemon1);
        Pokemon2 = new PokemonComposite(match.Pokemon2);
        Stade = new StadeComposite(match.Stade);
        Tournoi = match.Tournoi.Nom;
    }

    [DataMember]
    public int IdPokemonVainqueur
    {
        get { return idPokemonVainqueur; }
        set { idPokemonVainqueur = value; }
    }

    [DataMember]
    public string Tournoi
    {
        get { return tournoi; }
        set { tournoi = value; }
    }

    [DataMember]
    public EPhaseTournoi PhaseTournoi
    {
        get { return phaseTournoi; }
        set { phaseTournoi = value; }
    }

    [DataMember]
    public PokemonComposite Pokemon1
    {
        get { return pokemon1; }
        set { pokemon1 = value; }
    }

    [DataMember]
    public PokemonComposite Pokemon2
    {
        get { return pokemon2; }
        set { pokemon2 = value; }
    }

    [DataMember]
    public StadeComposite Stade
    {
        get { return stade; }
        set { stade = value; }
    }
}

[DataContract]
public class StadeComposite : EntityObjectComposite
{
    string nom;
    ETypeElement type;
    int nbPlaces;
    int attaque;
    int defense;

    public StadeComposite(Stade stade)
    {
        Id = stade.ID;
        Nom = stade.Nom;
        Type = stade.Type;
        NbPlaces = stade.NbPlaces;
        Attaque = stade.Attaque;
        Defense = stade.Defense;
    }

    [DataMember]
    public string Nom
    {
        get { return nom; }
        set { nom = value; }
    }

    [DataMember]
    public ETypeElement Type
    {
        get { return type; }
        set { type = value; }
    }

    [DataMember]
    public int NbPlaces
    {
        get { return nbPlaces; }
        set { nbPlaces = value; }
    }

    [DataMember]
    public int Attaque
    {
        get { return attaque; }
        set { attaque = value; }
    }

    [DataMember]
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }
}

[DataContract]
public class CaracterisiqueComposite : EntityObjectComposite
{
    int pv;
    int attaque;
    int defense;
    int vitesse;
    int esquive;

    public CaracterisiqueComposite(Caracteristique carac)
    {
        Id = carac.ID;
        PV = carac.PV;
        Attaque = carac.Attaque;
        Defense = carac.Defense;
        Esquive = carac.Esquive;
        Vitesse = carac.Vitesse;
    }

    [DataMember]
    public int PV
    {
        get { return pv; }
        set { pv = value; }
    }

    [DataMember]
    public int Attaque
    {
        get { return attaque; }
        set { attaque = value; }
    }

    [DataMember]
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    [DataMember]
    public int Esquive
    {
        get { return esquive; }
        set { esquive = value; }
    }

    [DataMember]
    public int Vitesse
    {
        get { return vitesse; }
        set { vitesse = value; }
    }
}