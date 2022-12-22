using System.ComponentModel.DataAnnotations;

namespace passwordmanager.WebUI.Models
{
    public class AccountPropertyModel
    {
        public int Id { get; set; }
        public int SystemTypeId { get; set; }
        public int PlatformId { get; set; }
        public int SafeId { get; set; }
        public string Comment { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        [DataType("Password")]
        public string Password { get; set; }
        [DataType("Password")]
        [Compare("Password")]
        public string RePassword { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }

        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
