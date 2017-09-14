using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AddressBook.Dal.Abstract;

namespace AddressBook.Dal.SqlServer
{
    public class PhoneNumber : IPhoneNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPerson { get; set; }
        public string Number { get; set; }
        public NumberTypeEnum NumberType { get; set; }

        [NotMapped]
        public IPerson Person
        {
            get => (IPerson)InternalPerson;
            set { }
        }

        internal Person InternalPerson { get; set; }

        public  static PhoneNumber Create(IPhoneNumber p)
        {
            return new PhoneNumber()
            {
                Id = p.Id,
                IdPerson = p.IdPerson,
                Number = p.Number,
                NumberType = p.NumberType
            };
        }
    }
}
