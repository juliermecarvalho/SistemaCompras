using MediatR;
using SistemaCompra.Application.Produto.Command.RegistrarProduto;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {

        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }

        public IList<ItemCommand> Itens { get; set; }

    }

    public class ItemCommand : IRequest<bool>
    {
        public RegistrarProdutoCommand Produto { get; set; }
        public int Qtde { get; set; }
    }


}
