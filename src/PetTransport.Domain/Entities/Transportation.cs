using System.ComponentModel;

namespace PetTransport.Domain.Entities;

public class Transportation
{
    public Guid Id { get; set; }
    [DisplayName("Название поездки")]
    public string Title { get; set; }
    public string Name { get; set; }
    
    [DisplayName("Описание")]
    public string Description { get; set; }
    
    [DisplayName("Дата создания")]
    public DateTime CreatedAt { get; set; }
    [DisplayName("Время обновления")]
    public DateTime UpdatedAt { get; set; }

    public List<Route> Routes { get; set; }
}