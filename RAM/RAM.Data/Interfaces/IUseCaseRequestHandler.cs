using System;
using System.Threading.Tasks;

namespace RAM.Data.Interfaces
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse> where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
}
