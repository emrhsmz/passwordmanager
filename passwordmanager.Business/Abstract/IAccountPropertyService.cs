using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Business.Abstract
{
    public interface IAccountPropertyService
    {
        List<AccountProperty> GetAll();
        List<AccountProperty> GetAnotherTable();
        AccountProperty GetById(int id);

        void Add(AccountProperty entity);
        void Update(AccountProperty entity);
        void Delete(AccountProperty entity);
    }
}
