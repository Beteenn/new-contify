using System.Collections.Generic;

namespace Rentfy.Application.ViewModels
{
    public class StoreViewModel
    {
        public long Id { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public LegalPersonViewModel LegalPerson { get; set; }
    }
}
