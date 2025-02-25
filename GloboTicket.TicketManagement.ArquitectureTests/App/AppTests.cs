using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using GloboTicket.TicketManagement.ArquitectureTests.Helpers;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace GloboTicket.TicketManagement.ArquitectureTests.App
{
    public class AppTests
    {
        [Fact]
        public void WebShouldNotDependOnAPI()
        {
            IArchRule appUIShouldNotDependOnAPI = Types()
                .That()
                .Are(LayerHelper.App)
                .Should()
                .NotDependOnAny(LayerHelper.Api)
                .Because("App UI and API should be independent of each other.");

            appUIShouldNotDependOnAPI.Check(LayerHelper.Architecture);

            //// Why is this failing?
        }
    }
}
