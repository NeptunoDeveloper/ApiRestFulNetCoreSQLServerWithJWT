using System;
using System.Collections.Generic;

namespace PrjLibraryDemo.Models.DTO
{
    public class AuthorDTO
    {
        public decimal IdAuthor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BookDTO> Books { get; set; }
    }
}
