using FluentValidation;

namespace Enginex.Application.Request.Commands
{
    public class SendRequestCommandValidator : AbstractValidator<SendRequestCommand>
    {
        public SendRequestCommandValidator()
        {
            RuleFor(c => c.From)
                .NotEmpty()
                .MaximumLength(40)
                .EmailAddress();

            RuleFor(c => c.Message)
                .MaximumLength(4000)
                .NotEmpty();
        }
    }
}
