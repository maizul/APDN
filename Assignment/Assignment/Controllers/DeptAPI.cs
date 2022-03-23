using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment.Models.DB;
namespace Assignment.Controllers
{
    public class DeptAPI : ApiController
    {

        //[Route("api/dept/details/{Id}"]
        //[HttpGet]
        //public HttpResponseMessage Dept(int id) {

        //    //Department data = Dept(id);

        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}


        [Route("api/dept/details/{Id}")]
        [HttpGet]
        public Department Dept(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            var p = db.Departments.ToList();
            return p.FirstOrDefault(x => x.Id == id);
        }
    }
}
