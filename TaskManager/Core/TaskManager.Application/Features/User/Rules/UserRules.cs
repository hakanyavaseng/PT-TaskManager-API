using TaskManager.Application.Bases;
using TaskManager.Application.Features.User.Exceptions;

namespace TaskManager.Application.Features.User.Rules
{
    public class UserRules : BaseRules
    {
        public Task PasswordsMustMatchAndMustNotBeNull(string password, string passwordConfirmed)
        {
            if(password == null || passwordConfirmed == null)
                throw new ArgumentNullException(nameof(password));
            if (!password.Equals(passwordConfirmed))
                throw new PasswordsMustMatchException();
            return Task.CompletedTask;

        }

    }
}
