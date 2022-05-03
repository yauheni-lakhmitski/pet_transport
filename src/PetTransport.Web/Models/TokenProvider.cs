namespace PetTransport.Web.Models;

public class TokenProvider
{
    public string XsrfToken { get; set; }
    public string RefreshToken { get; set; }
}