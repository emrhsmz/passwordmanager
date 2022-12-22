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
    public class EfPlatformRepository : EfEntityRepositoryBase<Platform, PasswordManagerContext>, IPlatformRepository
    {
        public List<Platform> GetWithAnotherTable()
        {
            using (var context = new PasswordManagerContext())
            {
                return context.Platforms
                    .Include(a => a.SystemType)
                    .ToList();
            }
        }
    }
}
