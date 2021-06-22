using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePedidos.Models
{
    public class Produto
    {
        [Column("cod_produto")]
        public int Id { get; set; }
        [Column("nm_produto")]
        public string Nome { get; set; }
        [Column("vlr_unitario")]
        public decimal ValorUnitario { get; set; }
        [Column("cod_categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

        public Produto()
        {
        }

        public Produto(int id, string nome, decimal valorUnitario, int categoriaId)
        {
            Id = id;
            Nome = nome;
            ValorUnitario = valorUnitario;
            CategoriaId = categoriaId;
        }
    }
}
