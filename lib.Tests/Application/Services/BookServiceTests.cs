using lib.Application.Repositories.Contracts;
using lib.Application.Services;
using lib.Domain.Entities;
using Moq;

namespace lib.Tests.Application.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private BookService _sut;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _sut = new BookService(_bookRepositoryMock.Object);
        }

        [Test]
        public async Task LendBook_NotExistentBook_NoUpdates()
        {
            var title = "title";

            _bookRepositoryMock
                .Setup(repo => repo.GetBookWithCopiesAndTickets(title))
                .ReturnsAsync((Book)null);

            await _sut.LendBook(title);

            _bookRepositoryMock.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Never());
        }

        [Test]
        public async Task LendBook_BookWithoutCopies_NoUpdates()
        {
            var title = "title";

            _bookRepositoryMock
                .Setup(repo => repo.GetBookWithCopiesAndTickets(title))
                .ReturnsAsync(new Book { Copies = new List<Copy>() });

            await _sut.LendBook(title);

            _bookRepositoryMock.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Never());
        }

        [Test]
        public async Task LendBook_BookWithCopies_Success()
        {
            var title = "title";

            _bookRepositoryMock
                .Setup(repo => repo.GetBookWithCopiesAndTickets(title))
                .ReturnsAsync(new Book 
                { 
                    Copies = new List<Copy>() 
                    { 
                        new Copy { IsBorrowed = false } 
                    } 
                }) ;

            await _sut.LendBook(title);

            _bookRepositoryMock.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Once());
        }

        [Test]
        public async Task CreateBook_ValidData_Success()
        {
            await _sut.CreateBook(It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>());

            _bookRepositoryMock.Verify(repo => repo.InsertBook(It.IsAny<Book>()), Times.Once());

        }

        [Test]
        public async Task ReturnBook_NotExistentBook_NoUpdates()
        {
            var title = "title";

            _bookRepositoryMock
                .Setup(repo => repo.GetBookWithCopiesAndTickets(title))
                .ReturnsAsync((Book)null);

            await _sut.ReturnBook(title);

            _bookRepositoryMock.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Never());
        }

        [Test]
        public async Task ReturnBook_NotExistentClient_NoUpdates()
        {
            var title = "title";

            _bookRepositoryMock
                .Setup(repo => repo.GetBookWithCopiesAndTickets(title))
                .ReturnsAsync(new Book
                {
                    Copies = new List<Copy>()
                    {
                        new Copy { Id = 1, IsBorrowed = false }
                    }
                });

            await _sut.ReturnBook(title);

            _bookRepositoryMock.Verify(repo => repo.UpdateBook(It.IsAny<Book>()), Times.Never());
        }
    }
}
