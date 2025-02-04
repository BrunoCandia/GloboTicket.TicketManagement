using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace GloboTicket.TicketManagement.App.Pages
{
    public partial class EventDetails
    {
        [Inject]
        public IEventDataService EventDataService { get; set; } = default!;

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public EventDetailViewModel EventDetailViewModel { get; set; } = new EventDetailViewModel() { Date = DateTimeOffset.Now.AddDays(1) };

        public ObservableCollection<CategoryViewModel> Categories { get; set; } = new ObservableCollection<CategoryViewModel>();

        public string Message { get; set; } = string.Empty;

        public string SelectedCategoryId { get; set; } = string.Empty;

        [Parameter]
        public string EventId { get; set; }

        private Guid SelectedEventId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out SelectedEventId))
            {
                EventDetailViewModel = await EventDataService.GetEventById(SelectedEventId);
                SelectedCategoryId = EventDetailViewModel.CategoryId.ToString();
            }

            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(list);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            EventDetailViewModel.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedEventId == Guid.Empty)
            {
                response = await EventDataService.CreateEvent(EventDetailViewModel);
            }
            else
            {
                response = await EventDataService.UpdateEvent(EventDetailViewModel);
            }

            HandleResponse(response);
        }

        protected async Task DeleteEvent()
        {
            var response = await EventDataService.DeleteEvent(SelectedEventId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/eventoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/eventoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
