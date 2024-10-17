namespace _5W2H.Application.Models;

public class LoginUserViewModel
{
    public LoginUserViewModel(string email, string token, int id)
    {
        Email = email;
        Token = token;
        Id = id;
    }

    public int Id { get; set; }
    public string Email { get; set; }   
    public string Token { get; set; }
}