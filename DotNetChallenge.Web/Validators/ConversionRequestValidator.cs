using System;
using DotNetChallenge.Web.Models;
using FluentValidation;

#pragma warning disable 1591

namespace DotNetChallenge.Web.Validators
{
    public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
    {
        public ConversionRequestValidator()
        {
            RuleFor(c => c.Name).NotNull()
                .Length(1, 64);
            RuleFor(c => c.Amount)
                .GreaterThanOrEqualTo(0)
                .LessThan((decimal) Math.Pow(10, 13));
        }
    }
}