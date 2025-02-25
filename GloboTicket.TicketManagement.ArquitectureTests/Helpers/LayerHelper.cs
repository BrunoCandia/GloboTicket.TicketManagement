using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Identity;
using GloboTicket.TicketManagement.Infraestructure;
using GloboTicket.TicketManagement.Persistence;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace GloboTicket.TicketManagement.ArquitectureTests.Helpers
{
    internal static class LayerHelper
    {
        //// TODO: review how to define the assemblies

        private static readonly System.Reflection.Assembly domainAssembly = typeof(AuditableEntity).Assembly;
        private static readonly System.Reflection.Assembly applicationAssembly = typeof(ApplicationServiceRegistration).Assembly;
        private static readonly System.Reflection.Assembly identityAssembly = typeof(IdentityServiceRegistration).Assembly;
        private static readonly System.Reflection.Assembly infrastructureAssembly = typeof(InfraestructureServiceRegistration).Assembly;
        private static readonly System.Reflection.Assembly initializationAssembly = typeof(GloboTicket.TicketManagement.Initialization.Program).Assembly;
        private static readonly System.Reflection.Assembly persistenceAssembly = typeof(PersistenceServiceRegistration).Assembly;
        private static readonly System.Reflection.Assembly apiAssembly = typeof(GloboTicket.TicketManagement.Api.StartupExtensions).Assembly;
        private static readonly System.Reflection.Assembly appAssembly = typeof(GloboTicket.TicketManagement.App.Pages.Home).Assembly;

        internal static readonly Architecture Architecture = new ArchLoader()
            .LoadAssemblies(
            domainAssembly,
                applicationAssembly,
                identityAssembly,
                infrastructureAssembly,
                initializationAssembly,
                persistenceAssembly,
                apiAssembly,
                appAssembly)
            .Build();

        internal static readonly IObjectProvider<IType> Domain = Types()
            .That()
            .ResideInAssembly(domainAssembly)
            .As("Domain");

        internal static readonly IObjectProvider<IType> Application = Types()
            .That()
            .ResideInAssembly(applicationAssembly)
            .As("Application");

        internal static readonly IObjectProvider<IType> Identity = Types()
            .That()
            .ResideInAssembly(identityAssembly)
            .As("Identity");

        internal static readonly IObjectProvider<IType> Infrastructure = Types()
            .That()
            .ResideInAssembly(infrastructureAssembly)
            .As("Infrastructure");

        internal static readonly IObjectProvider<IType> Initialization = Types()
            .That()
            .ResideInAssembly(initializationAssembly)
            .As("Initialization");

        internal static readonly IObjectProvider<IType> Persistence = Types()
            .That()
            .ResideInAssembly(persistenceAssembly)
            .As("Persistence");

        internal static readonly IObjectProvider<IType> Api = Types()
            .That()
            .ResideInAssembly(apiAssembly)
            .As("Api");

        internal static readonly IObjectProvider<IType> App = Types()
            .That()
            .ResideInAssembly(appAssembly)
            .As("App");

        ////private static System.Reflection.Assembly coreAssembly = typeof(IOrderRepository).Assembly;
        ////private static System.Reflection.Assembly blazorAdminAssembly = typeof(HttpService).Assembly;
        ////private static System.Reflection.Assembly blazorSharedAssembly = typeof(ICatalogItemService).Assembly;
        ////private static System.Reflection.Assembly infrastructureAssembly = typeof(FileItem).Assembly;
        ////private static System.Reflection.Assembly publicAPIAssembly = typeof(BaseMessage).Assembly;
        ////private static System.Reflection.Assembly webAssembly = typeof(GetOrderDetails).Assembly;

        ////internal static readonly Architecture Architecture = new ArchLoader()
        ////    .LoadAssemblies(
        ////        coreAssembly,
        ////        blazorAdminAssembly,
        ////        blazorSharedAssembly,
        ////        infrastructureAssembly,
        ////        publicAPIAssembly,
        ////        webAssembly)
        ////    .Build();

        ////internal static readonly IObjectProvider<IType> CoreLayer = Types()
        ////    .That()
        ////    .ResideInAssembly(coreAssembly)
        ////    .As("Core Layer");

        ////internal static readonly IObjectProvider<IType> BlazorAdminLayer = Types()
        ////    .That()
        ////    .ResideInAssembly(blazorAdminAssembly)
        ////    .As("BlazorAdmin Layer");

        ////internal static readonly IObjectProvider<IType> BlazorSharedLayer = Types()
        ////    .That()
        ////    .ResideInAssembly(blazorSharedAssembly)
        ////    .As("BlazorShared Layer");

        ////internal static readonly IObjectProvider<IType> InfrastructureLayer = Types()
        ////    .That()
        ////    .ResideInAssembly(infrastructureAssembly)
        ////    .As("Infrastructure Layer");

        ////internal static readonly IObjectProvider<IType> PublicAPILayer = Types()
        ////    .That()
        ////    .ResideInAssembly(publicAPIAssembly)
        ////    .As("API Layer");

        ////internal static readonly IObjectProvider<IType> WebLayer = Types()
        ////    .That()
        ////    .ResideInAssembly(webAssembly)
        ////    .As("Web Layer");
    }
}
