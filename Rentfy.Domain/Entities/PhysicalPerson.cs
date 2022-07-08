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

        public PhysicalPerson(long id, string name, string lastName) : base(id, name) 
        {
            LastName = lastName;
        }

        public PhysicalPerson(string name, string email, string lastName, DateTime birthDate, string cpf) : base(name, email)
        {
            LastName = lastName;
            BirthDate = birthDate;
            CPF = new CPFValueObject(cpf);
        }

        public void UpdateLastName(string newLastName) => LastName = newLastName;

        public void UpdateDocumento(CPFValueObject newDocument) => CPF = newDocument;

    }
}
