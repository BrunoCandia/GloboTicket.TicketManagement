﻿namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class EventNestedViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? Artist { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}
