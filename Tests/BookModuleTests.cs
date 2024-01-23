using Application.Dtos;
using Application.Interfaces;
using Application.UseCases;
using Domain;
using Moq;
using Xunit;

namespace Tests;

public class BookModuleTests
{
    [Fact]
    public async void MustReturnSuccessMessageOnCreateBook()
    {
        var response = new ResponseDto { Message = "Book registered successfully", Type = ResponseType.Success };

        var bookPersistence = new Mock<IBookPersistence>();
        bookPersistence.Setup(x => x.Create(It.IsAny<Book>())).ReturnsAsync(true);

        var bookModule = new BookModule(bookPersistence.Object);

        var bookDto = new BookDto
        {
            Code = "5506",
            Title = "Teste",
            Author = "joao",
            Genre = "Aventura",
            Publisher = "Abril"
        };

        await bookModule.Create(bookDto);

        Assert.Equal(response.Type, bookModule.Response.Type);
        Assert.Equal(response.Message, bookModule.Response.Message);
    }
}