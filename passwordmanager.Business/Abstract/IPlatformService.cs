using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Business.Abstract
{
    public interface IPlatformService
    {
        List<Platform> GetAll();
        List<Platform> GetWithAnotherTable();
        Platform GetById(int id);

        void Add(Platform entity);
        void Update(Platform entity);
        void Delete(Platform entity);
    }
}
