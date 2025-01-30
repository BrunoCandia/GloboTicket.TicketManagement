namespace GloboTicket.TicketManagement.App.ViewModels
{
    public class OrdersForMonthListViewModel
    {
        public Guid Id { get; set; }
        public int OrderTotal { get; set; }
        public DateTimeOffset OrderPlaced { get; set; }
    }
}
