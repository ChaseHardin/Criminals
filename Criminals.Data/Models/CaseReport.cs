using System;
using System.ComponentModel.DataAnnotations;

namespace Criminals.Data.Models
{
    public class CaseReport
    {
        [Key]
        public Guid DocketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
    }
}