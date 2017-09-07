using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Dal.Abstract
{
    public interface IDalRepository
    {
        IEnumerable<IPerson> FindPerson(string condition);
        IEnumerable<IPerson> FindPerson();
        IEnumerable<IPhoneNumber> FindNumber(string number);
        IEnumerable<IPhoneNumber> FindNumber();

    }
}
