using System;

namespace Rentfy.Application.DTO
{
    public class PhysicalPersonDto : APersonDto
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
