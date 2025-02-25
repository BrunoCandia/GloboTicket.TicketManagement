using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using GloboTicket.TicketManagement.ArquitectureTests.Helpers;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace GloboTicket.TicketManagement.ArquitectureTests.Core;

public class LayerDependencyTests
{
    readonly IArchRule domainShouldNotDependOnApplication = Types()
        .That()
        .Are(LayerHelper.Domain)
        .Should()
        .NotDependOnAny(LayerHelper.Application)
        .Because("Domain should not depend on Application");

    readonly IArchRule domainShouldNotDependOnIdentity = Types()
        .That()
        .Are(LayerHelper.Domain)
        .Should()
        .NotDependOnAny(LayerHelper.Identity)
        .Because("Domain should not depend on Idenity");

    readonly IArchRule domainShouldNotDependOnInfraestructure = Types()
        .That()
        .Are(LayerHelper.Domain)
        .Should()
        .NotDependOnAny(LayerHelper.Infrastructure)
        .Because("Domain should not depend on Infrastructure");

    readonly IArchRule domainShouldNotDependOnInitialization = Types()
        .That()
        .Are(LayerHelper.Domain)
        .Should()
        .NotDependOnAny(LayerHelper.Initialization)
        .Because("Domain should not depend on Initialization");

    readonly IArchRule domainShouldNotDependOnPersistence = Types()
        .That()
        .Are(LayerHelper.Domain)
        .Should()
        .NotDependOnAny(LayerHelper.Persistence)
        .Because("Domain should not depend on Persistence");

    readonly IArchRule domainShouldNotDependOnAppUI = Types()
        .That()
        .Are(LayerHelper.Domain)
        .Should()
        .NotDependOnAny(LayerHelper.App)
        .Because("Domain should not depend on App UI");

    [Fact]
    public void DomainShouldNotDependOnApplication()
    {
        domainShouldNotDependOnApplication.Check(LayerHelper.Architecture);
    }

    [Fact]
    public void DomainShouldNotDependOnIdentity()
    {
        domainShouldNotDependOnIdentity.Check(LayerHelper.Architecture);
    }

    [Fact]
    public void DomainShouldNotDependOnInfrastructure()
    {
        domainShouldNotDependOnInfraestructure.Check(LayerHelper.Architecture);
    }

    [Fact]
    public void DomainShouldNotDependOnInitialization()
    {
        domainShouldNotDependOnInitialization.Check(LayerHelper.Architecture);
    }

    [Fact]
    public void DomainShouldNotDependOnPersistence()
    {
        domainShouldNotDependOnPersistence.Check(LayerHelper.Architecture);
    }

    [Fact]
    public void DomainShouldNotDependOnAppUI()
    {
        domainShouldNotDependOnAppUI.Check(LayerHelper.Architecture);
    }

    [Fact]
    public void DomainShouldNotDependOnExternal()
    {
        domainShouldNotDependOnApplication
            .And(domainShouldNotDependOnApplication)
            .And(domainShouldNotDependOnIdentity)
            .And(domainShouldNotDependOnInfraestructure)
            .And(domainShouldNotDependOnInitialization)
            .And(domainShouldNotDependOnPersistence)
            .And(domainShouldNotDependOnAppUI)
            .Check(LayerHelper.Architecture);
    }
}