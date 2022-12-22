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
    public class EfSafeRepository : EfEntityRepositoryBase<Safe, PasswordManagerContext>, ISafeRepository
    {
    }
}
