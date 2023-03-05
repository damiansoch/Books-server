using Books_server.Data;
using Books_server.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books_server.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }


       

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }

       

        public async Task<Book> GetByIdAsync(Guid id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(book == null)
            {
                return null;
            }
            return book;
        }
        public async Task<Book> CreateBookAsync(Book book)
        {
            book.Id = Guid.NewGuid();
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBookAsync(Guid id)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return null;
            }
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(Guid id, Book book)
        {
            var existingBook = await context.Books.FirstOrDefaultAsync(b=>b.Id== id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;

            await context.SaveChangesAsync();

            return existingBook;
        }
    }
}
