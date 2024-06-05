using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ElectionController : ApiController
    {
        NeighborhoodCouncilEntities db = new NeighborhoodCouncilEntities();

        [HttpGet]
        public HttpResponseMessage AllElections()
        {

            try
            {
                var elections = db.Elections
                                         .Select(s => new
                                         {
                                             s.id,
                                             s.Name,
                                             s.No_of_Voters,
                                             s.No_of_Nominations,
                                             s.Date,

                                         })
                                         .OrderBy(b => b.id)
                                         .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, elections);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage StartElection(Election election)
        {

            try
            {
                db.Elections.Add(election);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Data Insert at" + election.id);


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
