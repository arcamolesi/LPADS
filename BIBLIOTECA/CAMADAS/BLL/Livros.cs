using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA.CAMADAS.BLL
{
    public class Livros
    {
        public List<MODEL.Livros> Select()
        {
            DAL.Livros dalLivro = new DAL.Livros();
            ///... verificações e regras de negócios
            return dalLivro.Select(); 
        }

        public void Insert (MODEL.Livros livro)
        {
            DAL.Livros dalLivro = new DAL.Livros();
            // escrever regras de negócios

            dalLivro.Insert(livro); 
        }

        public void Update (MODEL.Livros livro)
        {
            DAL.Livros dalLivro = new DAL.Livros();
            //.regras de negócios
            if (livro.autor!= String.Empty)
                dalLivro.Update(livro); 
        }

        public void Delete(int idLivro)
        {
            DAL.Livros dalLivro = new DAL.Livros();
            // regras de negócio 
            if (idLivro > 0)
               dalLivro.Delete(idLivro); 
            
        }
    }
}
