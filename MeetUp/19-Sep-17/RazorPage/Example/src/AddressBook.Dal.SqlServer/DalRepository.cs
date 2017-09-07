using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBook.Dal.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Dal.SqlServer
{
    public class DalRepository : IDalRepository
    {
        private AddressBookContext _dbContext;
        public DalRepository(AddressBookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<IPhoneNumber> FindNumber(string number)
        {
            var data = (IQueryable<PhoneNumber>)_dbContext.PhoneNumber;
            if (number != null)
            {
                data = data.Where((p) => p.Number.Equals(number));
            }
            return data.Include(p=> p.Person).ToList().Cast<IPhoneNumber>();
        }

        public IEnumerable<IPhoneNumber> FindNumber()
        {
            return FindNumber(null);
        }

        public IEnumerable<IPerson> FindPerson(string condition)
        {
            var data = (IQueryable<Person>)_dbContext.Person;
            if (condition != null)
            {
                data = data.Where((p) => condition.Contains(p.Name) || condition.Contains(p.Surname));
            }
            return data.Include(p=>p.PhoneNumber).ToList().Cast<IPerson>();
        }

        public IEnumerable<IPerson> FindPerson()
        {
            return FindPerson(null);
        }
        
    }
}
