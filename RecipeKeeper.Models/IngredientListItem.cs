﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
   public class IngredientListItem
    {
       
        public int IngredientId { get; set; }
        //[ForeignKey("Pantry")]
        public int PantryId { get; set; }
        //public virtual Pantry Pantry { get; set; }

        public string IngredientName { get; set; }

    }
}
