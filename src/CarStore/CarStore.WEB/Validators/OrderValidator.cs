using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarStore.DAL.Entities;
using FluentValidation;

namespace CarStore.WEB.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        private const int MAX_ORDER_TIME = 2;
        public OrderValidator()
        {
            RuleFor(x => x.CarID)
                .NotEmpty();
            RuleFor(x => x.PersonId)
                .NotEmpty();
            RuleFor(x => x.OrderDate)
                .NotEmpty()
                .ExclusiveBetween(DateTime.UtcNow, DateTime.UtcNow.AddYears(MAX_ORDER_TIME));
        }
    }
}
