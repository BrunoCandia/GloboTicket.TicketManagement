﻿using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryDto Category { get; set; } = new CreateCategoryDto();

        public CreateCategoryCommandResponse() : base()
        {
        }
    }
}