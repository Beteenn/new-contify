using System;

namespace Rentfy.Domain.ValueObjects
{
    public class CPFValueObject : ADocumentValueObject
    {
        public CPFValueObject() { }

        public CPFValueObject(string number) : base(number) { }

        private string RemovePonctuation(string number)
        {
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

            var cpf = RemovePonctuation(Number);

            if (cpf.Length != 11)
                return false;

            if (!ValidateEqualNumbers())
                return false;

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            string tempCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }

        private bool ValidateEqualNumbers()
        {
            if ((Number == 00000000000.ToString())
                || (Number == 11111111111.ToString())
                || (Number == 22222222222.ToString())
                || (Number == 33333333333.ToString())
                || (Number == 44444444444.ToString())
                || (Number == 55555555555.ToString())
                || (Number == 66666666666.ToString())
                || (Number == 77777777777.ToString())
                || (Number == 88888888888.ToString())
                || (Number == 99999999999.ToString()))
                return false;

            return true;
        }

        public override string ToString()
        {
            if (!IsValid()) return Number;
            return Convert.ToUInt64(Number).ToString(@"000\.000\.000\-00");
        }
    }
}
