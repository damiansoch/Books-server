namespace Books_server.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        
    }
}
