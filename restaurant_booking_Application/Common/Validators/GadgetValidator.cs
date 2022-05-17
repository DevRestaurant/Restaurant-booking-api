using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using restaurant_booking_Application.GadgetProduct;

namespace restaurant_booking_Application.Common.Validators
{
    class GadgetValidator : AbstractValidator<AddGadget.Query>
    {
        public GadgetValidator()
        {
            RuleFor(gadget => gadget.ProductName)
                .NotNull().WithMessage("Product name cannot be null")
                .NotEmpty().WithMessage("Product name cannot be null");
            RuleFor(gadget => gadget.ProductCategory)
                .NotNull().WithMessage("Product name cannot be null")
                .NotEmpty().WithMessage("Product name cannot be null");
            RuleFor(gadget => gadget.ProductDescription)
                .NotNull().WithMessage("Product name cannot be null")
                .NotEmpty().WithMessage("Product name cannot be null");
            RuleFor(gadget => gadget.ProductTitle)
                .NotNull().WithMessage("Product name cannot be null")
                .NotEmpty().WithMessage("Product name cannot be null");
            RuleFor(gadget => gadget.ProductPrice)
                .NotEmpty().WithMessage("Price cannot be empty")
                .GreaterThan(0);

        }
    }
}
