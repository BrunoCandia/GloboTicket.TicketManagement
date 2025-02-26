﻿using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class EventOverview
    {
        [Inject]
        public IEventDataService EventDataService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public ICollection<EventListViewModel> Events { get; set; } = new List<EventListViewModel>();

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        public HttpClient HttpClient { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            Events = await EventDataService.GetAllEvents();
        }

        protected void AddNewEvent()
        {
            NavigationManager.NavigateTo("/eventdetails");
        }

        protected async Task ExportEvents()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:7073/api/events/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }
    }
}
