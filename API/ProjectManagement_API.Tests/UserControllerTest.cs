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
    public class UserControllerTest
    {
        private readonly UserController userController;
        private IUserBL userBL;
        private IUserDA userContext;
        public UserControllerTest()
        {
            userContext = new UserDA();
            userBL = new UserBL(userContext);
            this.userController = new UserController(userBL);
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            Assert.AreNotEqual(null, userController.Get());
        }

        [TestMethod]
        public void TestGetUserByIDSuccess()
        {
            Assert.AreNotEqual(null, userController.GetById(1));
        }

        [TestMethod]
        public void TestGetTaskByIDFailed()
        {
            Assert.AreEqual(null, userController.GetById(2));
        }

        [TestMethod]
        public void TestAddUserSuccess()
        {
            IHttpActionResult response = userController.Post(new User() { FirstName = "AABB", LastName = "AB", EmployeeID = "Emp1", ProjectID = 1, TaskID = 2 });
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public void TestUpdateTaskSuccess()
        {
            IHttpActionResult response = userController.Put(new User() { UserID = 1, FirstName = "AABB", LastName = "AB", EmployeeID = "Emp1", ProjectID = 2, TaskID = 2 });
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public void TestDeleteTaskSuccess()
        {
            IHttpActionResult response = userController.Delete(2);
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
