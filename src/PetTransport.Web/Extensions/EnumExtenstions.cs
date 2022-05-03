using System.ComponentModel;
using System.Reflection;

namespace PetTransport.Web.Extensions;

public static class EnumExtenstions
{
    /// <summary>
    /// Приведение значения перечисления в удобочитаемый формат.
    /// </summary>
    /// <remarks>
    /// Для корректной работы необходимо использовать атрибут [Description("Name")] для каждого элемента перечисления.
    /// </remarks>
    /// <param name="enumElement">Элемент перечисления</param>
    /// <returns>Название элемента</returns>
    public static string GetEnumDescription(this Enum enumElement)
    {
        Type type = enumElement.GetType();

        MemberInfo[] memInfo = type.GetMember(enumElement.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
        }

        return enumElement.ToString();
    }
    
    
}