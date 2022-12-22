using passwordmanager.Core.DataAccess;
using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.DataAccess.Abstract
{
    public interface IFavoriteRepository : IEntityRepository<Favorite>
    {
        Favorite GetByAccountProprtyId(int id);
    }
}
