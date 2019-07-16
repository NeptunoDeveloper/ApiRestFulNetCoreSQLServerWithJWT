using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjLibraryDemo.Models.DTO
{
    public class BookDTO
    {
        public decimal IdBook { get; set; }
        public decimal? IdAuthor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Genre { get; set; }
        public int? Year { get; set; }
        public string Publisher { get; set; }

        public virtual AuthorDTO Author { get; set; }
    }
}
