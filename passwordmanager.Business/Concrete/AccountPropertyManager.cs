using passwordmanager.Business.Abstract;
using passwordmanager.DataAccess.Abstract;
using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Business.Concrete
{
    public class AccountPropertyManager : IAccountPropertyService
    {
        IAccountPropertyRepository _accountPropertyRepository;

        public AccountPropertyManager(IAccountPropertyRepository accountPropertyRepository)
        {
            _accountPropertyRepository = accountPropertyRepository;
        }

        public void Add(AccountProperty entity)
        {
            _accountPropertyRepository.Add(entity);
        }

        public void Delete(AccountProperty entity)
        {
            _accountPropertyRepository.Delete(entity);
        }

        public List<AccountProperty> GetAll()
        {
            return _accountPropertyRepository.GetAll();
        }

        public List<AccountProperty> GetAnotherTable()
        {
            return _accountPropertyRepository.GetAnotherTable();
        }

        public AccountProperty GetById(int id)
        {
            return _accountPropertyRepository.GetById(id);
        }

        public void Update(AccountProperty entity)
        {
            _accountPropertyRepository.Update(entity);
        }
    }
}
