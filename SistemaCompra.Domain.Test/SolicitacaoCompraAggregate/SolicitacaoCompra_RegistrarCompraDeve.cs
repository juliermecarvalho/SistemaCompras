using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SistemaCompra.Domain.Test.SolicitacaoCompraAggregate
{
    [TestClass]
    public class SolicitacaoCompra_RegistrarCompraDeve
    {

        /// <summary>
        /// troquei o framework para o do propio Visual Studio pq não estava rodando o Xnuit
        /// </summary>
        [TestMethod]
        public void DefinirPrazo30DiasAoComprarMais50mil()
        {
            //Dado
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var itens = new List<Item>();
            var produto = new Produto("Cedro", "Transversal 3/3", Categoria.Madeira.ToString(), 1001);
            itens.Add(new Item(produto, 50));

            //Quando
            solicitacao.RegistrarCompra(itens);

            //Então
            Assert.AreEqual(30, solicitacao.CondicaoPagamento.Valor);
        }


        [TestMethod]
        public void NotificarErroQuandoNaoInformarItensCompra()
        {
            //Dado
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var itens = new List<Item>();

            //Quando 
            var ex = Assert.ThrowsException<BusinessRuleException>(() => solicitacao.RegistrarCompra(itens));

            //Então
            Assert.AreEqual("A solicitação de compra deve possuir itens!", ex.Message);
        }
    }
}
