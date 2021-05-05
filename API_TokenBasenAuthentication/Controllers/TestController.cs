using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_TokenBasenAuthentication.Controllers
{
    public class TestController : ApiController
    {
        //[EnableCors(origins:"*", headers:"*", methods:"*")]
        [HttpGet]
        [Authorize] // Authorize attribute, token'ı olmayan kullanıcıların erişimini engeller.
        //[Authorize(Roles = "user")] // Kullanıcı (user) rolüne sahip olanlar erişsin diye ekleme yapabiliriz.
        public IHttpActionResult Get()
        {
            List<string> data = new List<string>();
            data.Add("Test1");
            data.Add("Test2");
            data.Add("Test3");

            return Json(data);
        }
    }
}
