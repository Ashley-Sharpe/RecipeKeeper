using RecipeKeeper.Data;
using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.service
{
    public class BookService
    {
        private readonly Guid _userId;

        public BookService(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateBook(BookCreate model)
        {
            var entity = new Book()
            {
                OwnerId = _userId,
                BookName = model.BookName,
                Author = model.Author
            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Books
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e =>
                    new BookListItem
                    {
                        BookId = e.BookId,
                        Author = e.Author,
                        BookName = e.BookName
                    }

                    );
                return query.ToArray();
            }
        }
        public BookDetail GetBookById(int id)
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Books
                            .Single(e => e.BookId == id && e.OwnerId == _userId);
                    return
                        new BookDetail
                        {
                            BookId = entity.BookId,
                            BookName = entity.BookName,
                            Author = entity.Author
                            
                        };
                }
            }
        }

    }


