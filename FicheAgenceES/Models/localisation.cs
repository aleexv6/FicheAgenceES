using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FicheAgenceES.Models
{
    public class Localisation
    {
        [BsonElement("adresse")]
        public string adresse { get; set; }

        [BsonElement("code_postal")]
        [Required]
        public string code_postal { get; set; }

        [BsonElement("ville")]
        [Required]
        public string ville { get; set; }

        [BsonElement("latitude")]
        [Required]
        public string latitude { get; set; }

        [BsonElement("longitude")]
        [Required]
        public string longitude { get; set; }
    }
}