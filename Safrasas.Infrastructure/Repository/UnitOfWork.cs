using Safrasas.Application.Interfaces;

namespace Safrasas.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IClientRepository ClientRepository)
        {
            Clients = ClientRepository;
        }

        public IClientRepository Clients { get; set; }
    }
}
