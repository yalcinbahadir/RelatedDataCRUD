using System;
using System.Collections.Generic;
using System.Text;

namespace RelatedData.Domein
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
