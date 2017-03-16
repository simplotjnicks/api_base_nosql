using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Interfaces;
using SampleApplication.Models;
using SampleApplication.QueryEngine;

namespace SampleApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        #region Private Instance Variables

        private readonly IDatabaseShim _databaseShim;

        #endregion Private Instance Variables

        #region Constructors

        public AuthenticationController(IDatabaseShim databaseShim = null)
        {
            _databaseShim = databaseShim ?? new DatabaseShim();
        }

        #endregion Constructors

        #region Methods

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Scott", "Josh" };
        }

        [HttpPost("{username}")]
        public User Post([FromBody]User user)
        {
            return _databaseShim.Login(user);
        }

        #endregion Methods
    }
}