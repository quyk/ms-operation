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
                if (_accountRepository.Exist(transfer.Origin))
                {
                    if (_accountRepository.Exist(transfer.Destination))
                    {
                        return _transferRepository.Transfer(transfer);
                    }

                    return OperationStatus.InvalidDestinationAccount;
                }

               return OperationStatus.InvalidOriginAccount;
            }

            return OperationStatus.InvalidData;
        }
    }
}
