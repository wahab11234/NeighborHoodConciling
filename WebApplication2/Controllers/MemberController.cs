using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication2.Models;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{   
    public class MemberController : ApiController
    {
        
        NeighborhoodCouncilEntities db = new NeighborhoodCouncilEntities();
        [HttpGet]
        public HttpResponseMessage FindMemberBy() {
            try
            {
                var request = HttpContext.Current.Request;
                var f = request.Form["post"];
                Member m = JsonConvert.DeserializeObject<Member>(f);
                var schedule = db.Members.Where(s=>(m.id==0?true:m.id==s.id)&& (m.Cnic == null ? true : m.Cnic == s.Cnic))
                                        .Select(s => new
                                        {
                                            s.id,
                                            s.Cnic,
                                            s.Full_Name,
                                            s.Gender,
                                            s.DoB,
                                            s.Province,
                                            s.City,
                                            s.Address,
                                            s.User_Type,
                                            s.Date_joined,
                                            s.Council_id
                                        })
                                        .OrderBy(b => b.id)
                                        .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, schedule);

            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public HttpResponseMessage ShowAllMembers()
        {

            try
            {
                var member = db.Members.Select(s => new
                                         {
                                             s.id,
                                             s.Cnic,
                                             s.Full_Name,
                                             s.Gender,
                                             s.DoB,
                                             s.Province,
                                             s.City,
                                             s.Address,
                                             s.User_Type,
                                             s.Date_joined,
                                             s.Council_id
                                         })
                                         .OrderBy(b => b.id)
                                         .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, member);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage InsertMember(Member member)
        {

            try
            {
                db.Members.Add(member);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "New Member Added at " + member.id);


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateMember(Member member)
        {

            try
            {
                var original = db.Members.Find(member.id);
                if (original == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Member not found");
                }
                db.Entry(original).CurrentValues.SetValues(member);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Member Updated");



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage DeleteMember(int id)
        {

            try
            {
                var original = db.Members.Find(id);
                if (original == null)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Member not found");
                }
                db.Entry(original).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Member Deleted");



            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}