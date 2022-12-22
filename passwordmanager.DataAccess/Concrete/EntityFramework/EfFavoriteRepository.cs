using Microsoft.EntityFrameworkCore;
using passwordmanager.Core.DataAccess.EntityFramework;
using passwordmanager.DataAccess.Abstract;
using passwordmanager.DataAccess.Concrete.EntityFramework.Context;
using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.DataAccess.Concrete.EntityFramework
{
    public class EfFavoriteRepository : EfEntityRepositoryBase<Favorite, PasswordManagerContext>, IFavoriteRepository
    {
        public Favorite GetByAccountProprtyId(int id)
        {
            using (var context = new PasswordManagerContext())
            {
                return context.Favorites
                    .Where(i => i.AccountPropertyId == id)
                    .Include(a => a.AccountProperty)
                    .FirstOrDefault();
            }
        }
    }
}
