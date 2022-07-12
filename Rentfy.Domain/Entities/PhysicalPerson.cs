using Rentfy.Domain.ValueObjects;
using System;

namespace Rentfy.Domain.Entities
{
    public class PhysicalPerson : APerson
    {
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public CPFValueObject CPF { get; private set; }
        public override ADocumentValueObject Document => CPF;
        public string FullName => $"{Name} {LastName}";

        public PhysicalPerson() { }

        public PhysicalPerson(long id, string name, string lastName, DateTime birthDate, string cpf) : base(id, name) 
        {
            LastName = lastName;
            BirthDate = birthDate;
            CPF = new CPFValueObject(cpf);
        }

        public PhysicalPerson(string name, string email, string lastName, DateTime birthDate, string cpf) : base(name, email)
        {
            LastName = lastName;
            BirthDate = birthDate;
            CPF = new CPFValueObject(cpf);
        }

        public void UpdateLastName(string newLastName) => LastName = newLastName;

        public void UpdateDocumento(CPFValueObject newDocument) => CPF = newDocument;

        public void UpdateBasicInfo(PhysicalPerson personUpdate)
        {
            UpdateEmail(personUpdate.Email.Address);
            UpdateName(personUpdate.Name);
            LastName = personUpdate.LastName;
            BirthDate = personUpdate.BirthDate;
            CPF = new CPFValueObject(personUpdate.CPF.Number);
        }
    }
}
