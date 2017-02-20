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
public class PokemonComposite
{
    int id;
    string nom;
    ETypeElement type;

    public PokemonComposite(Pokemon pokemon)
    {
        Id = pokemon.ID;
        Nom = pokemon.Nom;
        Type = pokemon.Type;
    }

    [DataMember]
    public int Id
    {
        get { return id; }
        set { id = value; }
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
}