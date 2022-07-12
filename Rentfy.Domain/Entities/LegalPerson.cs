using Rentfy.Domain.ValueObjects;
using System;

namespace Rentfy.Domain.Entities
{
    public class LegalPerson : APerson
    {
        public string FantasyName { get; set; }
        public CNPJValueObject CNPJ { get; private set; }

        public override ADocumentValueObject Document => CNPJ;

        public LegalPerson() { }

        public LegalPerson(string name, string email, string cnpj, string fantasyName) : base(name, email)
        {
            CNPJ = new CNPJValueObject(cnpj);
            FantasyName = fantasyName;
        }

        public void UpdateFantasyName(string newFantasyName) => FantasyName = newFantasyName;

        public void UpdateBasicInfo(LegalPerson personUpdate)
        {
            UpdateEmail(personUpdate.Email.Address);
            UpdateName(personUpdate.Name);
            CNPJ = new CNPJValueObject(personUpdate.CNPJ.Number);
            FantasyName = personUpdate.FantasyName;
        }
    }
}
