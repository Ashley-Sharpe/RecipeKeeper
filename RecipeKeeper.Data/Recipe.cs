using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string BookName { get; set; }
        public int? PageNumber { get; set; }
        [Required]
        [Display(Description ="Cooking or Baking recipe.")]
        public string RecipeType { get; set; }
        [Required]
        public string CuisineType { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
