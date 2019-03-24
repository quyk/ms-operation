using Microsoft.AspNetCore.Mvc;
using Moq;
using MS.Operation.API.Controllers;
using MS.Operation.Application.Interfaces;
using MS.Operation.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace MS.Operation.API.Test.Controllers
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountService> _accountService;
        private readonly AccountController _accountController;

        public AccountControllerTest()
        {
            _accountService = new Mock<IAccountService>();
            _accountController = new AccountController(_accountService.Object);
        }

        [Fact]
        public void GetOkObjectResult()
        {
            var accounts = new List<Account>
            {
                new Account
                {
                    Number = 3064,
                    Balance = 150.60,
                    Limit = true
                },
                new Account
                {
                    Number = 6828,
                    Balance = 170.96,
                    Limit = false
                }
            };
            _accountService.Setup(x => x.Get()).Returns(accounts);

            var callback = _accountController.Get();

            Assert.IsAssignableFrom<OkObjectResult>(callback);
        }

        [Fact]
        public void GetNoContentResult()
        {
            _accountService.Setup(x => x.Get()).Returns(new List<Account>());

            var callback = _accountController.Get();

            Assert.IsAssignableFrom<NoContentResult>(callback);
        }

        [Fact]
        public void GetBadRequestResult()
        {
            _accountService.Setup(x => x.Get()).Throws<Exception>();

            var callback = _accountController.Get();

            Assert.IsAssignableFrom<BadRequestResult>(callback);
        }

        [Fact]
        public void GetByNumberAccountOkObjectResult()
        {
            var account = new Account
            {
                Number = 3064,
                Balance = 150.60,
                Limit = true
            };

            _accountService.Setup(x => x.GetByNumber(It.IsAny<Account>())).Returns(account);

            var callback = _accountController.GetByNumber(3064);

            Assert.IsAssignableFrom<OkObjectResult>(callback);
        }

        [Fact]
        public void GetAccountNotFoundResult()
        {
            _accountService.Setup(x => x.GetByNumber(It.IsAny<Account>()));

            var callback = _accountController.GetByNumber(3064);

            Assert.IsAssignableFrom<NotFoundResult>(callback);
        }

        [Fact]
        public void GetAccountBadRequestResult()
        {
            _accountService.Setup(x => x.GetByNumber(It.IsAny<Account>())).Throws<Exception>();

            var callback = _accountController.GetByNumber(3064);

            Assert.IsAssignableFrom<BadRequestResult>(callback);
        }
    }
}
