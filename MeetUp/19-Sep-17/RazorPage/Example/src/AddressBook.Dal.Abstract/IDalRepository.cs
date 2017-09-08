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

        IPerson AddPerson(IPerson person);
        IEnumerable<IPerson> AddPerson(IEnumerable<IPerson> person);
        IPhoneNumber AddPhoneNumber(IPhoneNumber phoneNumber);
        IEnumerable<IPhoneNumber> AddPhoneNumber(IEnumerable<IPhoneNumber> phoneNumber);

    }
}
