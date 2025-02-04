using GloboTicket.TicketManagement.Api.Middleware;
using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Identity;
using GloboTicket.TicketManagement.Identity.Models;
using GloboTicket.TicketManagement.Infraestructure;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddApplicationServices();
            webApplicationBuilder.Services.AddInfraestructureServices(webApplicationBuilder.Configuration);
            webApplicationBuilder.Services.AddPersistenceServices(webApplicationBuilder.Configuration);
            webApplicationBuilder.Services.AddIdentityServices(webApplicationBuilder.Configuration);

            webApplicationBuilder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            webApplicationBuilder.Services.AddControllers();

            webApplicationBuilder.Services.AddHttpContextAccessor();

            webApplicationBuilder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "open",
                    policy => policy.WithOrigins([webApplicationBuilder.Configuration["ApiUrl"] ?? "https://localhost:7073", webApplicationBuilder.Configuration["BlazorUrl"] ?? "http://localhost:7080"])
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(policy => true)
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            webApplicationBuilder.Services.AddEndpointsApiExplorer();

            webApplicationBuilder.Services.AddSwaggerGen();

            return webApplicationBuilder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication webApplication)
        {
            webApplication.MapIdentityApi<ApplicationUser>();

            webApplication.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.Ok();
            });

            webApplication.UseCors("open");

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket.TicketManagement.Api v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            webApplication.UseAuthentication();

            webApplication.UseAuthorization();

            webApplication.UseMiddleware<ExceptionHandlerMiddleware>();

            webApplication.UseHttpsRedirection();

            webApplication.MapControllers();

            return webApplication;
        }
    }
}
