using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FicheAgenceES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var agences = new List<Models.Agences>();

            var Client = new MongoClient("mongodb://127.0.0.1:27017");
            var db = Client.GetDatabase("agences_gca");
            var collection = db.GetCollection<Models.Agences>("agences").Find(new BsonDocument()).ToList();

            foreach(var item in collection)
            {
                agences.Add(item);
            }
            return View(agences);
        }
    }
}