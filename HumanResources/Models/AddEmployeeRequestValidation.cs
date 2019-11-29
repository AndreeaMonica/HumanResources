using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Models
{
    public class AddEmployeeRequestValidation: AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of employee could not be null");
        }
    }
}
