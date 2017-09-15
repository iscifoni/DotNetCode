using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Dal.Abstract
{
    public class PersonBase<T> : IPerson
        where T : PhoneNumberBase, new()
    {
        private IList<T> _phoneNumbers = new List<T>(); 

        public virtual int IdPerson { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<T> PhoneNumbers
        {
            get => _phoneNumbers;
            set => _phoneNumbers = value;
        }
        IList<IPhoneNumber> IPerson.PhoneNumbers
        {
            get => new List<IPhoneNumber>(PhoneNumbers.Cast<IPhoneNumber>());
            set => PhoneNumbers = new List<T>(value.Cast<T>());
        }
        
        public static PersonBase<T> Create<M>(IPerson person) where M : PersonBase<T>, new()
        {
            IList<T> personNumber = new List<T>();
            
            if (person.PhoneNumbers.Count != 0)
            {
                personNumber = (IList<T>)PhoneNumberBase.Create<T>(person.PhoneNumbers);
            }

            return new M()
            {
                Address = person.Address,
                IdPerson = person.IdPerson,
                Name = person.Name,
                PhoneNumbers = (IList<T>)personNumber,
                Surname = person.Surname
            };
        }
    }
}
