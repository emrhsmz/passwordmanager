using passwordmanager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Entities.Concrete
{
    public class AccountProperty : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int SystemTypeId { get; set; }
        public int PlatformId { get; set; }
        public int SafeId { get; set; }
        public string Comment { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public bool isFavorite { get; set; }

        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }

        [ForeignKey("SystemTypeId")]
        public SystemType SystemType { get; set; }

        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }

        [ForeignKey("SafeId")]
        public Safe Safe { get; set; }

        public virtual List<Favorite> Favorites { get; set; }
    }
}
