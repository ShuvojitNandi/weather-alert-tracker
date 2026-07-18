using FluentValidation;
using WeatherAlertTracker.Application.DTOs.Cities;

namespace WeatherAlertTracker.Application.Validators;

public class CreateCityRequestValidator 
    : AbstractValidator<CreateCityRequest>
{
    public CreateCityRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("City name is required and must be less than 100 characters");


        RuleFor(x => x.Province)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Province is required");


        RuleFor(x => x.Country)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Country is required");


        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude must be between -90 and 90");


        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude must be between -180 and 180");
    }
}