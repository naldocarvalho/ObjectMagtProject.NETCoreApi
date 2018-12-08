using OpenText.ProjectApi.Models;
using OpenText.ProjectApi.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OpenText.ProjectApi.Infrastructure
{
    /// <summary>
    /// The Repository
    /// </summary>
    public class SysObjectRepo: IObjectRepository
    {       
        private static readonly Lazy<SysObjectRepo> LazyInstance = new Lazy<SysObjectRepo>(() => new SysObjectRepo());
        
        public static SysObjectRepo Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }
       
        public SysObjectRepo()
        {
            this.sysObjects = new Dictionary<int, SysObjectEntity>();
        }

        private readonly IDictionary<int, SysObjectEntity> sysObjects;
        private IsAlphanumeric validator = new IsAlphanumeric();


        public void InsertNewObject(SysObjectEntity obj)
        {
            if (null == obj)
                throw new ArgumentNullException();

            sysObjects.Add(obj.Id, obj);
        }

        public string GetPropertyNameValue(int id)
        {
            return FindById(id).propertyname;
            throw new KeyNotFoundException();
        }


        public SysObjectEntity FindById(int id)
        {
            if (sysObjects.ContainsKey(id))
                return sysObjects[id];

            throw new KeyNotFoundException();
        }

        public SysObjectEntity FindByProperty(string pName)
        {

            foreach (var pair in sysObjects)
            {
                if ((pName == pair.Value.propertyname)) return pair.Value;
            }

            throw new KeyNotFoundException();
        }
        public void FindAndSetNewValue(string propertyname, string newValue, int id)
        {
           
                FindById(id).SetpropertynameValue(propertyname,newValue);
        

            throw new ValidationException();
        }


        public IEnumerable<SysObjectEntity> GetAll()
        {
            return this.sysObjects.Values.ToList();
        }


        public bool ObjectWithPropertyNameExist(string propertyname)
        {
            bool result = false;
            foreach (var pair in sysObjects)
            {
                if ((propertyname == pair.Value.propertyname)) result = true;
            }

            return result;
        }
    }
}
