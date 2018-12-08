using MediatR;
using OpenText.ProjectApi.Infrastructure;
using OpenText.ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Commands
{
    [DataContract]
    public class SetPropertyCommand: IRequest<CommandResult>
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string propertyname { get; private set; }
        [DataMember]
        public string newValue { get; private set; }
       
    }
}
