using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Dal.Abstract
{
    public class PhoneNumberBase : IPhoneNumber
    {
        public virtual int Id { get; set; }
        public virtual int IdPerson { get; set; }
        public virtual string Number { get; set; }
        public virtual NumberTypeEnum NumberType { get; set; }
        public virtual IPerson Person { get; set; }

        public static T Create<T>(IPhoneNumber phoneNumber) where T : PhoneNumberBase, new()
        {
            return new T()
            {
                Id = phoneNumber.Id,
                IdPerson = phoneNumber.IdPerson,
                Number = phoneNumber.Number,
                NumberType = phoneNumber.NumberType
            };
        }

        public static IList<T> Create<T>(IList<IPhoneNumber> phoneNumbers) where T : PhoneNumberBase, new()
        {
            return phoneNumbers.Select(p => Create<T>(p)).ToList<T>();
        }
    }
}
