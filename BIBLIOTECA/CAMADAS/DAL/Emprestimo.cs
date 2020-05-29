using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA.CAMADAS.DAL
{
    public class Emprestimo
    {
        private string strCon = CAMADAS.DAL.Conexao.getConexao(); 

        //Método para recuperar Dados da Tabela de Emprestimo
        public List<MODEL.Emprestimo> Select()
        {
            List<MODEL.Emprestimo> lstEmprestimo = new List<MODEL.Emprestimo>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "SELECT * FROM Emprestimo;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                SqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    //preencher com dados do emprestimo
                    CAMADAS.MODEL.Emprestimo emprestimo = new MODEL.Emprestimo();
                    emprestimo.id = Convert.ToInt32(dados["id"].ToString());
                    emprestimo.clienteID = Convert.ToInt32(dados["clienteID"].ToString());
                    emprestimo.data = Convert.ToDateTime(dados["data"].ToString());
                    
                    //recuperar nome do cliente
                    CAMADAS.DAL.Clientes dalCli = new Clientes();
                    CAMADAS.MODEL.Clientes cliente = dalCli.SelectById(emprestimo.clienteID);
                    emprestimo.nomeCli = cliente.nome; 
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na consulta de Emprestimo...");
            }
            finally
            {
                conexao.Close();
            }

            return lstEmprestimo;
        }

        //Método para Inserir dados na tabela de Emprestimo
        public void Insert(MODEL.Emprestimo emprestimo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "INSERT INTO Emprestimo VALUES (@clienteID, @data);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@clienteID", emprestimo.clienteID);
            cmd.Parameters.AddWithValue("@data", emprestimo.data);
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


        //Método para Atualizar dados na tabela de emprestimo
        public void Update(MODEL.Emprestimo emprestimo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "UPDATE Emprestimo SET clienteID=@clienteID, data=@dataID  ";
            sql += " WHERE id=@id";

            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", emprestimo.id);
            cmd.Parameters.AddWithValue("@clienteID", emprestimo.clienteID);
            cmd.Parameters.AddWithValue("@data", emprestimo.data);


            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Emprestimo...");
            }
            finally
            {
                conexao.Close();
            }

        }

        //Método para remover Emprestimo
        public void Delete(int idEmprestimo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "DELETE FROM Emprestimo WHERE id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", idEmprestimo);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro remoção de Emprestimo...");
            }
            finally
            {
                conexao.Close();
            }
        }



    }
}
