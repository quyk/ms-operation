using Microsoft.AspNetCore.Mvc;
using MS.Operation.Application.Interfaces;
using MS.Operation.Application.Streaming;
using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;
using MS.Operation.Domain.Extensions;

namespace MS.Operation.API.Controllers
{
    [Route("api/transfer")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Transfer transfer)
        {
            var (valid, mesage) = JsonSchema<Transfer>.IsValid(transfer, "transfer-schema.json");
            if (valid)
            {
                try
                {
                    var result = _transferService.Transfer(transfer);
                    if (result == OperationStatus.Success)
                    {
                        return new CreatedResult(string.Empty, null);
                    }
                    
                    return new BadRequestObjectResult(new { message = result.Description() });
                }
                catch
                {
                    return new BadRequestResult();
                }
            }

            return new ConflictObjectResult(mesage);
        }
    }
}
