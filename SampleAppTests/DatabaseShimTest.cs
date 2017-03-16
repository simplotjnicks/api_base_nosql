using System;
using System.Linq;
using SampleApplication.Models;
using SampleApplication.QueryEngine;
using Xunit;

namespace SampleAppTests
{
    public class DatabaseShimTest
    {
        #region Test Cases

        [Fact]
        public void Constructor()
        {
            var result = DatabaseShimForTest();
            Assert.NotNull(result);
        }

        [Fact]
        public void LoginSuccess()
        {
            var user = new User();
            var result = DatabaseShimForTest().Login(user);
            Assert.Equal(user, result);
        }

        #endregion Test Cases

        #region Helpers

        private DatabaseShim DatabaseShimForTest()
        {
            return new DatabaseShim();
        }

        #endregion Helpers
    }
}