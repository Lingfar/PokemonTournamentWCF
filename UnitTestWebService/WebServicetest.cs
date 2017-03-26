using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonTournamentEntities;
using System.Collections.Generic;

namespace UnitTestWebService
{
    [TestClass]
    public class WebServiceTest
    {

        private ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient();

        [TestMethod]
        public void GetAllPokemons()
        {
            List<ServiceReference1.PokemonComposite> pokemons = new List<ServiceReference1.PokemonComposite>();
            pokemons.AddRange(service.GetAllPokemons());
            Assert.AreEqual(pokemons.Count, 100);
        }

        [TestMethod]
        public void TestGetSpecificPokemon()
        {
            ServiceReference1.PokemonComposite pokeTest = new ServiceReference1.PokemonComposite();

            pokeTest.Id = 1;
            pokeTest.Nom = "Bulbizarre";
            pokeTest.Type = ServiceReference1.ETypeElement.Plante;
            pokeTest.Caracteristique = new ServiceReference1.CaracterisiqueComposite();
            pokeTest.Caracteristique.PV = 101;
            pokeTest.Caracteristique.Attaque = 6;
            pokeTest.Caracteristique.Defense = 6;
            pokeTest.Caracteristique.Vitesse = 13;
            pokeTest.Caracteristique.Esquive = 24;

            ServiceReference1.PokemonComposite pokeTestUpdate = service.GetPokemonById(1);

            Assert.AreEqual(pokeTest.Id, pokeTestUpdate.Id);
            Assert.AreEqual(pokeTest.Nom, pokeTestUpdate.Nom);
            Assert.AreEqual(pokeTest.Caracteristique.PV, pokeTest.Caracteristique.PV);
            Assert.AreEqual(pokeTest.Caracteristique.Vitesse, pokeTest.Caracteristique.Vitesse);
            Assert.AreEqual(pokeTest.Caracteristique.Attaque, pokeTest.Caracteristique.Attaque);
            Assert.AreEqual(pokeTest.Caracteristique.Defense, pokeTest.Caracteristique.Defense);
        }

        [TestMethod]
        public void TestInsertPokemon()
        {
            ServiceReference1.PokemonComposite pokeTest = new ServiceReference1.PokemonComposite();
            pokeTest.Nom = "Pokemon Test";
            pokeTest.Type = ServiceReference1.ETypeElement.Insecte;

            ServiceReference1.CaracterisiqueComposite  caracTest = new ServiceReference1.CaracterisiqueComposite();
            caracTest.PV = 150;
            caracTest.Attaque = 15;
            caracTest.Defense = 5;
            caracTest.Vitesse = 10;
            caracTest.Esquive = 40;
            pokeTest.Caracteristique = caracTest;

            service.AddNewPokemon(pokeTest);

            List<ServiceReference1.PokemonComposite> pokemons = new List<ServiceReference1.PokemonComposite>();
            pokemons.AddRange(service.GetAllPokemons());

            ServiceReference1.PokemonComposite pokeTestUpdate = pokemons[pokemons.Count - 1];
            
            Assert.AreEqual(pokeTest.Nom, pokeTestUpdate.Nom);
            Assert.AreEqual(pokeTest.Caracteristique.PV, pokeTest.Caracteristique.PV);
            Assert.AreEqual(pokeTest.Caracteristique.Vitesse, pokeTest.Caracteristique.Vitesse);
            Assert.AreEqual(pokeTest.Caracteristique.Id, pokeTest.Caracteristique.Id);
            Assert.AreEqual(pokeTest.Caracteristique.Attaque, pokeTest.Caracteristique.Attaque);
            Assert.AreEqual(pokeTest.Caracteristique.Defense, pokeTest.Caracteristique.Defense);
        }

        [TestMethod]
        public void TestUpdatePokemon()
        {
            List<ServiceReference1.PokemonComposite> pokemons = new List<ServiceReference1.PokemonComposite>();
            pokemons.AddRange(service.GetAllPokemons());

            ServiceReference1.PokemonComposite pokeTest = pokemons[pokemons.Count - 1];

            pokeTest.Nom = "Pokemon Test Update";
            pokeTest.Type = ServiceReference1.ETypeElement.Feu;
            pokeTest.Caracteristique.PV = 179;
            pokeTest.Caracteristique.Attaque = 12;
            pokeTest.Caracteristique.Defense = 14;
            pokeTest.Caracteristique.Vitesse = 2;
            pokeTest.Caracteristique.Esquive = 30;

            service.UpdatePokemon(pokeTest);

            pokemons = new List<ServiceReference1.PokemonComposite>();
            pokemons.AddRange(service.GetAllPokemons());

            ServiceReference1.PokemonComposite pokeTestUpdate = pokemons[pokemons.Count - 1];

            Assert.AreEqual(pokeTest.Id, pokeTestUpdate.Id);
            Assert.AreEqual(pokeTest.Nom, pokeTestUpdate.Nom);
            Assert.AreEqual(pokeTest.Caracteristique.PV, pokeTest.Caracteristique.PV);
            Assert.AreEqual(pokeTest.Caracteristique.Vitesse, pokeTest.Caracteristique.Vitesse);
            Assert.AreEqual(pokeTest.Caracteristique.Id, pokeTest.Caracteristique.Id);
            Assert.AreEqual(pokeTest.Caracteristique.Attaque, pokeTest.Caracteristique.Attaque);
            Assert.AreEqual(pokeTest.Caracteristique.Defense, pokeTest.Caracteristique.Defense);
        }

        [TestMethod]
        public void TestDeletePokemon()
        {
            List<ServiceReference1.PokemonComposite> pokemons = new List<ServiceReference1.PokemonComposite>();
            pokemons.AddRange(service.GetAllPokemons());
            int ancienneTaille = pokemons.Count;
            service.DeletePokemonById(pokemons[pokemons.Count - 1].Id);
            pokemons = new List<ServiceReference1.PokemonComposite>();
            pokemons.AddRange(service.GetAllPokemons());
            Assert.AreEqual(ancienneTaille - 1, pokemons.Count);
        }

    }
}
