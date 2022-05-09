using System.ComponentModel;

namespace PetTransport.Domain.Entities.Enums;

public enum ApplicationStatus
{
    [Description("В обработке")]
    Pending,
    [Description("Ожидает оплаты")]
    NotPaid,
    [Description("Оплачен")]
    Paid,
    [Description("В работе")]
    InProgress,
    [Description("Завершен")]
    Completed
}