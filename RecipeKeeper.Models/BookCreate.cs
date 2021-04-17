using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class BookCreate
    {
      [Required]
      [MaxLength(100, ErrorMessage ="The book title is too long!")]
      [Display(Name ="Book Title")]
        public string BookName { get; set; }
       [MaxLength(100,ErrorMessage ="The author's name is too long!")]
        public string Author { get; set; }

        

    }
}
