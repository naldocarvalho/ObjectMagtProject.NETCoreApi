using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenText.ProjectApi.Models
{
    public interface IObjectRepository
    {
        void FindAndSetNewValue(string oldpName, string newpName, int id);
        string GetPropertyNameValue(int id);
        bool ObjectWithPropertyNameExist(string propertyname);
        void InsertNewObject(SysObjectEntity obj);
        SysObjectEntity FindByProperty(string pName);
        IEnumerable<SysObjectEntity> GetAll();
    }
}
