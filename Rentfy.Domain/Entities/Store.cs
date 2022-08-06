using System;
using System.Collections.Generic;

namespace Rentfy.Domain.Entities
{
    public class Store
    {
        public long Id { get; private set; }
        public ProductCollection Products { get; private set; }
        public LegalPerson LegalPerson { get; private set; }
        public long LegalPersonId { get; private set; }
        public ICollection<Rent> Rents { get; private set; }

        public Store() { }

        public Store(LegalPerson legaPerson)
        {
            LegalPerson = legaPerson;
        }

        public Store(long legalPersonId)
        {
            LegalPersonId = legalPersonId;
        }

        public void AddProduct(Product product) => Products.AddItem(product);

        public void UpdateBasicInfo(Store storeUpdate)
        {
            LegalPersonId = storeUpdate.LegalPersonId;
        }
    }
}
