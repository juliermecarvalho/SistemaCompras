using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : Controller
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost, Route("solicitacao-compra/salvar")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarProduto([FromBody] RegistrarProdutoCommand registrarProdutoCommand)
        {
            _mediator.Send(registrarProdutoCommand);
            return StatusCode(201);
        }
    }
}
