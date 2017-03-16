using SampleApplication.Models;

namespace SampleApplication.Interfaces
{
    public interface IDatabaseShim
    {
        User Login(User user);
    }
}