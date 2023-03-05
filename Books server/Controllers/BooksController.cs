using AutoMapper;
using Books_server.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        //-------------------------------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var allBooks =  await bookRepository.GetAllAsync();

            var allBooksDTO = mapper.Map<List<Models.DTO.Book>>(allBooks);

            return Ok(allBooksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetBookByIdAsync")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] Guid id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if(book == null)
            {
                return BadRequest("Book not found in database");
            }

            var bookDTO = mapper.Map<Models.DTO.Book>(book);

            return Ok(bookDTO);    
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsync(Models.DTO.AddBookRequest addBookRequest)
        {
            var book = mapper.Map<Models.Domain.Book>(addBookRequest);

            var response = await bookRepository.CreateBookAsync(book);

            if(response == null)
            {
                return BadRequest(response);
            }

            var bookDTO = mapper.Map<Models.DTO.Book>(response);

            return CreatedAtAction(nameof(GetBookByIdAsync), new { id = bookDTO.Id }, response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute]Guid id)
        {
            var response = await bookRepository.DeleteBookAsync(id);

            if (response == null)
            {
                return NotFound("Book not found in the database");
            }
            var bookDTO = mapper.Map<Models.DTO.Book>(response);

            return Ok(bookDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute]Guid id, [FromBody]Models.DTO.UpdateBookRequest updateBookRequest)
        {
            var book = mapper.Map<Models.Domain.Book>(updateBookRequest);

            var response = await bookRepository.UpdateBookAsync(id, book);

            if (response == null)
            {
                return BadRequest("Book not found");
            }

            var updatedBookDTO = mapper.Map<Models.DTO.Book>(response);

            return Ok(updatedBookDTO);
        }
        
    }
}
