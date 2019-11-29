using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Models
{
    public class UpdateEmployeeRequestValidation : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please ensure you have entered your {PropertyName}");
        }
    }
}
