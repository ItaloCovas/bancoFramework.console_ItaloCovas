using Domain.Model;

namespace Repository
{
    public interface IClienteRepository
    {

        Cliente GetById(int id);

        Cliente Create(Cliente cliente);

        void Update(Cliente cliente);

    }
}
