using FluentValidation.Results;
using MediatR;

namespace APIShell.Domain.Core.Commands
{
    public abstract class Commands : IRequest
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }

    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
