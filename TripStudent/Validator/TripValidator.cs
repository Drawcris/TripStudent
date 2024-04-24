using FluentValidation;
using TripStudent.ViewModel;

namespace TripStudent.Validator
{
    public class TripValidator : AbstractValidator<TripViewModel>
    {
        public TripValidator() 
        {
            RuleFor(x => x.Destination).Length(1, 20).NotEmpty().WithMessage("Destination is requied");
            RuleFor(x => x.Price).NotEqual(0).WithMessage("Price cannot be 0");
            RuleFor(x => x.StartDate).GreaterThan(x => DateTime.Now).WithMessage("Start date must be valid");
            RuleFor(x => x.EndDate).GreaterThan(x => DateTime.Now).WithMessage("end date must be valid");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start date is requed");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("end date is requed");
        }
    }
}
