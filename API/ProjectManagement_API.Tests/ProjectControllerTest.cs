using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement_API.Controllers;
using ProjectManagement_BL;
using ProjectManagement_Entity;
using ProjectManagement_DA;
using System.Web.Http.Results;
using System.Web.Http;

namespace ProjectManagement_API.Tests
{
    [TestClass]
    public class ProjectControllerTest
    {
        private readonly ProjectController projectController;
        private IProjectBL projectBL;
        private IProjectDA projectMngtContext;
        public ProjectControllerTest()
        {
            projectMngtContext = new ProjectDA();
            projectBL = new ProjectBL(projectMngtContext);
            this.projectController = new ProjectController(projectBL);
        }

        [TestMethod]
        public void TestGetAllProject()
        {
            Assert.AreNotEqual(null, projectController.Get());
        }

        [TestMethod]
        public void TestGetProjectByIDSuccess()
        {
            Assert.AreNotEqual(null, projectController.GetById(1));
        }

        [TestMethod]
        public void TestGetProjectByIDFailed()
        {
            Assert.AreEqual(null, projectController.GetById(2));
        }

        [TestMethod]
        public void TestAddProjectSuccess()
        {
            IHttpActionResult response = projectController.Post(new Project() { ProjectName = "A1B1", StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now, Priority = 1 });
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public void TestUpdateProjectSuccess()
        {
            IHttpActionResult response = projectController.Put(new Project() { ProjectID = 4, ProjectName = "DDD", StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now, Priority = 1 });
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public void TestDeleteProjectSuccess()
        {
            IHttpActionResult response = projectController.Delete(10);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
