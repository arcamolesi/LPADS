using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIBLIOTECA.CAMADAS; 

namespace BIBLIOTECA.RELATORIOS
{
    public class RelGerais
    {
        public static void relLivro()
        {
            CAMADAS.BLL.Livros bllLivro = new CAMADAS.BLL.Livros();
            List<CAMADAS.MODEL.Livros> lstLivros = new List<CAMADAS.MODEL.Livros>();
            lstLivros = bllLivro.Select(); 

            string pasta = Funcoes.deretorioPasta();
            string arquivo = pasta + @"\RelLivros_"+DateTime.Now.ToShortDateString().Replace("/","_")+ "_" + DateTime.Now.ToLongTimeString().Replace(":","_")+".html";
            StreamWriter sw = new StreamWriter(arquivo);
            using (sw)
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv='Content-Type' " +
                            "content='text/html; charset=utf-8'/>");
                sw.WriteLine("<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>");

                sw.WriteLine("</head>");

                sw.WriteLine("<body>");
                sw.WriteLine("<h1>Relatório de Livros</h1>");
                sw.WriteLine("<hr align='left' border:'5px' />");

                sw.WriteLine("<table class='table table-striped'>");
                //Cabeçalho da tabela

                sw.WriteLine("<tr align='right'>");
                sw.WriteLine("<th align='right' width='30px'>");
                sw.WriteLine("ID");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='250px'>");
                sw.WriteLine("TITULO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='150px'>");
                sw.WriteLine("EDITORA");
                sw.WriteLine("</th>");
                sw.WriteLine("<th  align='right' width='150px'>");
                sw.WriteLine("AUTOR");
                sw.WriteLine("</th>");
                sw.WriteLine("<th  align='right' width='150px'>");
                sw.WriteLine("VALOR");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='60px'>");
                sw.WriteLine("SITUAÇÃO");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");

                int cont = 0;
                float soma = 0; 
                foreach (CAMADAS.MODEL.Livros  livro in lstLivros.OrderBy(o => o.situacao).ThenBy(t=>t.autor).ThenBy(w=>w.titulo))
                {
  
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td align='right' width='30px'>");
                    sw.WriteLine(livro.id);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='right' width='250px'>");
                    sw.WriteLine(livro.titulo);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='right' width='150px'>");
                    sw.WriteLine(livro.editora);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td  align='right' width='150px'>");
                    sw.WriteLine(livro.autor);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td  align='right' width='150px'>");
                    sw.WriteLine(string.Format("{0:C2}", livro.valor));
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='right' width='60px'>");
                    sw.WriteLine(livro.situacao);
                    sw.WriteLine("</td>");
                    sw.WriteLine("</tr>");
                    soma = soma + livro.valor; 
                    cont++; 
                }



                
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("</table>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<h2>");
                sw.WriteLine("Total de Registros Impressos: " + cont.ToString());
                sw.WriteLine("</br>");
                sw.WriteLine("Valor total dos Livros R$: "+ string.Format("{0:#.#,00}",soma));
                sw.WriteLine("</body>");
                sw.WriteLine("</h2>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arquivo);
        }



    }
}
