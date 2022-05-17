using MediatR;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository solicitacaoCompraRepository;
        private readonly IProdutoRepository produtoRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IProdutoRepository produtoRepository,  IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitacaoCompraRepository = solicitacaoCompraRepository;
            this.produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);
            var itens = new List<Item>();

            foreach(var i in request.Itens)
            {

                var produto = produtoRepository.Obter(i.Produto.Id);
               var item = new Item(produto, i.Qtde);
                itens.Add(item);
            }

            solicitacaoCompra.RegistrarCompra(itens);


            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}
