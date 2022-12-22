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
    public class FavoriteManager : IFavoriteService
    {
        IFavoriteRepository _favoriteRepository;

        public FavoriteManager(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public void Add(Favorite entity)
        {
            _favoriteRepository.Add(entity);
        }

        public void Delete(Favorite entity)
        {
            _favoriteRepository.Delete(entity);
        }

        public List<Favorite> GetAll()
        {
            return _favoriteRepository.GetAll();
        }

        public Favorite GetByAccountProprtyId(int id)
        {
            return _favoriteRepository.GetByAccountProprtyId(id);
        }

        public Favorite GetById(int id)
        {
            return _favoriteRepository.GetById(id);
        }

        public void Update(Favorite entity)
        {
            _favoriteRepository.Update(entity);
        }
    }
}
