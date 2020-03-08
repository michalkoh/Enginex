using FluentValidation;

namespace Enginex.Application.Email.Commands
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .MaximumLength(40)
                .EmailAddress();

            RuleFor(c => c.Name)
                .MaximumLength(40)
                .NotEmpty();

            RuleFor(c => c.Subject)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Message)
                .MaximumLength(4000)
                .NotEmpty();
        }
    }
}
