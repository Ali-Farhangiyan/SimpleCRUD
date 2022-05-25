using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Range(1,120)]
        public int Age { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
