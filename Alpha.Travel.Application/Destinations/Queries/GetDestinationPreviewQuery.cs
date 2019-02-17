﻿namespace Alpha.Travel.Application.Destinations.Queries
{
    using MediatR;
    using Destinations.Models;

    public class GetDestinationPreviewQuery : IRequest<DestinationPreviewDto>
    {
        public int Id { get; set; }
    }
}