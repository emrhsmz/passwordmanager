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
    public class EfAccountPropertyRepository : EfEntityRepositoryBase<AccountProperty, PasswordManagerContext>, IAccountPropertyRepository
    {
        public List<AccountProperty> GetAnotherTable()
        {
            using (var context = new PasswordManagerContext())
            {
                return context.AccountProperties
                    .Include(a => a.Safe)
                    .Include(a => a.Platform)
                    .Include(a => a.SystemType)
                    .Include(a=>a.Favorites)
                    .ToList();
            }
        }
    }
}
