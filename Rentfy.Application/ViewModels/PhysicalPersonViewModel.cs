using System;

namespace Rentfy.Application.ViewModels
{
    public class PhysicalPersonViewModel : APersonViewModel
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string FullName { get; set; }
    }
}
