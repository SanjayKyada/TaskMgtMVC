using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInMemory
{
    public class DynRepository<T> where T : AbsBase
    {
        ObjectCache cacheRepository = MemoryCache.Default;
        List<T> dynObjList;
        string Name;

        //Assigning basic properties 
        public DynRepository()
        {
            Name = typeof(T).Name;
            dynObjList = cacheRepository[Name] as List<T>;
            if (dynObjList == null)
            {
                dynObjList = new List<T>();
            }
        }

        //get All records of object
        public IQueryable<T> GetAllData()
        {
            return dynObjList.AsQueryable();
        }

        //Updating Cache...
        public void Commit()
        {
            cacheRepository[Name] = dynObjList;
        }

        //Add record.
        public void Add(T obj)
        {
            dynObjList.Add(obj);
        }

        //Get detail of sepecific record.
        public T GetDetail(string Id)
        {
            T dynSingleRecord = dynObjList.Find(x => x.ID == Id);
            if (dynSingleRecord == null)
                throw new Exception(Name + " is not found. Try again.");
            else
                return dynSingleRecord;
        }

        //Deleting the object from records.
        public void Delete(string Id)
        {
            T dynSingleRecord = GetDetail(Id);
            dynObjList.Remove(dynSingleRecord);
        }

    }
}
