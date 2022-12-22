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
    public class SystemTypeManager : ISystemTypeService
    {
        ISystemTypeRepository _systemTypeRepository;

        public SystemTypeManager(ISystemTypeRepository systemTypeRepository)
        {
            _systemTypeRepository = systemTypeRepository;
        }

        public void Add(SystemType entity)
        {
            _systemTypeRepository.Add(entity);
        }

        public void Delete(SystemType entity)
        {
            _systemTypeRepository.Delete(entity);
        }

        public List<SystemType> GetAll()
        {
            return _systemTypeRepository.GetAll();
        }

        public SystemType GetById(int id)
        {
            return _systemTypeRepository.GetById(id);
        }

        public void Update(SystemType entity)
        {
            _systemTypeRepository.Update(entity);
        }
    }
}
