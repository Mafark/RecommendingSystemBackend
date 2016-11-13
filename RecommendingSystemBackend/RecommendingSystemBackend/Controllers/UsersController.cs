using Newtonsoft.Json;
using RecommendingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecommendingSystemBackend.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("users")]
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            //take data from the database
            //for example:
            users = JsonConvert.DeserializeObject<List<User>>("[{\"Films\":[[\"filmTitle\",\"genre\",\"5\",\"20.07.2015 0:00:00\"],[\"filmTitleTwo\",\"genre\",\"1\",\"20.01.2016 0:00:00\"]],\"Nickname\":\"nickName\",\"Email\":\"email\",\"Name\":\"name\",\"Surname\":\"urname\"}]");
            return users;
        }

        [HttpPost]
        [Route("users")]
        public HttpResponseMessage SaveUsers([FromBody]List<User> users)
        {
            try
            {
                //add the user to the database
                return Request.CreateResponse(HttpStatusCode.Created, "Users was successfully saved");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error");
            }
        }
    }
}
