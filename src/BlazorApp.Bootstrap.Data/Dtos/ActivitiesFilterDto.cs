using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Dtos
{
    public class ActivitiesFilterDto
    {
        public long? ActivityTypeId { get; set; }

        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}
