namespace _5W2H.Application.Models;

public class UserViewModel
{
    public UserViewModel(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }

    public string FullName { get;  set; }
    public string Email { get;  set; }
}