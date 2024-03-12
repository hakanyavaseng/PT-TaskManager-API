namespace TaskManager.Application.Features.User.Commands.Register
{
    public class RegisterCommandResponse
    {
        public bool IsSuccessed { get; set; }
        public IList<string>? Message { get; set; } = new List<string>();

        public string Token { get; set; }
    }
}
