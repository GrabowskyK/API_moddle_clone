namespace ApiMoodleClone.Auth.AuthService
{
    public interface IAuthService
    {
        public bool Register(RegisterRequestDto user);
        public string Login(LoginRequestDto user);
    }
}
