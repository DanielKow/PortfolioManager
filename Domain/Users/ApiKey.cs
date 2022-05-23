namespace PortfolioManager.Domain.Users;

public class ApiKey
{
    public string Key { get; set; }
    public string Type { get; set; }
    public int UserId { get; set; }
}