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
    public class Platform : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int SystemTypeId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }

        [ForeignKey("SystemTypeId")]
        public SystemType SystemType { get; set; }
    }
}
