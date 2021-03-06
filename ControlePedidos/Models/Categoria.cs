using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePedidos.Models
{
    public class Categoria
    {
        [Column("cod_categoria")]
        public int Id { get; set; }
        [Column("nm_categoria")]
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
