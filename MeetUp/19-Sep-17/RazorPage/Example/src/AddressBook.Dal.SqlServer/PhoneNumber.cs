using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AddressBook.Dal.Abstract;

namespace AddressBook.Dal.SqlServer
{
    public class PhoneNumber : PhoneNumberBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public override int IdPerson { get; set; }
        public override string Number { get; set; }
        public override NumberTypeEnum NumberType { get; set; }

        [NotMapped]
        public override IPerson Person
        {
            get => InternalPerson;
            set { }
        }

        internal Person InternalPerson { get; set; }
    }
}
