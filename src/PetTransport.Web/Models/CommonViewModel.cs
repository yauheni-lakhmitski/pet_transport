using PetTransport.Domain.Entities;

namespace PetTransport.Web.Models;

public class CommonViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class CommonGuidViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class CommonCustomerTypeViewModel
{
    public CommonCustomerTypeViewModel(CustomerType id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public CustomerType Id { get; set; }
    public string Name { get; set; }
}

public class CommonApplicationStatusViewModel
{
    public CommonApplicationStatusViewModel(ApplicationStatus id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public ApplicationStatus Id { get; set; }
    public string Name { get; set; }
}