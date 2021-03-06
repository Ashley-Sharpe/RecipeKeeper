using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Data
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Display(Name ="Title of the book")]
        public string BookName { get; set; }
        public string Author { get; set; }
        public Guid OwnerId { get; set; }
    }
}
