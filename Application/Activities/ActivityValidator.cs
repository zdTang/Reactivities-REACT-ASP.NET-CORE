using Domain;
using FluentValidation;

namespace Application.Activities
{
    // <Activity> is the type to be validated
    // validation happens during the DataModel Binding
    public  class ActivityValidator:AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
        }
    }
}
