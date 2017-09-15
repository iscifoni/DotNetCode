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

        public IPerson AddPerson(IPerson person)
        {
            IPerson personToReturn;

            var localPerson = (Person)Person.Create<Person>(person);
            
            personToReturn = _dbContext.Person.Add(localPerson).Entity;

            _dbContext.SaveChanges();

            return localPerson;
        }

        public IEnumerable<IPerson> AddPerson(IEnumerable<IPerson> persons)
        {
            foreach (var person in persons)
            {
                yield return AddPerson(person);
            }
        }

        public IPhoneNumber AddPhoneNumber(IPhoneNumber phoneNumber)
        {
            var localPhoneNumber = new PhoneNumber()
            {
                Id = phoneNumber.Id,
                IdPerson = phoneNumber.IdPerson,
                Number = phoneNumber.Number,
                NumberType = phoneNumber.NumberType,
                Person = phoneNumber.Person
            };

            return (IPhoneNumber)_dbContext.PhoneNumber.Add(localPhoneNumber);
        }

        public IEnumerable<IPhoneNumber> AddPhoneNumber(IEnumerable<IPhoneNumber> phoneNumbers)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                yield return AddPhoneNumber(phoneNumber);
            }
        }

        public void DeletePerson(int personId)
        {
            var entityPhoneNumber = _dbContext.PhoneNumber.Where(p => p.IdPerson == personId).ToList();
            _dbContext.RemoveRange(entityPhoneNumber);

            var entityPerson = _dbContext.Person.Where(p => p.IdPerson == personId).Single();
            _dbContext.Remove(entityPerson);
            
            _dbContext.SaveChanges();
        }

        public IEnumerable<IPhoneNumber> FindNumber(string number)
        {
            var data = (IQueryable<PhoneNumber>)_dbContext.PhoneNumber;
            if (number != null)
            {
                data = data.Where((p) => p.Number.Equals(number));
            }
            return data.Include(p => p.Person).ToList().Cast<IPhoneNumber>();
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
            return data.Include(p => p.PhoneNumber).ToList().Cast<IPerson>();
        }

        public IEnumerable<IPerson> FindPerson()
        {
            return FindPerson(null);
        }

        public IPerson GetPersonById(int id)
        {
            return (Person)_dbContext.Person
                                .Where(p => p.IdPerson == id)
                                .Include(p => p.PhoneNumber)
                                .SingleOrDefault();
        }

        public IPhoneNumber GetPhoneNumberById(int id)
        {
            return (PhoneNumber)_dbContext.PhoneNumber
                                    .Where(p => p.Id == id)
                                    .SingleOrDefault();
        }

        public void UpdatePerson(IPerson person)
        {
            var localPerson = (Person)Person.Create<Person>(person);
            _dbContext.Person.Attach(localPerson).State = EntityState.Modified;

            var phoneNumbers = _dbContext.PhoneNumber.Where(p => p.IdPerson == localPerson.IdPerson).ToList();

            var phoneNumbersToDelete = phoneNumbers.FindAll(p => !localPerson.PhoneNumbers.Any(m => m.Id == p.Id));
            if (phoneNumbersToDelete.Count() > 0)
            {
                _dbContext.RemoveRange(phoneNumbersToDelete);
            }

            var phoneNumbersToAdd = localPerson.PhoneNumbers.Where(p => !phoneNumbers.Any(m => m.Id == p.Id)).ToList();
            if (phoneNumbersToAdd.Count() > 0)
            {
                _dbContext.AddRange(phoneNumbersToAdd);
            }
            
            _dbContext.SaveChanges();
        }
    }
}
