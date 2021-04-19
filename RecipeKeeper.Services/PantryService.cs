using RecipeKeeper.Data;
using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.service
{
    public class PantryService
    {
        private readonly Guid _userId;
        public PantryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePantry(PantryCreate model)
        {
            var entity = new Pantry()
            {
                OwnerId = _userId,
                IngredientName = model.IngredientName,
                InStock = model.InStock,
                Location = model.Location,
                Quantity = model.Quantity

            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Pantry.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
