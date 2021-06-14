using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CvtTest.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Other { get; set; }

        public static string[] GetPropertiesNames() // получаем названия всех полей контакта
        {
            var propArray = typeof(Contact).GetProperties();
            var result = new List<string>();
            foreach(var prop in propArray)
                result.Add(prop.Name);
            return result.ToArray();
        }

        public void Copy(Contact toContact) // переписываем все свойства this в contact
        {
            PropertyInfo[] toObjectProperties = toContact.GetType().GetProperties(); // получаем все публичные свойства объекта
            foreach (PropertyInfo propTo in toObjectProperties) // пробегаемся по свойствам
            {
                PropertyInfo propFrom = GetType().GetProperty(propTo.Name);
                if (propFrom != null && propFrom.CanWrite)
                    propTo.SetValue(toContact, propFrom.GetValue(this, null), null); // переписываем свойство из this в toContact
            }
        }
    }
}
