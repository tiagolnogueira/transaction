using System;

namespace Core.Aggregate.TransactionAggregate
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get; private set; }

        public Money(decimal value) => Value = value;

        public static implicit operator Money(decimal value) => new Money(Parse(value));

        public static implicit operator decimal(Money Money) => Parse(Money.Value);

        private static decimal Parse(decimal value)
        {
            if(value < 0)
                throw new ArithmeticException("Value should be greater than 0");

            return value;
        }

        protected override bool EqualsCore(Money other)
        {
            Money Money = other as Money;

            if (Money is null)
                return false;

            if (ReferenceEquals(this, Money))
                return true;

            return Money.Value.Equals(Value);
        }

        protected override int GetHashCodeCore() => HashCode.Combine(Value);
    }
}
