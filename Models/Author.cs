using System;
using System.Collections.Generic;

namespace PrjLibraryDemo.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public decimal IdAuthor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
