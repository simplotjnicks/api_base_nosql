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
            SetupUsers();
            var result = ControllerForTest().Post(_users["good"]);
            Assert.Equal(_users["good"], result);
        }

        [Fact]
        public void LoginFail()
        {
            SetupUsers();
            var result = ControllerForTest().Post(_users["bad"]);
            Assert.Null(result);
        }

        private void SetupUsers()
        {
            _users = new Dictionary<string, User>
            {
                {"good", new User {UserName = "test", Password = "test"}},
                {"bad", new User {UserName = "test", Password = "badpassword"}}
            };
        }

        #endregion Test Cases

        #region Helpers

        private AuthenticationController ControllerForTest()
        {
            var database = Substitute.For<IDatabaseShim>();
            database.Login(_users["good"]).Returns(_users["good"]);
            return new AuthenticationController(database);
        }

        #endregion Helpers
    }
}