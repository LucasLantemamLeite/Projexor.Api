namespace Projexor.Models;

public class UserAccount
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateTime CreateAt { get; set; }
    public bool Active { get; set; }
    public int Role { get; set; }

    public UserAccount(string name, string email, string password, string phone_number, DateOnly birth_date, bool active = true, int role = 1)
    {
        Id = Guid.NewGuid();
        Name = name;
        PasswordHash = password;
        Email = email;
        PhoneNumber = phone_number;
        BirthDate = birth_date;
        CreateAt = DateTime.UtcNow;
        Active = active;
        Role = role;
    }

    protected UserAccount() { }
}