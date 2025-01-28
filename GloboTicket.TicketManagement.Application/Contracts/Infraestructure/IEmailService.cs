using GloboTicket.TicketManagement.Application.Models.Mail;

namespace GloboTicket.TicketManagement.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
