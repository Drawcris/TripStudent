using FluentValidation;
using TripStudent.ViewModel;

namespace TripStudent.Validator
{
    public class StudentValidator : AbstractValidator<StudentViewModel>
    {
        public StudentValidator() 
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.lastname).NotEmpty().WithMessage("lastname is required");
            RuleFor(x => x.email).EmailAddress().WithMessage("email is invalid");
            RuleFor(x => x.email).NotEmpty().WithMessage("email is requied");
        }
    }
}
