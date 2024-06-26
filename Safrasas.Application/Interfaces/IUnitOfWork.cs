namespace Safrasas.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRepository Clients { get; }
    }
}
