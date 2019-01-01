using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Book : ITrackedItem
    {
        [Required] 
        public int Id { get; set; }

        public int? StorageID { get; set; }

        [Required]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$",ErrorMessage = "ISBN does not have a valid format!")]
        public string ISBN { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; } = " ";
        public string Note { get; set; }
        
        
    }
}