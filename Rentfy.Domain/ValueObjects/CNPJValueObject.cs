using System;

namespace Rentfy.Domain.ValueObjects
{
    public class CNPJValueObject : ADocumentValueObject
    {
        public string Number { get; private set; }

        public CNPJValueObject() { }
        public CNPJValueObject(string number)
        {
            Number = RemovePonctuation(number);
        }

        private string RemovePonctuation(string number)
        {
            if (string.IsNullOrEmpty(number)) return number;

            return number.Trim()
                .Replace(".", "")
                .Replace("-", "")
                .Replace("/", "")
                .Replace("%2F", "");
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Number))
                return false;

            var cnpj = RemovePonctuation(Number);

            if (cnpj.Length != 14)
                return false;

            int[] multiplier1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(cnpj[i].ToString()) * multiplier1[i];

            int rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            string tempCnpj = $"{cnpj.Substring(0, 12)}{rest.ToString()}";
            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cnpj.EndsWith(digit);
        }

        public override string ToString()
        {
            if (!IsValid()) return Number;
            return Convert.ToUInt64(Number).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
