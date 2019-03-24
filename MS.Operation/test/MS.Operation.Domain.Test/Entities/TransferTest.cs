using MS.Operation.Domain.Entities;
using Xunit;

namespace MS.Operation.Domain.Test.Entities
{
    public class TransferTest
    {
        private readonly Transfer _transfer;

        public TransferTest()
        {
            _transfer = new Transfer();
        }

        [Fact]
        public void AccountNotNull()
        {
            _transfer.Origin = new Account
            {
                Number = 1120,
                Balance = -10.50,
                Limit = true
            };

            Assert.NotNull(_transfer.Origin);
        }

        [Fact]
        public void DestinationNotNull()
        {
            _transfer.Destination = new Account
            {
                Number = 417,
                Balance = 150.20,
                Limit = true
            };

            Assert.NotNull(_transfer.Destination);
        }

        [Fact]
        public void ValueIsNotDefault()
        {
            _transfer.Value = 6.50;
            Assert.True(_transfer.Value != default(double));
        }

        [Fact]
        public void ValueIsDefault()
        {
            Assert.True(_transfer.Value == default(double));
        }
    }
}
