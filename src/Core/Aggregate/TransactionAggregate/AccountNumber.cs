using System;
using System.Text.RegularExpressions;

namespace Core.Aggregate.TransactionAggregate
{
    public class AccountNumber : ValueObject<AccountNumber>
    {
        public string Value { get; private set; }

        public AccountNumber(string value) => Value = value;

        public static implicit operator AccountNumber(string value) => new AccountNumber(Parse(value));

        public static implicit operator string(AccountNumber AccountNumber) => Parse(AccountNumber.Value);

        private static string Parse(string value)
        {
            var lengthRequired = new Regex("^.{8,}$");
            if (string.IsNullOrWhiteSpace(value) || lengthRequired.IsMatch(value))
                throw new ArithmeticException($"You should inform a valid {nameof(AccountNumber)}");

            return value;
        }

        protected override bool EqualsCore(AccountNumber other)
        {
            AccountNumber AccountNumber = other as AccountNumber;

            if (AccountNumber is null)
                return false;

            if (ReferenceEquals(this, AccountNumber))
                return true;

            return AccountNumber.Value.Equals(Value);
        }

        protected override int GetHashCodeCore() => HashCode.Combine(Value);
    }
}
