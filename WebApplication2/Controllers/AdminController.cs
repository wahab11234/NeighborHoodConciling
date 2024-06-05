using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : ApiController
    {
        NeighborhoodCouncilEntities db = new NeighborhoodCouncilEntities();

        [HttpGet]

        public HttpResponseMessage ViewAdmins()
        {
            try
            {
                var admin = db.Admins.Select(u => new
                {
                    u.id,
                    u.Member_id,
                    u.Council_id
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, admin);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage InsertAdmin(Admin admin)
        {

            try
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Member added" + admin.id);


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage ModifyAdmin(Admin Admin)
        {

            try
            {
                var original = db.Admins.Find(Admin.id);
                if (original == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Schedule not found");
                }
                db.Entry(original).CurrentValues.SetValues(Admin);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Schedule Modified");



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage FindMemberAdmin(String cnic)
        {

            try
            {
                var schedule = db.Members.Where(b => b.Cnic == cnic)
                                         .Select(s => new
                                         {
                                             s.id,
                                             s.Cnic,
                                             s.Full_Name,


                                         })

                                         .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, schedule);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }


}