using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePedidos.Models.ViewModels
{
    public class ItemPedidoFormViewModel
    {
        public ItemPedido ItemPedido { get; set; }
        public Pedido Pedido { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();
    }
}
