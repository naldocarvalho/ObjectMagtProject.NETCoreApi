using OpenText.ProjectApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Models
{
    [DataContract]
    public class AddObjectRequest
    {     
        [DataMember]
        public dynamic coreObject { get; set; }      
   
        public SysObjectEntity RequestToEntity(dynamic dynObj)
        {
            return new SysObjectEntity( dynObj, "PropertyName To Be Set", UniqueId.Next());
        }

    }
}
