namespace Rentfy.Domain.ValueObjects
{
    public abstract class ADocumentValueObject : AValueObject
    {
        public string Number { get; private set; }

        public ADocumentValueObject() { }

        public ADocumentValueObject(string number)
        {
            Number = number;
        }

        public void UpdateNumber(string newNumber) => Number = newNumber;
    }
}
