using Domain;

namespace Application.Interfaces
{
    public interface IClientPersistence
    {
        Task<bool> Create(Client client);
        Task<bool> Update();
        Task<Client?> GetById(Guid clientId);
        Task<IEnumerable<Client>> Filter(int page, int itemByPage);
    }
}
