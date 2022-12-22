using passwordmanager.Core.Entities;
using passwordmanager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordmanager.Entities.Concrete
{
    public class Favorite : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int AccountPropertyId { get; set; }
        public string UserId { get; set; }


        [ForeignKey("AccountPropertyId")]
        public AccountProperty AccountProperty { get; set; }
    }
}
