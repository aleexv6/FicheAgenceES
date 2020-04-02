using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using FicheAgenceES.Models;
using Microsoft.Extensions.Configuration;

namespace FicheAgenceES.Agences
{
    public class AgenceService
    {
        private readonly IMongoCollection<Models.Agences> agences;

        public AgenceService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("agences_gca"));
            IMongoDatabase database = client.GetDatabase("agences_gca");
            agences = database.GetCollection<Models.Agences>("agences");
        }
        public List<Models.Agences> Get()
        {
            return agences.Find(agence => true).ToList();
        }

        public Models.Agences Get(string id)
        {
            return agences.Find(agence => agence.id == id).FirstOrDefault();
        }

        public Models.Agences Create(Models.Agences agence)
        {
            agences.InsertOne(agence);
            return agence;
        }

        public void Update(string id, Models.Agences agenceIn)
        {
            agences.ReplaceOne(agence => agence.id == id, agenceIn);
        }
        public void Remove(Models.Agences agenceIn)
        {
            agences.DeleteOne(agence => agence.id == agenceIn.id);
        }

        public void Remove(string id)
        {
            agences.DeleteOne(agence => agence.id == id);
        }
    }
}