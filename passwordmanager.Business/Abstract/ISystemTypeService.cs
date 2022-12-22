using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Business.Abstract
{
    public interface ISystemTypeService
    {
        List<SystemType> GetAll();
        SystemType GetById(int id);

        void Add(SystemType entity);
        void Update(SystemType entity);
        void Delete(SystemType entity);
    }
}
