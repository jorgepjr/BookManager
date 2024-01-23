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
    }
}
