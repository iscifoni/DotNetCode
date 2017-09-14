using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AddressBook.Dal.Abstract;

namespace AddressBook.Dal.SqlServer
{
    public class Person : IPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public IList<IPhoneNumber> PhoneNumbers
        {
            get => new List<IPhoneNumber>(PhoneNumber.Cast<IPhoneNumber>());
            set => PhoneNumber = value.Select(p => AddressBook.Dal.SqlServer.PhoneNumber.Create(p)).ToList();
        }
        
        internal IList<PhoneNumber> PhoneNumber { get; set; }
    }
}
