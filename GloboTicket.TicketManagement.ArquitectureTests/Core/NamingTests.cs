using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.ArquitectureTests.Helpers;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace GloboTicket.TicketManagement.ArquitectureTests.Core
{
    public class NamingTests
    {
        [Fact]
        public void IRepositoryImplementers_Should_IncludeRepositoryInName()
        {
            IArchRule repositoryImplementersNameShouldIncludeRepository = Classes()
                .That()
                .AreAssignableTo(typeof(IRepository<>))
                ////.AreAssignableTo("GloboTicket.TicketManagement.Application.Contracts.Persistence*", true)
                .Should()
                .HaveNameContaining("Repository");

            repositoryImplementersNameShouldIncludeRepository.Check(LayerHelper.Architecture);
        }

        [Fact]
        public void InterfacesWithRepositoryName_Should_ImplementIRepository()
        {
            IArchRule repositories = Interfaces()
                .That()
                .HaveNameEndingWith("Repository")
                .Should()
                .ImplementInterface(typeof(IRepository<>));

            repositories.Check(LayerHelper.Architecture);
        }
    }
}
