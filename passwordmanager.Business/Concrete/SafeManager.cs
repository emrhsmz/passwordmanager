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
    public class SafeManager : ISafeService
    {
        ISafeRepository _safeRepository;

        public SafeManager(ISafeRepository safeRepository)
        {
            _safeRepository = safeRepository;
        }

        public void Add(Safe entity)
        {
            _safeRepository.Add(entity);
        }

        public void Delete(Safe entity)
        {
            _safeRepository.Delete(entity); 
        }

        public List<Safe> GetAll()
        {
            return _safeRepository.GetAll();
        }

        public Safe GetById(int id)
        {
            return _safeRepository.GetById(id);
        }

        public void Update(Safe entity)
        {
            _safeRepository.Update(entity);
        }
    }
}
