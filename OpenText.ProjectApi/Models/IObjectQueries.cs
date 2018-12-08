using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Models
{
    public interface IObjectQueries
    {
       // IEnumerable<string> GetListOfObjectMembers(int id);
        IEnumerable<SysObjectEntity> GetObjects();
        List<string> GetAllMembersOfObject(int id);
        object GetpropertynameValue(string str, int id);
    }
}
