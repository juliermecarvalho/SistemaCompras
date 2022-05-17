using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SistemaCompra.Domain.Test.ProdutoAggregate
{
    [TestClass]
    public class ProdutoAggregate_AtualizarPrecoDeve
    {
        [TestMethod]
        public void AtualizarPrecoDe400Para500()
        {
            //Dado
            var produto = new Produto("produto001", "desc", Categoria.Madeira.ToString(), 400);

            //Quando
            produto.AtualizarPreco(500);

            //Então
            Assert.AreEqual(500, produto.Preco.Value);
        }

        [TestMethod]
        public void NotificarErroQuandoProdutoEstaCancelado()
        {
            //Dado
            var produto = new Produto("produto001", "desc", Categoria.Madeira.ToString(), 400);
            produto.Suspender();

            //Quando
            var ex = Assert.ThrowsException<BusinessRuleException>(() => produto.AtualizarPreco(500));

            //Então
            Assert.AreEqual("Produto deve estar ativo!", ex.Message);
        }
    }
}
