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
    }
}
