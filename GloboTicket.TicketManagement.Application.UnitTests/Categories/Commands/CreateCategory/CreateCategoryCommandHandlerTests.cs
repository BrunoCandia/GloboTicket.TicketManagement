using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Profiles;
using GloboTicket.TicketManagement.Application.UnitTests.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Application.UnitTests.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepository<Category>> _mockCategoryRepository;

        public CreateCategoryCommandHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.GetAllAsync();

            allCategories.Count.ShouldBe(5);
        }
    }
}
