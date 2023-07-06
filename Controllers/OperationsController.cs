using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : Controller
    {
        private readonly OperationService _operationService;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationSingletonInstance _singletonInstanceOperation;

        public OperationsController(OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation)
        {
            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(
                new
                {
                    Transient = _transientOperation.OperationId,
                    TransientService = _operationService.TransientOperation.OperationId,
                    TransientComment = "Transient changes in every call",
                    Scoped = _scopedOperation.OperationId , 
                    ScopedService = _operationService.ScopedOperation.OperationId,
                    ScopedComment = "Scoped changes in new request , but stays as it is in same request ",
                    Singleton = _singletonOperation.OperationId,
                    SingletonService = _operationService.SingletonOperation.OperationId,
                    SingletonComment = "Singleton stays as it is always",
                    SingletonInstance = _singletonInstanceOperation.OperationId,
                    SingletonInstanceService = _operationService.SingletonInstanceOperation.OperationId,
                    SingletonInstanceComment = "Here we can use the same instance if we have an id"                 
                }
            );
        }
    }
}