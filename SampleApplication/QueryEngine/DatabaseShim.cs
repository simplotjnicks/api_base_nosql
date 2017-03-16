using SampleApplication.Interfaces;
using SampleApplication.Models;

namespace SampleApplication.QueryEngine
{
    public class DatabaseShim : IDatabaseShim
    {
        #region Methods

        public User Login(User user)
        {
            /* TODO: Actual check in a local or cloud MS SQL DB */
            /* TODO: Actual check in a local or cloud NOSQL DB */
            return user.Name == user.Password ? user : null;
        }

        #endregion Methods
    }
}