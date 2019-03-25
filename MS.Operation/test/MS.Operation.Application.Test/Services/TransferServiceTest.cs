using Moq;
using MS.Operation.Application.Services;
using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;
using MS.Operation.Infrastructure.Interfaces;
using Xunit;

namespace MS.Operation.Application.Test.Services
{
    public class TransferServiceTest
    {
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly Mock<ITransferRepository> _transferRepository;
        private readonly TransferService _transferService;
        private readonly Transfer _transfer;

        public TransferServiceTest()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _transferRepository = new Mock<ITransferRepository>();
            _transferService = new TransferService(_accountRepository.Object, _transferRepository.Object);
            _transfer = new Transfer
            {
                Origin = new Account
                {
                    Number = 3064
                },
                Destination = new Account
                {
                    Number = 6828
                },
                Value = 58.40
            };
        }

        [Fact]
        public void TransferIsNull()
        {
            var callback = _transferService.Transfer(null);

            Assert.IsAssignableFrom<OperationStatus>(callback);
        }

        [Fact]
        public void TransferOriginNotExist()
        {
            _accountRepository.Setup(x => x.Exist(_transfer.Origin)).Returns(false);

            var callback = _transferService.Transfer(_transfer);

            Assert.IsAssignableFrom<OperationStatus>(callback);
        }

        [Fact]
        public void TransferDestinationNotExist()
        {
            _accountRepository.Setup(x => x.Exist(_transfer.Origin)).Returns(true);
            _accountRepository.Setup(x => x.Exist(_transfer.Destination)).Returns(false);

            var callback = _transferService.Transfer(_transfer);

            Assert.IsAssignableFrom<OperationStatus>(callback);
        }

        [Fact]
        public void TransferSucess()
        {
            _accountRepository.Setup(x => x.Exist(_transfer.Origin)).Returns(true);
            _accountRepository.Setup(x => x.Exist(_transfer.Destination)).Returns(true);

            var callback = _transferService.Transfer(_transfer);

            Assert.IsAssignableFrom<OperationStatus>(callback);
        }
    }
}
