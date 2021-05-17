using Confitec.Domain.Entities;
using Confitec.Domain.Interfaces.Repositories;
using Confitec.Domain.Interfaces.Services;

namespace Confitec.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
