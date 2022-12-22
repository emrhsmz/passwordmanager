using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Business.Abstract
{
    public interface IFavoriteService
    {
        List<Favorite> GetAll();
        Favorite GetById(int id);
        Favorite GetByAccountProprtyId(int id);

        void Add(Favorite entity);
        void Update(Favorite entity);
        void Delete(Favorite entity);
    }
}
