﻿namespace Alpha.Travel.Application.Customers.Validators
{
    using Common.Validators;
    using Common.Enums;
    using FluentValidation;
    using Queries;

    public class GetCustomerPreviewQueryValidator : AbstractValidator<GetCustomerPreviewQuery>
    {
        public GetCustomerPreviewQueryValidator()
        {
            RuleFor(x => x.Id)
                .IsValidIntId()
                .WithErrorCode(Error.InvalidDestinationId.ToString());
        }
    }

    public class GetCustomersPreviewQueryValidator : AbstractValidator<GetCustomersPreviewQuery>
    {
        public GetCustomersPreviewQueryValidator()
        {
            RuleFor(x => x.Offset)
                .IsValidIntId()
                .WithErrorCode(Error.InvalidPageNumber.ToString())
                .WithMessage("Offset must be positive integer starting from 0.");

            RuleFor(x => x.Limit)
                .IsValidIntId()
                .WithErrorCode(Error.InvalidPageSize.ToString())
                .InclusiveBetween(1, 100)
                .WithMessage("Limit must be greater than 0 and less than 100.");
        }
    }
}