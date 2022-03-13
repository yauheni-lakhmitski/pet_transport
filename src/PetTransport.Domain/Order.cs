using System.ComponentModel;

namespace PetTransport.Domain;

public class Order
{
    [DisplayName("Идентификатор")] public Guid Id { get; set; }
    
    
    [DisplayName("Страна")] public string CountryOfDestination { get; set; }
    [DisplayName("Дата отправления")] public DateTime DepartureDate { get; set; }
    [DisplayName("Стоимость доставки")] public Decimal Price { get; set; }
    
    
    // TODO: Additional service

    [DisplayName("Встреча в аэропорту")] public bool Airport { get; set; }
    [DisplayName("Встреча на вокзале")] public bool RailwayStation { get; set; }
    [DisplayName("Курьер")]public bool Courier { get; set; }

    [DisplayName("Адресс")] public string Address { get; set; }
    [DisplayName("Номер телефона перевозчика")] public string TransferPhoneNumber { get; set; }
    
    [DisplayName("Передержка с")] public DateTime ShelterFrom { get; set; }
    
    // TODO: SENDER
    [DisplayName("Отправитель ФИО")] public string SenderFullName { get; set; }
    [DisplayName("Улица отправителя")] public string SenderStreet { get; set; }
    [DisplayName("Город отправителя")] public string SenderCity { get; set; }
    [DisplayName("Регион отправителя")] public string SenderRegion { get; set; }
    [DisplayName("Почтовый индекс отправителя")] public string Zip { get; set; }
    [DisplayName("Телефон отправителя")] public string SenderPhoneNumber { get; set; }
    [DisplayName("Email отправителя")] public string SenderEmail { get; set; }
    [DisplayName("WhatsApp отправителя")] public string SenderWhatsApp { get; set; }
    
    
    // TODO: ANIMAL
    [DisplayName("Кличка")]public string Name { get; set; }
    [DisplayName("Порода")]public string Breed { get; set; }
    [DisplayName("Пол")]public string Sex { get; set; }
    [DisplayName("Окрас")]public string Color { get; set; }
    [DisplayName("Дата рождения")]public DateTime DateOfBirth { get; set; }
    [DisplayName("Номер чипа")]public string ChipNumber { get; set; }
    [DisplayName("Дата чипирования")]public DateTime DateOfChip { get; set; }
    
    
    
    // TODO: RECIPIENT
    [DisplayName("Получатель ФИО")] public string RecipientFullName { get; set; }
    [DisplayName("Адрес полный")] public string RecipientStreet { get; set; }
    [DisplayName("Почтовый индекс получателя")] public string RecipientZip { get; set; }
    [DisplayName("Телефон получателя")] public string RecipientPhoneNumber { get; set; }
    [DisplayName("Email получателя")] public string RecipientEmail { get; set; }
    [DisplayName("WhatsApp получателя")] public string RecipientWhatsApp { get; set; }
}