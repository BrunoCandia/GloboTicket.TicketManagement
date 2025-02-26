﻿namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class EventListViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }
        public string? ImageUrl { get; set; }
    }
}
