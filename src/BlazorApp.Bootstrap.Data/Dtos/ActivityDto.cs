using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Dtos
{
    public class ActivityDto
    {
        public long Id { get; set; }
        
        [Required]
        public long ActivityTypeId { get; set; }
        
        [Required]
        public DateTime ActivityDate { get; set; }
        
        public string? Notes { get; set; }

        public string? ActivityType { get; set; }

        public string ActivityDay => ActivityDate == null ? "" : ActivityDate.DayOfWeek.ToString();

        public int MemberCount { get; set; }
    }
}
