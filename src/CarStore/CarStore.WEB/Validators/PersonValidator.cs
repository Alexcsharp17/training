using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarStore.DAL.Entities;
using FluentValidation;

namespace CarStore.WEB.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        private const int MAX_NAME_LENGTH = 50;
        private const string PHONE_PATTERN = "[0-9]*$";
        public PersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(MAX_NAME_LENGTH);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(MAX_NAME_LENGTH);
            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(PHONE_PATTERN);
        }
    }
}
