using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FicheAgenceES.Models
{
    public class Agences
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        
        [BsonElement("nom")]
        public string nom { get; set; }


        [BsonElement("localisation")]
        public Localisation localisation { get; set; }

        [BsonElement("employe")]
        public List<Employe> employe { get; set; }

        [BsonElement("tel")]
        public string tel { get; set; }
    }
}