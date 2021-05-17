using Confitec.Application.Interfaces;
using Confitec.Domain.Entities;
using Confitec.Domain.Interfaces.Services;

namespace Confitec.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public void Add(Cliente cliente)
        {
            cliente.validaData();
            _clienteService.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            cliente.validaData();
            _clienteService.Add(cliente);
        }
    }
}
