
using System.Linq;
using System.Web.Mvc;
using FicheAgenceES.Connexion;
using FicheAgenceES.Models;
using Nest;

namespace WebElasticSearch.Controllers
{
    public class AllSearchController : Controller
    {
        private readonly ConnexionES _connectionToEs;
        public AllSearchController()
        {
            _connectionToEs = new ConnexionES();
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View("Search");
        }

        public JsonResult DataSearch(string genre, string description)
        {

            var indexDescriptor = new CreateIndexDescriptor("importsql")
                                    .Map<importsql>(m => m.AutoMap());

            if (!string.IsNullOrEmpty(genre) && !string.IsNullOrEmpty(description))
            {
                var responsedata = _connectionToEs.EsClient().Search<importsql>(s => s
                                 .Index("importsql")
                                 .Size(50)
                                 .Query(q => q
                                 .Match(m => m
                                     .Field(f => f.genre)
                                     .Query(genre)
                                 )
                                     && q
                                     .Match(m => m
                                         .Field(f => f.description)
                                         .Query(description)
                                 ))
                                );

                var datasend = (from hits in responsedata.Hits
                                select hits.Source).ToList();

                return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);

            }
            else if (!string.IsNullOrEmpty(genre))
            {
                var responsedata = _connectionToEs.EsClient().Search<importsql>(s => s
                                .Index("importsql")
                                .Size(50)
                                .Query(q => q
                                    .Match(m => m
                                        .Field(f => f.genre)
                                        .Query(genre)
                                    )));

                var datasend = (from hits in responsedata.Hits
                                select hits.Source).ToList();

                return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);
            }
            else if (!string.IsNullOrEmpty(description))
            {
                var responsedata = _connectionToEs.EsClient().Search<importsql>(s => s
                                .Index("importsql")
                                .Size(50)
                                .Query(q => q
                                    .Match(m => m
                                        .Field(f => f.description)
                                        .Query(description)
                                    )));
                var datasend = (from hits in responsedata.Hits
                                select hits.Source).ToList();

                return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);
            }
            return Json(data: null, behavior: JsonRequestBehavior.AllowGet);

        }


        #region Single Search
        //public JsonResult DataSearch(string jobtitle, string nationalIDNumber)
        //{
        //    var responsedata = _connectionToEs.EsClient().Search<Humanresources>(s => s
        //                            .Index("humanresources")
        //                            .Type("doc")
        //                            .Size(50)
        //                            .Query(q => q
        //                                .Match(m => m
        //                                    .Field(f => f.jobtitle)
        //                                    .Query(jobtitle)
        //                                )
        //                            )
        //                        );

        //    var datasend = (from hits in responsedata.Hits
        //                    select hits.Source).ToList();

        //    return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);
        //} 
        #endregion

        #region Conditional Search
        //public JsonResult DataSearch(string jobtitle, string nationalIDNumber)
        //{

        //    if (!string.IsNullOrEmpty(jobtitle) && !string.IsNullOrEmpty(nationalIDNumber))
        //    {
        //        var responsedata = _connectionToEs.EsClient().Search<Humanresources>(s => s
        //                         .Index("humanresources")
        //                         .Type("doc")
        //                         .Size(50)
        //                         .Query(q => q
        //                             .Match(m => m
        //                                 .Field(f => f.jobtitle)
        //                                 .Query(jobtitle)
        //                             )
        //                             && q
        //                             .Match(m => m
        //                                 .Field(f => f.nationalidnumber)
        //                                 .Query(nationalIDNumber)
        //                         ))
        //                     );

        //        var datasend = (from hits in responsedata.Hits
        //                        select hits.Source).ToList();

        //        return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);

        //    }
        //    else if (!string.IsNullOrEmpty(jobtitle))
        //    {
        //        var responsedata = _connectionToEs.EsClient().Search<Humanresources>(s => s
        //                        .Index("humanresources")
        //                        .Type("doc")
        //                        .Size(50)
        //                        .Query(q => q
        //                            .Match(m => m
        //                                .Field(f => f.jobtitle)
        //                                .Query(jobtitle)
        //                            )));

        //        var datasend = (from hits in responsedata.Hits
        //                        select hits.Source).ToList();

        //        return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);
        //    }
        //    else if (!string.IsNullOrEmpty(nationalIDNumber))
        //    {
        //        var responsedata = _connectionToEs.EsClient().Search<Humanresources>(s => s
        //                        .Index("humanresources")
        //                        .Type("doc")
        //                        .Size(50)
        //                        .Query(q => q
        //                            .Match(m => m
        //                                .Field(f => f.nationalidnumber)
        //                                .Query(nationalIDNumber)
        //                            )));
        //        var datasend = (from hits in responsedata.Hits
        //                        select hits.Source).ToList();

        //        return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(data: null, behavior: JsonRequestBehavior.AllowGet);

        //} 
        #endregion
    }
}