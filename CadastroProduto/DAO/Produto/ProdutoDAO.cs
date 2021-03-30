using MySql.Data.MySqlClient;
using CadastroProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.DAO.Produto
{
    public class ProdutoDAO
    {
        public string ConnectionString { get; set; }

        public ProdutoDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() 
        {
            return new MySqlConnection(ConnectionString);

        }

        public  List<Models.Produto> GetProdutos() 
        {
            List<Models.Produto> produtos = new List<Models.Produto>();

            using (MySqlConnection con = GetConnection()) 
            {
                con.Open();

                using(MySqlCommand cmd = con.CreateCommand()) 
                {
                    cmd.CommandText = @"Select * from Produto";

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Models.Produto p = new Models.Produto();

                            p.Id = int.Parse(dr[0].ToString());
                            p.Nome = (dr[1].ToString());
                            p.Preco = decimal.Parse(dr[2].ToString());
                            p.Estoque = int.Parse(dr[3].ToString());

                            produtos.Add(p);

                           
                        }
                    }
                }
            }
            return produtos;
        }
        public void CadastrarProduto(Models.Produto p)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Produto(Nome, Preco, Estoque) VALUES (@Nome, @Preco, @Estoque)";

                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Preco", p.Preco);
                    cmd.Parameters.AddWithValue("@Estoque", p.Estoque);


                    cmd.ExecuteNonQuery();

                }
            }
        }
        public Models.Produto GetProduto(int? id)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"Select * from Produto Where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Models.Produto p = new Models.Produto();

                            p.Id = int.Parse(dr[0].ToString());
                            p.Nome = (dr[1].ToString());
                            p.Preco = decimal.Parse(dr[2].ToString());
                            p.Estoque = int.Parse(dr[3].ToString());

                            return p;
                        }   
                        
                    }
                }
            }
            return null;
        }

        public void AlterarProduto(int id, Models.Produto p)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"update Produto set Nome = @Nome, Preco = @Preco, Estoque = @Estoque where Id = @Id";

                    cmd.Parameters.AddWithValue("@Nome", p.Nome);
                    cmd.Parameters.AddWithValue("@Preco", p.Preco);
                    cmd.Parameters.AddWithValue("@Estoque", p.Estoque);
                    cmd.Parameters.AddWithValue("@Id", id);


                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void DeleteProduto(int ? id)
        {
            using (MySqlConnection con = GetConnection())
            {
                con.Open();

                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Produto  where Id = @Id";

                   
                    cmd.Parameters.AddWithValue("@Id", id);


                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
