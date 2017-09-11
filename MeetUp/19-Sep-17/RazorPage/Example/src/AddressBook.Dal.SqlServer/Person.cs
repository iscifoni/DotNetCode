using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            get => (IList<IPhoneNumber>)PhoneNumber;
            set => PhoneNumber = value as IList<PhoneNumber>;
        }
        internal IList<PhoneNumber> PhoneNumber { get; set; }
    }
}
