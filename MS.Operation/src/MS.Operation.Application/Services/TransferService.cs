using MS.Operation.Application.Interfaces;
using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;
using MS.Operation.Infrastructure.Interfaces;

namespace MS.Operation.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransferRepository _transferRepository;

        public TransferService(IAccountRepository accountRepository, ITransferRepository transferRepository)
        {
            _accountRepository = accountRepository;
            _transferRepository = transferRepository;
        }

        public OperationStatus Transfer(Transfer transfer)
        {
            if (transfer != null)
            {
                var originIsValid = _accountRepository.Exist(transfer.Origin);
                var destination = _accountRepository.Exist(transfer.Destination);

                if (originIsValid && destination)
                {
                    return _transferRepository.Transfer(transfer);
                }
                else
                {
                    if (!originIsValid)
                    {
                        return OperationStatus.InvalidOriginAccount;
                    }
                    else
                    {
                        return OperationStatus.InvalidDestinationAccount;
                    }
                }
            }

            return OperationStatus.InvalidData;
        }
    }
}
