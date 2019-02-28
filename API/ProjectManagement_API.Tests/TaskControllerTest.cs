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
    public class TaskControllerTest
    {
        private readonly TaskController taskController;
        private ITaskBL taskBL;
        private ITaskDA taskContent;
        public TaskControllerTest()
        {
            taskContent = new TaskDA();
            taskBL = new TaskBL(taskContent);
            this.taskController = new TaskController(taskBL);
        }

        [TestMethod]
        public void TestGetAllTask()
        {
            Assert.AreNotEqual(null, taskController.Get());
        }

        [TestMethod]
        public void TestGetTaskByIDSuccess()
        {
            Assert.AreNotEqual(null, taskController.GetById(1));
        }

        [TestMethod]
        public void TestGetTaskByIDFailed()
        {
            Assert.AreEqual(null, taskController.GetById(2));
        }

        [TestMethod]
        public void TestAddTaskSuccess()
        {
            IHttpActionResult response = taskController.Post(new Task() { ParentTaskId = 1, ProjectId = 1, TaskDesc = "Task 1", StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now, Priority = 1 });
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public void TestUpdateTaskSuccess()
        {
            IHttpActionResult response = taskController.Put(new Task() { TaskID = 1, ParentTaskId = 2, ProjectId = 1, TaskDesc = "Task 1", StartDate = DateTime.Now.AddMonths(-2), EndDate = DateTime.Now, Priority = 1 });
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public void TestDeleteTaskSuccess()
        {
            IHttpActionResult response = taskController.Delete(1);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
