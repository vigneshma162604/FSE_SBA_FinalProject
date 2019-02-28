using ProjectManagement_BL;
using ProjectManagement_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagement_API.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IProjectBL projectBL;

        public ProjectController(IProjectBL projectBL)
        {
            this.projectBL = projectBL;
        }

        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns>IEnuemrable<Project></returns>
        [HttpGet]
        [Route("GetProjectDetails")]
        public IEnumerable<Project> Get()
        {
            return projectBL.GetAllProject();
        }

        /// <summary>
        /// Get Project By Id
        /// </summary>
        /// <param name="projectID">Project Id</param>
        /// <returns>Project</returns>
        [HttpGet]
        [Route("GetProjectById")]
        public Project GetById(int id)
        {
            return projectBL.GetProjectById(id);
        }

        /// <summary>
        /// Add New Project
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [Route("AddProject")]
        public IHttpActionResult Post([FromBody]Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            else
            {
                projectBL.AddProject(project);
                return Ok();
            }
        }

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="projectID">Project Id</param>
        /// <returns>Boolean</returns>
        [HttpDelete]
        [Route("DeleteProject")]
        public IHttpActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                int result = projectBL.DeleteProject(id);
                if (result == -1)
                    return NotFound();
                else
                    return Ok();
            }
        }

        /// <summary>
        /// Updated Project
        /// </summary>
        /// <param name="project">Project</param>
        /// <returns>Boolean</returns>
        [HttpPut]
        [Route("UpdateProject")]
        public IHttpActionResult Put([FromBody]Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            else
            {
                int result = projectBL.UpdateProject(project);
                if (result == -1)
                    return NotFound();
                else
                    return Ok();
            }
        }

    }
}