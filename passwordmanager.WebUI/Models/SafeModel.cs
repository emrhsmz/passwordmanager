﻿namespace passwordmanager.WebUI.Models
{
    public class SafeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
    }
}
