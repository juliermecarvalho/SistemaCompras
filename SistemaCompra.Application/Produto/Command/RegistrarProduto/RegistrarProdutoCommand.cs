using MediatR;
using System;

namespace SistemaCompra.Application.Produto.Command.RegistrarProduto
{
    public class RegistrarProdutoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
