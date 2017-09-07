using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Dal.Abstract
{
    public interface IPerson
    {
        int IdPerson { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Address { get; set; }

        IList<IPhoneNumber> PhoneNumbers { get; set; }
    }
}
