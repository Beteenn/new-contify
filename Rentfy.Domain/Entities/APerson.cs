using Rentfy.Domain.ValueObjects;

namespace Rentfy.Domain.Entities
{
    public abstract class APerson
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public EmailValueObject Email { get; private set; }
        public abstract ADocumentValueObject Document { get; }

        public APerson() {}

        public APerson(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public APerson(string name, string email)
        {
            Name = name;
            Email = new EmailValueObject(email);
        }

        public void UpdateName(string newName) => Name = newName;

        public void UpdateEmail(string newEmail) => Email = new EmailValueObject(newEmail);

    }

}
