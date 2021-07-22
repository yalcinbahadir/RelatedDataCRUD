using System;
using System.Collections.Generic;
using System.Text;

namespace RelatedData.Domein
{
    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } 
        public string EmailAddress { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Address { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }


    }
}
