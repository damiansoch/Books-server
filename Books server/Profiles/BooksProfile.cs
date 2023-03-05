using AutoMapper;

namespace Books_server.Profiles
{
    public class BooksProfile:Profile
    {
        public BooksProfile()
        {
            CreateMap<Models.Domain.Book, Models.DTO.Book>().ReverseMap();
            CreateMap<Models.Domain.Book, Models.DTO.AddBookRequest>().ReverseMap();
            CreateMap<Models.Domain.Book, Models.DTO.UpdateBookRequest>().ReverseMap();
        }
    }
}
