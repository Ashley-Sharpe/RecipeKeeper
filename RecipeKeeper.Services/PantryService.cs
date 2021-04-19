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
        public IEnumerable<PantryListItem> GetPantry()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Pantry
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e => new PantryListItem
                    {
                        PantryId = e.PantryId,
                        IngredientName = e.IngredientName,
                        InStock = e.InStock,
                        Location = e.Location,
                        Quantity = e.Quantity
                    }
                    );
                return query.ToArray();
            }
        }
        public PantryDetail GetPantryDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Pantry
                    .Single(e => e.PantryId == id && e.OwnerId == _userId);
                return new PantryDetail
                {
                    PantryId = entity.PantryId,
                    IngredientName = entity.IngredientName,
                    InStock = entity.InStock,
                    Location = entity.Location,
                    Quantity = entity.Quantity
                };
            }
        }
    }
}
