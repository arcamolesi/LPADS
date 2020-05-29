using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;

namespace BIBLIOTECA.CAMADAS.DAL
{
    public class Clientes
    {
        
        private string strCon = Conexao.getConexao(); 

        //Método para recuperar Dados da Tabela de Clientes
        public List<MODEL.Clientes> Select()
        {
            List<MODEL.Clientes> lstClientes = new List<MODEL.Clientes>(); 
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Clientes cliente = new MODEL.Clientes();
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.curso = dados["curso"].ToString();
                    cliente.dias = Convert.ToInt32(dados["dias"].ToString());
                    cliente.multa = Convert.ToSingle(dados["multa"].ToString());
                    lstClientes.Add(cliente);
                }
            }
            catch {
                Console.WriteLine("Deu erro na consulta de Clientes..."); 
            }
            finally
            {
                conexao.Close(); 
            }

            return lstClientes; 
        }


        public MODEL.Clientes SelectById(int id)
        {
            MODEL.Clientes cliente = new MODEL.Clientes(); 
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Clientes WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id); 
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
               if (dados.Read())
                {
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.curso = dados["curso"].ToString();
                    cliente.dias = Convert.ToInt32(dados["dias"].ToString());
                    cliente.multa = Convert.ToSingle(dados["multa"].ToString());
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Clientes por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return cliente;
        }

        //Método para Inserir dados na tabela de clientes
        public void Insert (MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Clientes VALUES (@nome, @curso, @dias, @multa);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@curso", cliente.curso);
            cmd.Parameters.AddWithValue("@dias", cliente.dias);
            cmd.Parameters.AddWithValue("@multa", cliente.multa);
         

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }
        }


        //Método para Atualizar dados na tabela de clientes
        public void Update (MODEL.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Clientes SET nome=@nome, curso=@curso, dias=@dias, multa=@multa ";
                   sql += " WHERE id=@id";

            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id); 
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@curso", cliente.curso);
            cmd.Parameters.AddWithValue("@dias", cliente.dias);
            cmd.Parameters.AddWithValue("@multa", cliente.multa);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Clientes...");
            }
            finally
            {
                conexao.Close();
            }

        }

        //Método para remover Cliente
        public void Delete (int idCliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Clientes WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", idCliente);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); 
            }
            catch
            {
                Console.WriteLine("Erro remoção de Clientes..."); 
            }
            finally
            {
                conexao.Close(); 
            }
        }


    }
}
