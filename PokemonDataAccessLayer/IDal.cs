using PokemonTournamentEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDataAccessLayer
{
    public interface IDal
    {
        Utilisateur GetUtilisateurByLogin(string login);
        bool RegisterLogin(Utilisateur user);

        List<Tournoi> GetAllTournois();
        Tournoi GetTournoiById(int id);
        List<Pokemon> GetAllPokemons();
        List<Pokemon> GetAllPokemonsByType(ETypeElement type);
        Pokemon GetPokemonById(int id);
        List<Match> GetAllMatches();
        Match GetMatchById(int id);
        List<Stade> GetAllStades();
        Stade GetStadeById(int id);
        List<Caracteristique> GetAllCaracteristiques();

        bool InsertPokemon(Pokemon pokemon);
        bool InsertMatch(Match match);
        bool InsertStade(Stade stade);
        bool InsertTournoi(Tournoi tournoi);

        bool UpdateStade(Stade stade);
        bool UpdateTournoi(Tournoi tournoi);
        bool UpdatePokemon(Pokemon pokemon);

        bool DeleteStade(Stade stade);
        bool DeleteTournoi(Tournoi tournoi);
        bool DeletePokemon(Pokemon pokemon);
    }
}
