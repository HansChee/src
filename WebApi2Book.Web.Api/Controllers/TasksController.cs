using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi2Book.Web.Api.Controllers
{
    [RoutePrefix("api/employeeTasks")]
    public class TasksController : ApiController
    {
        [Route("{id:int:max(100)}", Name = "GetTaskById")]
        public HttpResponseMessage GetTaskWithAMaxIdOf100(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created);

            // Generate a link to the new book and set the Location header in the response.
            string uri = Url.Link("GetTaskById", new { id });
            response.Headers.Location = new Uri(uri);

            return response;
            //return $"In the GetTaskWithAMaxIdOf100(int id) method, id = {id}";
        }

        [Route("{id:int:min(101)}")]
        [HttpGet]
        public string FindTaskWithAMinIdOf101(int id)
        {
            return $"In the FindTaskWithAMinIdOf101(int id) method, id = {id}";
        }

        [Route("api/tasks/{taskNum:alpha}")]
        public string Get(string taskNum)
        {
            return $"In the Get(string taskNum) overload, taskNum = {taskNum}";
        }


    }
}
