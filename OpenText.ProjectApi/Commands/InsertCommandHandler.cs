using MediatR;
using OpenText.ProjectApi.Infrastructure;
using OpenText.ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Commands
{
    public class InsertCommandHandler: IRequestHandler<InsertCommand, CommandResult>
    {
        private readonly IObjectRepository repository;
        private readonly IMediator mediator;

        public InsertCommandHandler(IObjectRepository repo, IMediator med)
        {
            repository = repo ?? throw new ArgumentNullException(nameof(repo));
            mediator = med ?? throw new ArgumentNullException(nameof(med));

        }

        public async Task<CommandResult> Handle(InsertCommand request, CancellationToken ct)
        {
            //await SysObjectRepo.Instance.FindAndSetNewValueAsync(request.oldpName, request.newpName, request.Id);
            SysObjectRepo.Instance.InsertNewObject(request.RequestToEntity(request, request.propertyname));
            return new CommandResult() { IsSuccess = true };
        }
    }
}
