using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MS.Operation.Application.Interfaces;
using MS.Operation.Domain.Entities;

namespace MS.Operation.API.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _accountService.Get();
                if (result.Any())
                {
                    return new OkObjectResult(result);
                }

                return new NoContentResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{number}")]
        public IActionResult GetByNumber(int number)
        {
            try
            {
                var result = _accountService.GetByNumber(new Account {Number = number});
                if (result != null)
                {
                    return new OkObjectResult(result);
                }

                return new NotFoundResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}