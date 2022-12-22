using passwordmanager.Core.DataAccess;
using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.DataAccess.Abstract
{
    public interface IPlatformRepository : IEntityRepository<Platform>
    {
        List<Platform> GetWithAnotherTable();
    }
}
