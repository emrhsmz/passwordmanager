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
    public class PlatformManager : IPlatformService
    {
        IPlatformRepository _platformRepository;

        public PlatformManager(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public void Add(Platform entity)
        {
            _platformRepository.Add(entity);
        }

        public void Delete(Platform entity)
        {
            _platformRepository.Delete(entity);
        }

        public List<Platform> GetAll()
        {
            return _platformRepository.GetAll();
        }

        public Platform GetById(int id)
        {
            return _platformRepository.GetById(id);
        }

        public List<Platform> GetWithAnotherTable()
        {
            return _platformRepository.GetWithAnotherTable();
        }

        public void Update(Platform entity)
        {
            _platformRepository.Update(entity);
        }
    }
}
