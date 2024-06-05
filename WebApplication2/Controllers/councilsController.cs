using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class councilsController : ApiController
    {


        NeighborhoodCouncilEntities db = new NeighborhoodCouncilEntities();

        [HttpPost]
        public HttpResponseMessage InsertAdmin(Council Council)
        {

            try
            {
                db.Councils.Add(Council);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "member add" + Council.id);


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    //[HttpGet]
    //public HttpResponseMessage Searchcouncils(int matchid)
    //{

    //    try
    //    {
    //        var schedule = db.Schedules.Where(b => b.match_id == matchid)
    //                                 .Select(s => new
    //                                 {
    //                                     s.id,
    //                                     s.team1_id,
    //                                     s.team2_id,
    //                                     s.match_id,
    //                                     s.date,
    //                                     s.time

    //                                 })
    //                                 .OrderBy(b => b.id)
    //                                 .ToList();
    //        return Request.CreateResponse(HttpStatusCode.OK, schedule);

    //    }
    //    catch (Exception ex)
    //    {
    //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
    //    }
    }

