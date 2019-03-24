using Microsoft.AspNetCore.Mvc;
using Moq;
using MS.Operation.API.Controllers;
using MS.Operation.Application.Interfaces;
using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;
using System;
using Xunit;

namespace MS.Operation.API.Test.Controllers
{
    public class TransferControllerTest
    {
        private readonly Mock<ITransferService> _transferService;
        private readonly TransferController _transferController;
        private readonly Transfer _transfer;

        public TransferControllerTest()
        {
            _transferService = new Mock<ITransferService>();
            _transferController = new TransferController(_transferService.Object);
            _transfer = new Transfer
            {
                Origin = new Account { Number = 1124 },
                Destination = new Account { Number = 4785 },
                Value = 150.00
            };
        }

        [Fact]
        public void TransferConflictObjectResult()
        {
            _transfer.Origin = null;
            _transferService.Setup(x => x.Transfer(_transfer)).Throws<Exception>();

            var callback = _transferController.Post(_transfer);

            Assert.IsAssignableFrom<ConflictObjectResult>(callback);
        }

        [Fact]
        public void TransferBadRequest()
        {
            _transferService.Setup(x => x.Transfer(_transfer)).Throws<Exception>();

            var callback = _transferController.Post(_transfer);

            Assert.IsAssignableFrom<BadRequestResult>(callback);
        }

        [Fact]
        public void TransferCreatedResult()
        {
            _transferService.Setup(x => x.Transfer(_transfer)).Returns(OperationStatus.Success);

            var callback = _transferController.Post(_transfer);

            Assert.IsAssignableFrom<CreatedResult>(callback);
        }

        [Fact]
        public void TransferBadRequestObjectResult()
        {
            _transferService.Setup(x => x.Transfer(_transfer)).Returns(OperationStatus.NoBalance);

            var callback = _transferController.Post(_transfer);

            Assert.IsAssignableFrom<BadRequestObjectResult>(callback);
        }
    }
}
