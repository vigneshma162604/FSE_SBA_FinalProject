using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement_BL;
using ProjectManagement_Entity;

namespace ProjectManagement_API.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskBL taskBL;

        public TaskController(ITaskBL taskBL)
        {
            this.taskBL = taskBL;
        }

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns>IEnuemrable<Project></returns>
        [HttpGet]
        [Route("GetTaskDetails")]
        public IEnumerable<Task> Get()
        {
            return taskBL.GetAllTask();
        }

        /// <summary>
        /// Get Task By Id
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>Project</returns>
        [HttpGet]
        [Route("GetTaskById")]
        public Task GetById(int id)
        {
            return taskBL.GetTaskById(id);
        }

        /// <summary>
        /// Add New Task
        /// </summary>
        /// <param name="task">task</param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("AddTask")]
        public IHttpActionResult Post([FromBody]Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            else
            {
                taskBL.AddTask(task);
                return Ok();
            }
        }

        /// <summary>
        /// Updated Task
        /// </summary>
        /// <param name="task">Task</param>
        /// <returns>IHttpActionResult</returns>
        [HttpPut]
        [Route("UpdateTask")]
        public IHttpActionResult Put([FromBody]Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            else
            {
                int result = taskBL.UpdateTask(task);
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
        [Route("DeleteTask")]
        public IHttpActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                int result = taskBL.DeleteTask(id);
                if (result == -1)
                    return NotFound();
                else
                    return Ok();
            }
        }
    }
}