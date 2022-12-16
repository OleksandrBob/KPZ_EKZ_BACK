using Cars.Core.Repository;
using Cars.Core.Services.Interfaces;
using Cars.DAL.Models;

namespace Cars.Core.Services
{
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOperation(Operation operation)
        {
            _unitOfWork.Operations.Add(operation);
        }
    }
}
