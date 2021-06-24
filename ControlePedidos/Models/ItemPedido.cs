using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePedidos.Models
{
    public class ItemPedido
    {
        [Column("cod_item_pedido")]
        public int Id { get; set; }
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

        public ICollection<ItemPedido> ItemPedidos { get; set; }

        public ItemPedido()
        {
        }

        public ItemPedido(int id, int quantidade, int sequencial, Produto produto, Pedido pedido)
        {
            Id = id;
            Quantidade = quantidade;
            Sequencial = sequencial;
            Produto = produto;
            Pedido = pedido;
        }
    }
}
