using Books_server.Models.Domain;

namespace Books_server.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable <Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> DeleteBookAsync(Guid id);
        Task<Book> UpdateBookAsync(Guid id,Book book);
    }

}
