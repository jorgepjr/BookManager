using Application.Dtos;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Domain;

namespace Application.UseCases.Modules
{
    public class BookModule : IBookModule
    {
        private readonly IBookPersistence _bookPersistence;

        public ResponseDto Response { get; set; } = new();

        public BookModule(IBookPersistence bookPersistence)
        {
            _bookPersistence = bookPersistence;
        }


        public async Task<BookDto> Create(BookDto bookDto)
        {
            var response = await _bookPersistence.GetByCode(bookDto.Code);

            if(response is not null)
            {
                Response = new ResponseDto { Type = ResponseType.Error, Message = "code already exists" };
                return new BookDto { };
            }

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
                    return new BookDto { Id = book.Id, Code = book.Code };

                }
            }
            catch (Exception ex)
            {
                Response = new ResponseDto { Type = ResponseType.Error, Message = ex.Message };
            }

            return new BookDto { };
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
                Id = book.Id,
                Code = book.Code,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                Genre = book.Genre,
                Publisher = book.Publisher,
            };

            Response = new ResponseDto { Type = ResponseType.Success };
            return bookResponse;
        }

        public async Task<IEnumerable<BookDto>> Filter(int page, int itemByPage)
        {
            var books = await _bookPersistence.Filter(page, itemByPage);

            if (books is null)
            {
                return Enumerable.Empty<BookDto>();
            }

            var booksResponse = books.Select(x => new BookDto
            {
                Id = x.Id,
                Code = x.Code,
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