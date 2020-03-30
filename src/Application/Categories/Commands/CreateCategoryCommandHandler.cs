using System;
using Enginex.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enginex.Application.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository repository;

        public CreateCategoryCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
