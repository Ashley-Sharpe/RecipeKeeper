using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class BookDetail

    {
        public int BookId { get; set; }
        [Display(Name = "Book Title")]
        public string BookName { get; set; }
        public string Author { get; set; }
    }
}
