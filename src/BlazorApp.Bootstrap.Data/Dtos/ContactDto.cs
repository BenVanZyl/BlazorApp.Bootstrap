using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Dtos
{
    public class ContactDto
    {
        [Required]
        public string SenderName { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
