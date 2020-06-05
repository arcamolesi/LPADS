using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA.CAMADAS.DAL
{
    public class Itens
    {
        private string strCon = CAMADAS.DAL.Conexao.getConexao();

        //Método para recuperar Dados da Tabela de Emprestimo
        public List<MODEL.Itens> Select()
        {
            List<MODEL.Itens> lstItens = new List<MODEL.Itens>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Itens;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    //preencher com dados do item
                    CAMADAS.MODEL.Itens item = new MODEL.Itens();
                    item.id = Convert.ToInt32(dados["id"].ToString());
                    item.emprestimoID = Convert.ToInt32(dados["emprestimoID"].ToString());
                    item.livroID = Convert.ToInt32(dados["livroID"].ToString());
                    item.entrega = Convert.ToDateTime(dados["entrega"].ToString());

                    //recuperar nome do livro
                    CAMADAS.BLL.Livros bllLivro = new BLL.Livros();
                    List<MODEL.Livros> listaLivro = bllLivro.SelectByID (item.livroID);
                    item.titulo = listaLivro[0].titulo;

                    lstItens.Add(item);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Itens...");
            }
            finally
            {
                conexao.Close();
            }

            return lstItens;
        }


        public List<MODEL.Itens> SelectByEmp(int id)
        {
            List<MODEL.Itens> lstItens = new List<MODEL.Itens>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Itens WHERE emprestimoID=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id); 
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    //preencher com dados do item
                    CAMADAS.MODEL.Itens item = new MODEL.Itens();
                    item.id = Convert.ToInt32(dados["id"].ToString());
                    item.emprestimoID = Convert.ToInt32(dados["emprestimoID"].ToString());
                    item.livroID = Convert.ToInt32(dados["livroID"].ToString());
                    item.entrega = Convert.ToDateTime(dados["entrega"].ToString());

                    //recuperar nome do livro
                    CAMADAS.BLL.Livros bllLivro = new BLL.Livros();
                    List<MODEL.Livros> listaLivro = bllLivro.SelectByID(item.livroID);
                    item.titulo = listaLivro[0].titulo;

                    lstItens.Add(item);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Itens...");
            }
            finally
            {
                conexao.Close();
            }

            return lstItens;
        }

        //Método para Inserir dados na tabela de Itens
        public void Insert(MODEL.Itens item)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Itens VALUES (@emprestimoID, @livroID, @entrega);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@emprestimoID", item.emprestimoID);
            cmd.Parameters.AddWithValue("@livroID", item.livroID);
            cmd.Parameters.AddWithValue("@entrega", item.entrega);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Emprestimo...");
            }
            finally
            {
                conexao.Close();
            }
        }


        //Método para Atualizar dados na tabela de itens
        public void Update(MODEL.Itens item)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Itens SET emprestimoID=@emprestimoID, livroID=@livroID, entrega=@entrega  ";
            sql += " WHERE id=@id";

            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", item.id);
            cmd.Parameters.AddWithValue("@emprestimoID", item.emprestimoID);
            cmd.Parameters.AddWithValue("@livroID", item.livroID);
            cmd.Parameters.AddWithValue("@entrega", item.entrega);


            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Itens...");
            }
            finally
            {
                conexao.Close();
            }

        }

        //Método para remover Itens
        public void Delete(int id)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Itens WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro remoção de Itens...");
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
