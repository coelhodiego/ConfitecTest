using AutoMapper;
using Confitec.Api.ViewModels;
using Confitec.Application.Interfaces;
using Confitec.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Confitec.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>    
    /// <response code="400">Requisição inválida</response>   
    /// <response code="404">A página requerida é inexistente</response>   
    /// <response code="500">Erro interno de servidor</response>            
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteAppService clienteAppService, IMapper mapper)
        {
            _clienteAppService = clienteAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// Listar rodos clientes
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteViewModel>))]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var retorno =_clienteAppService.GetAll();

                return Ok(_mapper.Map<List<ClienteViewModel>>(retorno));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Buscar cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteViewModel))]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var retorno = _clienteAppService.GetById(id);

                if(retorno != null)
                    return Ok(_mapper.Map<ClienteViewModel>(retorno));

                return BadRequest("Cliente inexistente");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Adiciona cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public IActionResult Add(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clienteAppService.Add(_mapper.Map<Cliente>(clienteViewModel));

                    return Ok();
                }
                catch (System.Exception ex)
                {
                    return BadRequest("Erro ao adicionar Cliente: " + ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Atualiza dados do cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public IActionResult Update(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clienteAppService.Update(_mapper.Map<Cliente>(clienteViewModel));

                    return Ok(true);
                }
                catch (System.Exception ex)
                {
                    return BadRequest("Erro ao atualizar Cliente: " + ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Remove cliente da base
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public IActionResult Delete(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clienteAppService.Remove(_clienteAppService.GetById(clienteViewModel.Id));

                    return Ok(true);
                }
                catch (System.Exception ex)
                {
                    return BadRequest("Erro ao excluir Cliente: " + ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
