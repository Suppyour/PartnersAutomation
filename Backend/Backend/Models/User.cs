namespace Backend;

public class User
{
    public const int MaxLength = 25;

    public User(Guid id, string login, string email, string password)
    {
        Id = id;
        Login = login;
        Email = email;
        Password = password;
    }

    public Guid Id { get; set; }
    public string? Login { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public static (User? User, string Error) Create(Guid id, string? login, string? email, string? password)
    {
        if (string.IsNullOrWhiteSpace(login) || login.Length > MaxLength)
        {
            return (null, "Логин не может быть пустым, либо превышает максимально допустимую длину");
        }
        if (string.IsNullOrWhiteSpace(email) || email.Length > MaxLength)
        {
            return (null, "Mail не может быть пустым, либо превышает максимально допустимую длину");
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            return (null, "Пароль не может быть пустым");
        }
        var user = new User(Guid.NewGuid(), login, email, password);
        return (user, string.Empty);
    }
}