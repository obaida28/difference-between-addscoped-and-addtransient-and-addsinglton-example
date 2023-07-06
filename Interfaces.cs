// namespace DIclass;
// public interface IMyDependency
// {
//     public string? name { get; set; }
//     public string? Description { get; set; }
// }

// public class MyDependency : IMyDependency
// {
//     public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
//     public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
// }


using System;

namespace DependencyInjectionSample.Interfaces
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {
    }

    public interface IOperationScoped : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }

    public interface IOperationSingletonInstance : IOperation
    {
    }
}