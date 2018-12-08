using MediatR;
using OpenText.ProjectApi.Infrastructure;
using OpenText.ProjectApi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Commands
{
    public class SetPropertyCommandHandler: IRequestHandler<SetPropertyCommand, CommandResult>
    {
        private readonly IObjectRepository repository;
        private readonly IMediator mediator;

        public SetPropertyCommandHandler(IObjectRepository repo, IMediator med)
        {
            repository = repo ?? throw new ArgumentNullException(nameof(repo)) ;
            mediator = med ?? throw new ArgumentNullException(nameof(med));

        }     

        public async Task<CommandResult> Handle(SetPropertyCommand request, CancellationToken cancellationToken)
        {
            SysObjectRepo.Instance.FindAndSetNewValue(request.propertyname, request.newValue, request.Id);

            return new CommandResult() { IsSuccess = true };

        }
    }
}
