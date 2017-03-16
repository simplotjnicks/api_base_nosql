using System.Collections.Generic;
using NSubstitute;
using SampleApplication.Controllers;
using SampleApplication.Interfaces;
using SampleApplication.Models;
using Xunit;

namespace SampleAppTests
{
    public class AuthenticationControllerTest
    {
        #region Private Instance Variables

        private Dictionary<string, User> _users;

        #endregion Private Instance Variables

        #region Test Cases

        [Fact]
        public void LoginSuccess()
        {
            var result = ControllerForTest().Post(_users["good"]);
            Assert.Equal(_users["goodOut"], result);
        }

        [Fact]
        public void LoginFail()
        {
            var result = ControllerForTest().Post(_users["bad"]);
            Assert.Null(result);
        }

        [Fact]
        public void Get()
        {
            var result = ControllerForTest().Get();
            Assert.IsType<string[]>(result);
            Assert.Contains("Josh", result);
        }

        #endregion Test Cases

        #region Helpers

        private void SetupUsers()
        {
            _users = new Dictionary<string, User>
            {
                {"good", new User {UserName = "test", Password = "test"}},
                {"goodOut", new User {UserName = "test", Password = "test", Name = "Test User"}},
                {"bad", new User {UserName = "test", Password = "badpassword"}},
            };
        }

        private AuthenticationController ControllerForTest()
        {
            SetupUsers();
            var database = Substitute.For<IDatabaseShim>();
            database.Login(_users["good"]).Returns(_users["goodOut"]);
            return new AuthenticationController(database);
        }

        #endregion Helpers
    }
}