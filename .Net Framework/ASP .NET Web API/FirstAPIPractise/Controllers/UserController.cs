using FirstAPIPractise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FirstAPIPractise.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private ApplicationDbContext context;
        public UserController()
        {
            context = new ApplicationDbContext();
        }

        [Route("getusers")]
        [Route("~/")]
        public HttpResponseMessage GetUsers()
        {
            var users = context.Users.ToList();

            if (users == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,"No Value is there");

            return Request.CreateResponse(HttpStatusCode.OK, users);

        }

      
        [Route("getuserbyid/{id}")]
        public async Task<HttpResponseMessage> GetUserById(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Not Found");
            else
                return Request.CreateResponse(HttpStatusCode.OK,user);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IHttpActionResult> AddUser(User user)
        {
            if (user == null)
                return StatusCode(HttpStatusCode.NoContent);
            else
            {
                try
                {
                    context.Users.Add(user);
                    await context.SaveChangesAsync();
                    return Created("", "Added");
                }
                catch
                {
                    return InternalServerError();
                }
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IHttpActionResult> UpdateUser(int id,[FromBody] User user)
        {
            if (user == null)
                return StatusCode(HttpStatusCode.NoContent);
            else
            {
                try
                {
                    if (id != user.UserId)
                        return BadRequest();
                    else
                    {
                        context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        await context.SaveChangesAsync();
                        return Ok("Updated");
                    }
                    
                }
                catch
                {
                    return InternalServerError();
                }
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return BadRequest();
            else
            {
                try
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                    return Ok("Deleted");
                }
                catch
                {
                    return InternalServerError();
                }
            }
        }
    }
}
