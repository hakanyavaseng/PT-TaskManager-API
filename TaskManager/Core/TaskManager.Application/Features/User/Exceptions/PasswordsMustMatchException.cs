using TaskManager.Application.Bases;

namespace TaskManager.Application.Features.User.Exceptions
{
    public class PasswordsMustMatchException : BaseExceptions
    {
        public PasswordsMustMatchException(string? message="Passwords doesn't match, check passwords!") : base(message)
        {
        }
    }
}
