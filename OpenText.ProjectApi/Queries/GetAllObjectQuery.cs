using OpenText.ProjectApi.Infrastructure;
using OpenText.ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Queries
{
    public class GetAllObjectQuery
    {
        public async Task<IEnumerable<SysObjectEntity>> GetObjectsAsync()
        {
            var query = SysObjectRepo.Instance.GetAll();

            return query.ToList();
        }
    }
}
