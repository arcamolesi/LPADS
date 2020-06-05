using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTECA.CAMADAS.BLL
{
    public class Itens
    {
        public List<MODEL.Itens> Select()
        {
            DAL.Itens dalItens = new DAL.Itens();
            return dalItens.Select();
        }

        public List<MODEL.Itens> SelectByEmp(int id)
        {

            DAL.Itens dalItens = new DAL.Itens();
            return dalItens.SelectByEmp(id);
        }

        public void Insert(MODEL.Itens item)
        {

            //regra de negócio para atualizar o livro
            BLL.Livros bllLivro = new Livros();
            List<MODEL.Livros> lstLivro = bllLivro.SelectByID(item.livroID);
            MODEL.Livros livro = lstLivro[0];
            livro.situacao = 2;
            bllLivro.Update(livro); 

            //inserir item emprestado. 
            DAL.Itens dalItens = new DAL.Itens();
            dalItens.Insert(item);
        }

        public void Devolver(MODEL.Itens item) {
            //regra de negócio para atualizar o livro
            BLL.Livros bllLivro = new Livros();
            List<MODEL.Livros> lstLivro = bllLivro.SelectByID(item.livroID);
            MODEL.Livros livro = lstLivro[0];
            livro.situacao = 1;
            bllLivro.Update(livro);

            item.entrega = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            //inserir item emprestado. 
            DAL.Itens dalItens = new DAL.Itens();
            dalItens.Update(item);
        }


        public void Update(MODEL.Itens item)
        {
            DAL.Itens dalItens = new DAL.Itens();
            dalItens.Update(item);
        }

        public void Delete(int id)
        {
            DAL.Itens dalItens = new DAL.Itens();
            dalItens.Delete(id);
        }
    }
}
