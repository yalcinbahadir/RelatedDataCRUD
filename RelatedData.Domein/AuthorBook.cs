using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatedData.Domein
{
    //If you have no pay load, you don't need to implement this class.
    public class AuthorBook
    {
        public int BookId { get; set; }      
        public int AuthorId { get; set; }   
        //Payload: See configuration in dbcontext class.
        public DateTime CreatedAt { get; set; }
    }
}
