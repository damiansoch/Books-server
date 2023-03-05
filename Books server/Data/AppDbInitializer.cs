using Books_server.Models.Domain;

namespace Books_server.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Philosopher's Stone",
                        },
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Chamber of Secrets",
                        },
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Prisoner of Azkaban",
                        },
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Goblet of Fire",
                        },
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Order of the Phoenix",
                        },
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Half-Blood Prince",
                        },
                        new Book()
                        {
                            Id = Guid.NewGuid(),
                            Title = "Harry Potter - Deathly Hallows",
                        },

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
