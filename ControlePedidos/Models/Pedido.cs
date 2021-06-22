using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePedidos.Models
{
    public class Pedido
    {
        [Column("nu_pedido")]
        public int Id { get; set; }
        [Column("dt_pedido")]
        public DateTime Data { get; set; }
        [Column("vlr_total")]
        public decimal ValorTotal { get; set; }
        [Column("dsc_pedido")]
        public string Descricao { get; set; }
        public ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

        public Pedido()
        {
        }

        public Pedido(int id, DateTime data, decimal valorTotal, string descricao)
        {
            Id = id;
            Data = data;
            ValorTotal = valorTotal;
            Descricao = descricao;
        }

        public void AddItem(ItemPedido ip)
        {
            ItemPedidos.Add(ip);
        }

        public void RemoveItem(ItemPedido ip)
        {
            ItemPedidos.Remove(ip);
        }

        //public double ValorPedido()
        //{
        //    return ItemPedidos.Sum(ItemPedido => ItemPedido.SubTotal());
        //}
    }
}
