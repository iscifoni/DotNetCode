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

        public class InsertPersonModel : IPerson
        {
            [Required]
            public string Name { get; set; }
            public int IdPerson { get; set; }
            [Required]
            public string Surname { get; set; }
            public string Address { get; set; }

            public IList<IPhoneNumber> PhoneNumbers { get; set; }
        }
    }
    
   
}