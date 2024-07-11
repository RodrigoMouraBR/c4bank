using FinancialFlow.Domain.Entities;
using FluentValidation;

namespace FinancialFlow.Domain.Validations
{
    public class FinancialTransactionValidation : AbstractValidator<FinancialTransaction>
    {
        public FinancialTransactionValidation()
        {
            RuleFor(transaction => transaction.CustomerId)
           .NotEmpty().WithMessage("CustomerId must not be empty.")
           .Must(BeAValidGuid).WithMessage("CustomerId must be a valid GUID.");

            RuleFor(transaction => transaction.DateRef)
                .NotEmpty().WithMessage("Date must not be empty.");

            RuleFor(transaction => transaction.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(transaction => transaction.Description)
                .NotEmpty().WithMessage("Description must not be empty.");

            RuleFor(transaction => transaction.TransactionType)
                .IsInEnum().WithMessage("TransactionType must be a valid enum value.");
        }
        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
