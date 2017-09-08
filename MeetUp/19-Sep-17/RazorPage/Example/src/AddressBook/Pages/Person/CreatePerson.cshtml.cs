using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Dal.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBook.Pages.Person
{
    public class CreatePersonModel : PageModel
    {
        private IDalRepository _DalRepository;

        [BindProperty]
        public InsertPersonModel Input { get; set; }

        public CreatePersonModel(IDalRepository dalRepository)
        {
            if (dalRepository == null)
            {
                throw new ArgumentNullException(nameof(dalRepository));
            }

            _DalRepository = dalRepository;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            _DalRepository.AddPerson(Input);   
        }

        public void OnGetSalva()
        {
            _DalRepository.AddPerson((IPerson)Input);
        }
        public class InsertPersonModel : IPerson
        {
            private IList<InsertPhoneNumber> _phoneNumbers;
            [Required]
            public string Name { get; set; }
            public int IdPerson { get; set; }
            [Required]
            public string Surname { get; set; }
            public string Address { get; set; }

            public IList<InsertPhoneNumber> PhoneNumbers { get => _phoneNumbers; set => _phoneNumbers = value; }
            IList<IPhoneNumber> IPerson.PhoneNumbers
            {
                get => new List<IPhoneNumber>( _phoneNumbers.Cast<IPhoneNumber>());
                set => _phoneNumbers = new List<InsertPhoneNumber>(value.Cast<InsertPhoneNumber>());
            }
        
        }

        public class InsertPhoneNumber : IPhoneNumber
        {
            public int Id { get; set; }
            public int IdPerson { get; set; }
            public string Number { get; set; }
            public NumberTypeEnum NumberType { get; set; }
            public IPerson Person { get; set; }
        }
    }


}