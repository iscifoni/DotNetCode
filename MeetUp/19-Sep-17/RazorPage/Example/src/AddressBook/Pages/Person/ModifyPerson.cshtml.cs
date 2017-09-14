using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Dal.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBook.Pages.Person
{
    public class ModifyPersonModel : PageModel
    {
        private IDalRepository _dalRepository;

        [BindProperty]
        public ModifyItemPersonModel Input { get; set; }

        [FromRoute]
        public int PersonId { get; set; }

        public ModifyPersonModel(IDalRepository dalRepository)
        {
            if (dalRepository == null)
            {
                throw new ArgumentNullException(nameof(dalRepository));
            }

            _dalRepository = dalRepository;
        }
        public void OnGet()
        {
            Input = ModifyItemPersonModel.Create(_dalRepository.GetPersonById(PersonId));
        }

        public class ModifyItemPersonModel : IPerson
        {
            private IList<ModifyItemPhoneNumber> _phoneNumbers;
            [Required]
            public string Name { get; set; }
            public int IdPerson { get; set; }
            [Required]
            public string Surname { get; set; }
            public string Address { get; set; }

            public IList<ModifyItemPhoneNumber> PhoneNumbers { get => _phoneNumbers; set => _phoneNumbers = value; }
            IList<IPhoneNumber> IPerson.PhoneNumbers
            {
                get => new List<IPhoneNumber>(_phoneNumbers.Cast<IPhoneNumber>());
                set => _phoneNumbers = new List<ModifyItemPhoneNumber>(value.Cast<ModifyItemPhoneNumber>());
            }

            public static ModifyItemPersonModel Create(IPerson person)
            {
                return  new ModifyItemPersonModel()
                {
                    Address = person.Address,
                    IdPerson = person.IdPerson,
                    Name = person.Name,
                    Surname = person.Surname,
                    PhoneNumbers = new List<ModifyItemPhoneNumber>(person.PhoneNumbers.Cast<ModifyItemPhoneNumber>())
                };
            }
        }

        public class ModifyItemPhoneNumber : IPhoneNumber
        {
            public int Id { get; set; }
            public int IdPerson { get; set; }
            public string Number { get; set; }
            public NumberTypeEnum NumberType { get; set; }
            public IPerson Person { get; set; }
        }
    }
}