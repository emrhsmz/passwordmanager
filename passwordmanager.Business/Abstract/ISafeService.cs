using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Business.Abstract
{
    public interface ISafeService
    {
        List<Safe> GetAll();
        Safe GetById(int id);

        void Add(Safe entity);
        void Update(Safe entity);
        void Delete(Safe entity);
    }
}
