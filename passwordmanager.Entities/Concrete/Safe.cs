using passwordmanager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Entities.Concrete
{
    public class Safe : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }

        public virtual List<AccountProperty> AccountProperties { get; set; }
    }
}
