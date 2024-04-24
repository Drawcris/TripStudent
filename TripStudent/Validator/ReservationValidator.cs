using FluentValidation;
using TripStudent.ViewModel;

namespace TripStudent.Validator
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator() 
        { 
            RuleFor(x => x.reservation_date).GreaterThan(x => DateTime.Now).NotEmpty().WithMessage("Date is invalid");
            RuleFor(x => x.reservation_date).NotEmpty().WithMessage("Start date is requed");
            RuleFor(x => x.status).IsInEnum().WithMessage("must be in enum"); 
            RuleFor(x => x.studentID).NotEmpty().WithMessage("studentID is required");
            RuleFor(x => x.tripID).NotEmpty().WithMessage("tripID is required");


        }
    }
}
