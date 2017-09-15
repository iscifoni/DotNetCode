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
            IPerson response = new ModifyItemPersonModel();
            response = _dalRepository.GetPersonById(PersonId);
            Input = (ModifyItemPersonModel)ModifyItemPersonModel.Create<ModifyItemPersonModel>(response);
            
            //    var response = _dalRepository.GetPersonById(PersonId);
            //Input = response; 
        }

        public IActionResult OnPost()
        {
            _dalRepository.UpdatePerson(Input);
            return RedirectToPage("index");
        }

        public class ModifyItemPersonModel : PersonBase<ModifyItemPhoneNumber>
        {
            [Required]
            public override string Name { get; set; }
            public override int IdPerson { get; set; }
            [Required]
            public override string Surname { get; set; }
            public override string Address { get; set; }
        }

        public class ModifyItemPhoneNumber : PhoneNumberBase
        {
            //public int Id { get; set; }
            //public int IdPerson { get; set; }
            //public string Number { get; set; }
            //public NumberTypeEnum NumberType { get; set; }
            //public IPerson Person { get; set; }
        }
    }
}