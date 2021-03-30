using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models
{
    public class Produto
    {
        

        public int Id { get;  set; }

        public string Nome { get;  set; }

        public  decimal Preco{ get;  set; }

        public int Estoque { get;  set; }

        public Produto()
        {
                
        }
       

        public Produto(int id, string nome, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            this.Preco = preco;
            Estoque = estoque;
        }
    }
}
