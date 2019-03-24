using MS.Operation.Domain.Entities;
using Xunit;

namespace MS.Operation.Domain.Test.Entities
{
    public class AccountTest
    {
        private readonly Account _account;

        public AccountTest()
        {
            _account = new Account();
        }

        [Fact]
        public void NumberIsNotDefault()
        {
            _account.Number = 6781;
            Assert.True(_account.Number != default(int));
        }

        [Fact]
        public void NumberIsDefault()
        {
            Assert.True(_account.Number == default(int));
        }

        [Fact]
        public void BalanceIsNotDefault()
        {
            _account.Balance = 100.51;
            Assert.True(_account.Balance != default(int));
        }

        [Fact]
        public void BalanceIsDefault()
        {
            Assert.True(_account.Balance == default(double));
        }

        [Fact]
        public void LimitIsTrue()
        {
            _account.Limit = true;
            Assert.True(_account.Limit);
        }

        [Fact]
        public void BalanceIsFa()
        {
            Assert.False(_account.Limit);
        }
    }
}
