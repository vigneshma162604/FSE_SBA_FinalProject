using ProjectManagement_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement_Entity;
using System.Web.Http.Cors;
using Unity;

namespace ProjectManagement_API.Controllers
{
    //[EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>IEnuemrable<User></returns>
        [HttpGet]
        [Route("GetUserDetails")]
        public IEnumerable<User> Get()
        {
            return userBL.GetAllUser();
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        [HttpGet]
        [Route("GetUserById")]
        public User GetById(int id)
        {
            return userBL.GetUserById(id);
        }

        /// <summary>
        /// Search User
        /// </summary>
        /// <param name="searchText">Search Text</param>
        /// <returns>IEnumerable<User></returns>
        [HttpGet]
        [Route("SearchUsers")]
        public IEnumerable<User> SearchUsers(string searchText)
        {
            return userBL.SearchUsers(searchText);
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="task">USer</param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                userBL.AddUser(user);
                return Ok();
            }
        }

        /// <summary>
        /// Updated User
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>IHttpActionResult</returns>
        [HttpPut]
        [Route("UpdateUser")]
        public IHttpActionResult Put([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                int result = userBL.UpdateUser(user);
                if (result == -1)
                    return NotFound();
                else
                    return Ok();
            }
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>IHttpActionResult</returns>
        [HttpDelete]
        [Route("DeleteUser")]
        public IHttpActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                int result = userBL.DeleteUser(id);
                if (result == -1)
                    return NotFound();
                else
                    return Ok();
            }
        }
    }
}