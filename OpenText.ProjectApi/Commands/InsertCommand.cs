using MediatR;
using OpenText.ProjectApi.Infrastructure;
using OpenText.ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Commands
{
    [DataContract]
    public class InsertCommand: IRequest<CommandResult>
    {
        [DataMember(Order= 1)]     
        public string propertyname { get; set; }

        [DataMember(Order=2)]
        public dynamic UserObject { get; set; }

        public SysObjectEntity RequestToEntity(dynamic dynObj, string propertyname)
        {
            return new SysObjectEntity(dynObj, propertyname, UniqueId.Next());
        }

    }
}
