using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Dal.Abstract
{
    public interface IPhoneNumber
    {
        int Id { get; set; }
        int IdPerson { get; set; }
        string Number { get; set; }
        NumberTypeEnum NumberType { get; set; }

        IPerson Person { get; set; }
    }
}
