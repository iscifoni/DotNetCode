using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AddressBook.Dal.Abstract;

namespace AddressBook.Dal.SqlServer
{
    public class Person : PersonBase<PhoneNumber>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int IdPerson { get; set; }
        public override string Name { get; set; }
        public override string Surname { get; set; }
        public override string Address { get; set; }

        [NotMapped]
        public override IList<PhoneNumber> PhoneNumbers
        {
            get => PhoneNumber;
            set => PhoneNumber = value;
        }
        
        internal IList<PhoneNumber> PhoneNumber { get; set; }
    }
}
