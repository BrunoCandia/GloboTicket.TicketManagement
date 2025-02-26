﻿using GloboTicket.TicketManagement.App.Components;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class TicketSales
    {

        [Inject]
        public IOrderDataService OrderDataService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public string SelectedMonth { get; set; }

        public string SelectedYear { get; set; }

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

        public List<string> YearList { get; set; } = new List<string>() { "2022", "2023", "2024" };

        private int? pageNumber = 1;

        private PaginatedList<OrdersForMonthListViewModel> paginatedList = new PaginatedList<OrdersForMonthListViewModel>();

        private IEnumerable<OrdersForMonthListViewModel> ordersList;

        protected async Task GetSales()
        {
            DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);

            var orders = await OrderDataService.GetPagedOrderForMonth(dt, pageNumber.Value, 5);

            paginatedList = new PaginatedList<OrdersForMonthListViewModel>(orders.OrdersForMonth.ToList(), orders.Count, pageNumber.Value, 5);

            ordersList = paginatedList.Items;

            StateHasChanged();
        }

        public async Task PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }

            pageNumber = newPageNumber;

            await GetSales();

            StateHasChanged();
        }
    }
}