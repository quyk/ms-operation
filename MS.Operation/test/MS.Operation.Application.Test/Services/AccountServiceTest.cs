using System.Collections.Generic;
using Moq;
using MS.Operation.Application.Services;
using MS.Operation.Domain.Entities;
using MS.Operation.Infrastructure.Interfaces;
using Xunit;

namespace MS.Operation.Application.Test.Services
{
    public class AccountServiceTest
    {
        private readonly AccountService _accountService;
        private readonly Mock<IAccountRepository> _accountRepository;

        public AccountServiceTest()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _accountService = new AccountService(_accountRepository.Object);
        }

        [Fact]
        public void Get()
        {
            var accounts = new List<Account>
            {
                new Account
                {
                    Number = 3322,
                    Balance = 115, 
                    Limit = false
                },
                new Account
                {
                    Number = 6828,
                    Balance = -145.00,
                    Limit = true
                }
            };
            _accountRepository.Setup(x => x.Get()).Returns(accounts);

            var callback = _accountService.Get();

            Assert.IsAssignableFrom<IList<Account>>(callback);
        }

        [Fact]
        public void GetByNumberIsNotNull()
        {
            var account = new Account
            {
                Number = 6828,
                Balance = -145.00,
                Limit = true
            };

            _accountRepository.Setup(x => x.GetByNumber(It.IsAny<Account>())).Returns(account);

            var callback = _accountService.GetByNumber(new Account { Number = 6828});

            Assert.IsAssignableFrom<Account>(callback);
        }

        [Fact]
        public void GetByNumberIsNull()
        {
            _accountRepository.Setup(x => x.GetByNumber(It.IsAny<Account>()));

            var callback = _accountService.GetByNumber(null);

            Assert.Null(callback);
        }
    }
}