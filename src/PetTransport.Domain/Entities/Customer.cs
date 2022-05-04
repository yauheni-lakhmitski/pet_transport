using System.ComponentModel;

namespace PetTransport.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string? OrganizationNumber { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public CustomerType CustomerType { get; set; }
}

public enum CustomerType
{
    [Description("Физическое лицо")]
    NaturalPerson,
    [Description("ИП")]
    IndividualEntrepreneur,
    [Description("Юридическое лицо")]
    LegalEntity
}