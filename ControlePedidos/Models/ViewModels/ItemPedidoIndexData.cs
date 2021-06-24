using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePedidos.Models.ViewModels
{
    public class ItemPedidoIndexData
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<ItemPedido> ItemPedidos { get; set; }
    }
}
