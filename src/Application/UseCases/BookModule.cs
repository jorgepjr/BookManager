using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Domain;

namespace Application.UseCases
{
    public class BookModule : IBookModule
    {
        private readonly IBookPersistence _bookPersistence;

        public ResponseDto Response { get; set; } = new();

        public BookModule(IBookPersistence bookPersistence)
        {
            _bookPersistence = bookPersistence;
        }


        public async Task Create(BookDto bookDto)
        {
            var book = new Book(
                bookDto.Code,
                bookDto.Title,
                bookDto.Author,
                bookDto.Year,
                bookDto.Genre,
                bookDto.Publisher);

            try
            {
                var successfulRequest = await _bookPersistence.Create(book);

                if (successfulRequest)
                {
                    Response = new ResponseDto { Type = ResponseType.Success, Message = "Book registered successfully" };

                }
            }
            catch (Exception ex)
            {
                Response = new ResponseDto { Type = ResponseType.Error, Message = ex.Message };
            }
        }

        public async Task<BookDto> GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                Response = new ResponseDto { Type = ResponseType.Error, Message = "The code is null" };
                return new BookDto { };
            }

            var book = await _bookPersistence.GetByCode(code);

            if (book is null)
            {
                Response = new ResponseDto { Type = ResponseType.Info, Message = "Book not found" };
                return new BookDto { };
            }

            var bookResponse = new BookDto
            {
                Code = book.Code,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Genre = book.Genre,
                Publisher = book.Publisher,
            };

            return bookResponse;
        }

        public async Task<IEnumerable<BookDto>> Filter(int page, int itemByPage)
        {
            var books = await _bookPersistence.Filter(page, itemByPage);

            if(books is null)
            {
                return Enumerable.Empty<BookDto>();
            }

            var booksResponse = books.Select(x=> new BookDto
            {
                Code =x.Code,
                Title = x.Title,
                Author = x.Author,
                Year = x.Year,
                Genre = x.Genre,
                Publisher = x.Publisher,
            });

            return booksResponse;
        }
    }
}