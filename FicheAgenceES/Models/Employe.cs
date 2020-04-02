using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FicheAgenceES.Models
{
    public class Employe
    {
        [BsonElement("nom")]
        public string nom { get; set; }

        [BsonElement("prenom")]
        public string prenom { get; set; }

        [BsonElement("poste")]
        public string poste { get; set; }

        [BsonElement("numero_tel")]
        public string numero_tel { get; set; }
    }
}