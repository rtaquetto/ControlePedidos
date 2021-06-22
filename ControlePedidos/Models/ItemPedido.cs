using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePedidos.Models
{
    public class ItemPedido
    {
        [Column("nu_qtd_item")]
        public int Quantidade { get; set; }
        [Column("nu_sequencial_pedido")]
        public int Sequencial { get; set; }
        [Column("cod_produto")]
        public int ProdutoId { get; set; }
        [Column("nu_pedido")]
        public int PedidoId { get; set; }

        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }

        public ItemPedido()
        {
        }

        public ItemPedido(int quantidade, int sequencial, Produto produto, Pedido pedido)
        {
            Quantidade = quantidade;
            Sequencial = sequencial;
            Produto = produto;
            Pedido = pedido;
        }

        //public double SubTotal()
        //{
        //  return Produto.ValorUnitario * Quantidade;
        //}
    }
}
