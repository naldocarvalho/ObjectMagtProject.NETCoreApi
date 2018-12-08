using OpenText.ProjectApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenText.ProjectApi.Models;

namespace OpenText.ProjectApi.Queries
{
    public class QueriesServices: IObjectQueries
    {
        public IEnumerable<SysObjectEntity> GetObjects()
        {
            var query = SysObjectRepo.Instance.GetAll();

            return query.ToList();
        }

        public IEnumerable<string> GetListOfObjectMembers(int id)
        {
            var query = SysObjectRepo.Instance.FindById(id).GetAllMembers();

            return query.ToList();
        }

        public object GetpropertynameValue(string str, int id)
        {
            object query =  SysObjectRepo.Instance.FindById(id).GetpropertynameValue(str);

            return query;
        }

        public List<string> GetAllMembersOfObject(int id)
        {
            var query = SysObjectRepo.Instance.FindById(id).GetAllMembers();

            return query ;
        }
    }
}
