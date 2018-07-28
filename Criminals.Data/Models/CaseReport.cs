using System;
using System.ComponentModel.DataAnnotations;

namespace Criminals.Data.Models
{
    public class CaseReport
    {
        [Key]
        public Guid DocketNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
    }
}